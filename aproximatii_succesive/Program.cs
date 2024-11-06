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
		public static decimal xn, xn_1, yn, yn_1;
		public static decimal a, b;

		static void Main(string[] args)
		{
			aproximareSistemeNeliniare();

			Console.ReadKey();
		}

		//public static void aproximare()
		//{
		//	a = 1;
		//	b = 2;
		//	eps = 1e20m;
		//	n = 1;

		//	xn_1 = a;

		//	xn = fi(xn_1);

		//	do
		//	{
		//		n++;

		//		xn_1 = xn;
		//		xn = fi(xn_1);
		//	} while (Math.Abs(xn - xn_1) >= eps);

		//	Console.WriteLine(n + " " + xn_1);
		//}

		public static void aproximareSistemeNeliniare()
		{
			eps = 1e20m;
			n = 1;

			xn_1 = 3.5m;
			yn_1 = 2.2m;

			yn = G(xn_1, yn_1);
			xn = F(xn_1, yn_1);

			do
			{
				n++;

				yn_1 = yn;
				xn_1 = xn;
				yn = G(xn_1, yn_1);
				xn = F(xn_1, yn_1);
			} while (Math.Abs(xn - xn_1) >= eps || Math.Abs(yn - yn_1) >= eps);

			Console.WriteLine(xn + " " + yn + " " + n);
		}

		public static decimal F(decimal x, decimal y)
		{
			return (decimal)Math.Sqrt((double)(x * (y+5) - 1)/2);
		}

		public static decimal G(decimal x, decimal y)
		{
			return (decimal)Math.Sqrt((double)(x + 3 * (decimal)Math.Log10((double)x)));
		}

		public static decimal fi(decimal x)
		{
			return (decimal)Math.Pow((double)x + 1, 0.25);
		}
	}
}
