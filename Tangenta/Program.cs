using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Tangenta
{
	internal class Program
	{
		static int n, m;
		static decimal a, b, c, dda, epsilon, xn, xn_1;
	
		static void Main(string[] args)
		{
			metodaTangentei();

			Console.ReadKey();
		}

		static void metodaTangentei()
		{
			n = 1;
			a = 1;
			b =	2;
			dda = 2;
			epsilon = 1e-28m; //1e-8m, 1e-12m
			m = 2;
			c = 2;


			if(fRad(a) * dda > 0)
			{
				xn_1 = a;
			}
			else
			{
				xn_1 = b;
			}

			xn = xn_1 - (fRad(xn_1) / dfRad(xn_1));
			do
			{
				n++;

				xn_1 = xn;
				xn = xn_1 - (fRad(xn_1) / dfRad(xn_1));
			} while (Math.Abs(xn - xn_1) >= epsilon);

			Console.WriteLine(n + " " + xn);
		}

		public static decimal f(decimal x)
		{
			return x * x * x * x * x - 5 * x + 1;
		}

		public static decimal df(decimal x)
		{
			return 5 * x * x * x * x - 5;
		}

		public static decimal fRad(decimal x)
		{
			return (decimal)Math.Pow((double)x, m) - c;
		}

		public static decimal dfRad(decimal x)
		{
			//decimal toR = m;

			//for(int i = 0; i < m - 1; i++)
			//{
			//	toR *= x;
			//}

			//return toR;

			return m * (decimal)Math.Pow((double)x, m - 1);
		}
	}
}
