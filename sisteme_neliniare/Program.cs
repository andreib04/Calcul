using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sisteme_neliniare
{
	//METODE ITERATIVE 
	internal class Program
	{
		//a,b start / end interval
		//dda, ddb - derivata dubla a,b
		static decimal a, b, epsilon, dda, xn, xn_1;
		static int n;
		static void Main(string[] args)
		{
			Coarda();

			Console.ReadKey();
		}

		public static void Coarda()
		{
			n = 0;
			a = 0;
			b = 1;
			dda = 0;
			epsilon = 1e-4m;

			decimal aux;

			if(f(a) * dda < 0)
			{
				xn_1 = a;
				aux = b;
			}
			else
			{
				xn_1 = b;
				aux = a;
			}


			xn = xn_1 - (f(xn_1) / (f(aux) - f(xn_1))) * (aux - xn_1);

			do
			{
				n++;
				xn_1 = xn;
				xn = xn_1 - (f(xn_1) / (f(aux) - f(xn_1))) * (aux - xn_1);
				
				
			} while (Math.Abs(xn - xn_1) >= epsilon);

			Console.WriteLine($"{n} {xn}");


		}

		static decimal f(decimal x)
		{
			return x * x * x - 3 * x + 1;
		}
	}

}
