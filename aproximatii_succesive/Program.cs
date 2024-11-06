using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aproximatii_succesive
{
	internal class Program
	{
		public static decimal n;
		public static decimal eps;
		public static decimal xn, xn_1;
		public static decimal a, b;

		static void Main(string[] args)
		{
			aproximare();

			Console.ReadKey();
		}

		public static void aproximare()
		{
			a = 1;
			b = 2;
			eps = 1e20m;
			n = 1;

			xn_1 = a;

			xn = fi(xn_1);

			do
			{
				n++;

				xn_1 = xn;
				xn = fi(xn_1);
			} while (Math.Abs(xn - xn_1) >= eps);

			Console.WriteLine(n + " " + xn_1);
		}

		public static decimal fi(decimal x)
		{
			return (decimal)Math.Pow((double)x + 1, 0.25);
		}
	}
}
