using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace polinoame
{
	public partial class Form1 : Form
	{
		Graphics graphics;
		Bitmap bitmap;
		decimal x0, xn, y0, yn;

		int m, n;
		decimal[] x, y, u, p, q;
		decimal[,] Nf;
		decimal[][] T;
		decimal s1, s2, s3, s4, t1, t2, t3, a, b, c, d, d1, d2, d3;
		decimal h;

		private void button4_Click(object sender, EventArgs e)
		{
			n = 6;
			s1 = s2 = s3 = s4 = 0;
			t1 = t2 = t3 = 0;

			u = new decimal[10000];
			q = new decimal[10000];

			x = new decimal[] { -3, -2, -1, 0, 1, 2, 3 };
			y = new decimal[] { 6, 4, 1, 2, 3, 8, 11 };

			x0 = x.Min();
			xn = x.Max();
			y0 = y.Min();
			yn = y.Max();

			for (int i = 0; i <= n; i++)
			{
				s1 += x[i];
				s2 += x[i] * x[i];
				s3 += x[i] * x[i] * x[i];
				s4 += x[i] * x[i] * x[i] * x[i];

				t1 += y[i];
				t2 += x[i] * y[i];
				t3 += x[i] * x[i] * y[i];
			}

			d = (n + 1) * s2 * s4 + 2 * s1 * s2 * s3 - s2 * s2 * s2 - s1 * s1 * s4 - (n + 1) * s3 * s3;
			d1 = (n + 1) * s2 * t3 + s1 * s2 * t2 + s1 * s3 * t1 - s2 * s2 * t1 - s1 * s1 * t2 - (n + 1) * s3 * t2;
			d2 = (n + 1) * t2 * s4 + s4 + s2 * s3 * t1 + s1 * s2 * t3 - s2 * s2 * t2 - s1 * s4 * t1 - (n + 1) * s3 * t3;
			d3 = s2 * s4 * t1 + s1 * s3 * t3 + s2 * s3 * t2 - s2 * s2 * t3 - s1 * s4 * t2 - s3 * s3 * t1;

			a = d1 / d;
			b = d2 / d;
			c = d3 / d;

			textBox1.Text = a + " " + b + " " + c;

			h = (xn - x0) / 1000;

			for(int j = 0; j < 1000; j++)
			{
				u[j] = x0 + j * h;
				q[j] = a * u[j] * u[j] + b * u[j] + c;
			}
			bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

			DrawGraph(u, q);
			DrawGraph(x, y);
		}

		

		private void button3_Click(object sender, EventArgs e)
		{
			n = 5;
			s1 = 0;
			s2 = 0;
			t1 = 0;
			t2 = 0;
			
			u = new decimal[10000];
			q = new decimal[10000];

			x = new decimal[] {1, 3, 4, 6, 8, 9 };
			y = new decimal[] { 1, 2, 4, 4, 5, 3 };
			
			x0 = x[0];
			xn = x[n];
			y0 = y[0];
			yn = y.Max();

			for(int i = 0; i <= n; i++)
			{
				s1 += x[i];
				s2 += x[i] * x[i];
				t1 += y[i];
				t2 += x[i] * y[i];
			}

			d = (n + 1) * s2 - s1 * s1;
			d1 = (n + 1) * t2 - s1 * t1;
			d2 = s2 * t1 - t2 * s1;

			a = d1 / d;
			b = d2 / d;

			textBox1.Text = a + " " + b;

			h = (xn - x0) / 1000;

			
			for(int j = 0; j < 1000; j++)
			{
				u[j] = x0 + j * h;
				q[j] = a * u[j] + b;
			}
			bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

			DrawGraph(u, q);
			DrawGraph(x, y);
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			decimal a = 0;
			decimal b = (decimal)Math.PI;
			n = 7;
			p = new decimal[n];
			u = new decimal[1000];
			T = new decimal[n][];

			for(int i = 0; i < n; i++)
			{
				T[i] = new decimal[1000];
			}

			p[0] = 1;
			decimal h = (b - a) / 1000;
			int k;

			for (k = 1; k < n; k++)
			{
				p[k] = p[k - 1] * k;
			}

			for (int j = 0; j < 1000; j++)
			{
				u[j] = a + j * h;
				T[0][j] = f(0);

				for (k = 1; k < n; k++)
				{
	
					T[k][j] = T[k - 1][j] + ((1 / p[k]) * (decimal)Math.Pow((double)(u[j] - a), k)) * f(k);
				}
			}

			x0 = u.Min();
			xn = u.Max();
			y0 = T[n - 2].Min();
			yn = T[n - 2].Max();


			DrawGraph(u, T[n - 2]);
		}

		public decimal f(decimal x)
		{
			return (decimal)Math.Sin((double)x);
		}

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			m = 5;
			x = new decimal[] { 1, 1.1m, 1.3m, 1.5m, 1.6m };
			y = new decimal[] { 1, 1.032m, 1.091m, 1.145m, 1.17m };
			x0 = x[0];
			xn = x[m - 1];
			y0= y[0];
			yn = y[m - 1];

			decimal[,] d = new decimal[m, m];

			//Pas 1: calculam diferentele divizate
			for(int i = 0; i < m; i++)
			{
				d[0, i] = y[i];
			}

			for(int j = 1; j < m; j++)
			{
				for(int i = 0; i < m - j; i++)
				{
					d[j, i] = (d[j-1, i+1] - d[j-1, i]) / (x[i+1] - x[i]);
				}
			}

			//Pas2: calculam Nf
			decimal h = (xn - x0) / 1000;
		    u = new decimal[1000];
			Nf = new decimal[m, 1000];
			decimal[] p = new decimal[m];

			for(int j = 0; j < 1000; j++)
			{
				u[j] = x[0] + j * h;
				Nf[0, j] = y[0];
				p[0] = 1;

				for(int i = 1; i < m; i++)
				{
					p[i] = p[i - 1] * (u[j] - x[i - 1]);
					Nf[i, j] = Nf[i - 1, j] + p[i] * d[i, 0];
				}
			}
			decimal[] f = new decimal[1000];

			for(int i = 0; i < 1000; i++)
			{
				f[i] = Nf[m - 1, i];
			}

			//Pas 3: desenare
			//DrawGraph(u, f);      

		}

		public void DrawGraph(decimal[] x, decimal[] y)
		{
			graphics = Graphics.FromImage(bitmap);

			for (int i = 0; i < x.Length; i++)
			{
				PointF location = MapValuesToPointF(x[i], y[i]);
				graphics.DrawEllipse(new Pen(Color.Red, 5), location.X - 5, location.Y - 5, 11, 11);
			}

			pictureBox1.Image = bitmap;
		}

		public PointF MapValuesToPointF(decimal x, decimal y)
		{
			decimal scaleX = xn - x0;
			decimal scaleY = yn - y0;
			float X = (float)((x - x0) * (pictureBox1.Width - 5) / scaleX);
			float Y = pictureBox1.Height - (float)((y - y0) * (pictureBox1.Height - 5) / scaleY);

			return new PointF(X, Y);
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
