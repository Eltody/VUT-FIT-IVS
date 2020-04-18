/**************************************************************
 * Matematická knižnica pre 2. projekt IVS - Kalkulačka
 *
 * Názov tímu: Slovenska (j)elita
 *
 * Autori projektu:    Tomáš Zaťko (xzatko02)
 *            	       Martin Rakús (xrakus04)
 *           		   Patrik Jacola (xjacol00)
 *            		   Monika Kubincová (xkubin24)
 **************************************************************/

using System;

namespace Kalkulator.Calculator.Math
{
	/// <summary>
	/// Implementácia matematickej knižnice
	/// </summary>
	public class Math : DMath
	{
		public double Add(double a, double b)
		{
			return a + b;
		}

		public double Substract(double a, double b)
		{
			return a - b;
		}

		public double Multiply(double a, double b)
		{
			return a * b;
		}

		public double Divide(double a, double b)
		{
			if (b == 0.0)
			{
				throw new DivideByZeroException();
			}
			return a / b;
		}

		public double Log(double a, double b)
		{
			double result = System.Math.Log(b, a);
			if (double.IsInfinity(result) || double.IsNaN(result))
			{
				throw new NotFiniteNumberException();
			}
			return result;
		}
		
		public ulong Fact(double a)
		{
			if (a < 0.0 || a % 1 != 0.0)
			{
				throw new ArgumentOutOfRangeException();
			}
			ulong result = (ulong) a;
			ulong lowerNum = result;
			if (lowerNum == 0)
			{
				return 1;
			}
			for (ulong i = 1; i < lowerNum; i++)
			{
				result = result * (lowerNum - i);
			}
			return result;
		}		

		public double Pow(double a, double b)
		{
			double result = System.Math.Pow(a, b);

			if (double.IsInfinity(result) || double.IsNaN(result))
			{
				throw new NotFiniteNumberException();
			}
			return result;
		}

		public double Root(double a, double b)
		{
			if (b == 0.0)
			{
				throw new DivideByZeroException();
			}
			double result = this.Pow(a, 1.0 / b);
			return result;
		}
	}
}
