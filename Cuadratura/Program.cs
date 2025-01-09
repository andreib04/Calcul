using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuadratura
{
	internal class Program
	{
		public static decimal a, b, T, M, S;
		public static int n;
		public static decimal[] x;
		static void Main(string[] args)
		{
			a = 0;
			b = 1;
			n = 5;

			x = new decimal[1000];

			for (int i = 0; i < n; i++)
			{
				x[i] = a + ((i * (b-a)) / n);
			}

			T = 0;
			M = 0;
			S = 0;



			for(int i = 1; i < n; i++)
			{
				T += f(x[i]) + f(x[i - 1]);

				M += f((x[i - 1] + x[i]) / 2);
			}

			S = ((b - a) / (6 * n)) * (T + (4 * M));

			Console.WriteLine(S);

			Console.ReadKey();
		}

		public static decimal f(decimal x)
		{
			return 1M / (1 + x);
		}
	}
}
