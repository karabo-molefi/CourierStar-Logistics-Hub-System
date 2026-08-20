# CourierStarApp

A menu-driven console application simulating the operations console for a
courier/logistics hub — staff, vehicles, customers, packages, and orders —
built as a Smart Operations Console System.

## System Overview

CourierStarApp manages four connected areas of a courier business:

- **Staff** — Drivers (with a license type) and Office Staff (assigned to a
  workstation), both derived from an abstract `Staff` base class.
- **Vehicles** — Motorcycles, Vans, and Trucks, each with its own weight and
  volume capacity, derived from an abstract `Vehicle` base class.
- **Customers** — contact and delivery-address records.
- **Orders & Packages** — an order links a customer to a package and, where
  possible, a vehicle.

When an order is created, the system immediately tries to match it to a
vehicle with enough remaining weight/volume capacity. If none is free right
now, the order isn't just left stuck — it's handed off to a background
**auto-dispatch queue** that keeps retrying it without blocking the menu (see
[Multithreading](#multithreading) below). As vehicles get loaded, they raise
**events** when they cross a capacity warning threshold or become full (see
[Events & Delegates](#events--delegates) below).

## How to Run

1. Open `CourierStarApp.csproj` in Visual Studio (or run `dotnet build` /
   `dotnet run` from the project folder if you're on the .NET CLI).
2. Build and run — the console starts a background dispatch service, then
   shows the main menu:
   ```
   1. Manage Staff
   2. Manage Vehicles
   3. Manage Orders
   4. Manage Customers
   5. Manage System
   6. Exit
   ```
3. Try it end-to-end: **Manage Vehicles → Add a New vehicle** (or just use
   the starter fleet), then **Manage Customers → Add new customer**, then
   **Manage Orders → Add New Package** followed by **Add a New Order**. If
   every vehicle that could carry the package is already full, the order is
   queued and you'll see an `[Auto-Dispatch]` message appear on its own a few
   seconds later once a vehicle frees up or a new one is added.

## Key Design Decisions

- **Abstraction & inheritance**: `Staff` and `Vehicle` are abstract base
  classes; `Driver`/`OfficeStaff` and `Motorcyle`/`Van`/`Truck` provide
  concrete, type-specific behaviour (ID formatting, capacity rules) via
  overridden methods — demonstrating polymorphism through a single
  `PrintDetails()`/`CanCarry()` call site that behaves differently per type.
- **Encapsulation**: mutable state (`staffID`, `CurrentLoad`, `OrderId`, etc.)
  is exposed only through constructors, properties with private setters, or
  explicit update methods — never as public mutable fields.
- **Interfaces**: `IPrintable` (a display contract every entity implements)
  and `IWarning`/`ISearch` decouple *what* a class can do from *how* it does
  it, so the menu code can work with the interface rather than a concrete
  type.
- **Custom exceptions**: `LicenseMismatchException` for an invalid
  driver/vehicle license pairing, and `DispatchException` for a logically
  invalid dispatch attempt (e.g. an order with no package) — both represent
  domain rule violations, not framework crashes.
- **Domain rule**: a vehicle can only be assigned a package if the package's
  weight and volume both fit within its remaining capacity (`CanCarry`) —
  the core constraint the whole dispatch/auto-dispatch flow is built around.

## Multithreading

The **auto-dispatch queue** (`DispatchQueue.cs`) is the background process:

- Unassigned orders are pushed onto a thread-safe `ConcurrentQueue<Order>`.
- `DispatchQueue.Start()` is called once, from `Program.cs`, right after the
  menu classes are created — it launches a `Task` that loops independently
  of the console menu for the entire lifetime of the app.
- Every polling cycle (default 3 seconds) it dequeues each order that was
  waiting at the start of that cycle, tries to match it to a vehicle with
  `CanCarry`, and either assigns it (printing an `[Auto-Dispatch]` message)
  or puts it back for the next cycle. Only the orders present *at the start*
  of a cycle are swept, so a re-queued order can never spin the loop.
- A `lock` around the console writes stops the background task's output
  from interleaving mid-line with whatever the user is typing at the menu —
  the safe-execution requirement.
- `DispatchQueue.Stop()` cancels the loop cleanly via a
  `CancellationTokenSource` when the app exits.

This means a user can keep navigating menus, adding vehicles or orders,
while previously-stuck orders are quietly being retried and assigned in the
background — no user action required to "kick" the queue.

## Events & Delegates

`Vehicle` (in `Vehicle.cs`) defines a custom delegate and two events:

```csharp
public delegate void VehicleStatusHandler(object sender, VehicleEventArgs e);

public event VehicleStatusHandler CapacityWarningRaised;
public event VehicleStatusHandler VehicleFull;
```

- **`CapacityWarningRaised`** fires from `TriggerWarning()` whenever a
  vehicle's load reaches 90% of its max weight.
- **`VehicleFull`** fires from `LoadPackage()` whenever a load reaches or
  exceeds max weight or max volume.

`VehicleRepository` subscribes every vehicle — starter fleet or user-added —
to both events as soon as it's created, so alerts print automatically
wherever a vehicle gets loaded, whether that's through the normal menu flow
or from inside the background dispatch queue. This is a straightforward
publisher/subscriber setup: `Vehicle` doesn't know or care who's listening,
it just raises the event; `VehicleRepository` (or, in principle, any other
part of the system) decides what to do about it.

## Known Limitations / Not Yet Implemented

- **Manage System** menu option is a stub — a natural place for a bonus
  feature such as save/load of system state.
- No persistence: all data (staff, vehicles, orders, customers) resets each
  run.
- No automated unit tests.
