using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisteme
{
	internal class Program
	{
		static int n;
		static decimal[,] a;
		static decimal[] b;
		static decimal[] x;
		static decimal[] xNew;
		static decimal epsilon;

		static void Main(string[] args)
		{
			MetodaIacobi();
		}

		static void MetodaIacobi()
		{
			n = 3;
			epsilon = 0.001m;
			a = new decimal[,]
			{
				{ 5, 1, 1 },
				{ 1, 6, 4 },
				{ 1, 1, 10 }
			};

			b = new decimal[] { 10, 4, 7 };
			x = new decimal[n];
			xNew = new decimal[n];

			decimal[] u = new decimal[n];
			decimal[] sum = new decimal[n];

			bool conditie = false;

			for(int i = 0; i < n; i++)
			{
				decimal u_ = 0;
				for(int j = 0; j < n; j++)
				{
					//if(j != i)
					//{
						
					//}
					u[i] += Math.Abs(a[i, j]);
					if (u[i] <= Math.Abs(a[i,i]))
					{
						Console.WriteLine("Nu se poate aplica Iacobi");
					}
				}
			}

			for(int i = 0; i < n; i++)
			{
				x[i] = b[i] / a[i, i];
			}

			int k = 0; 
			decimal[] x_ = new decimal[n];
			do
			{
				k++;

				for (int i = 0; i < n; i++)
				{
					sum[i] = 0;
					for(int j = 0; j < n; j++)
					{
						if(i != j)
						{
							sum[i] = sum[i] + (a[i, j] * x[j]);
						}
					}

					xNew[i] = (b[i] - sum[i]) / a[i, i];

					if (Math.Abs(xNew[i] - x[i]) > epsilon)
					{
						conditie = true;
					}
				}
				

			} while (conditie);

			for(int i = 0; i < n; i++)
			{
				Console.WriteLine(i.ToString(), xNew[i]);
			}
		}
	}
}
