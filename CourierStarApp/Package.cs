using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierStarApp
{
	public class Package
	{
		public double weight { get; set; }
		public double length { get; set; }
		public double width { get; set; }
		public double height { get; set; }
		internal int packageId { get; private set; }

		public double volume => length * width * height;
		public Package(int PackageID, double Weight, double Length, double Width, double Height)
		{
			weight = Weight;
			length = Length;
			width = Width;
			height = Height;
			packageId = PackageID;


        }

	}
}