/********************************************************************************
 * Implementácia testov pre matematickú knižnicu pre 2. projekt IVS - Kalkulačka
 *
 * Názov tímu: Slovenska (j)elita
 *
 * Autori projektu:    Tomáš Zaťko (xzatko02)
 *          		   Martin Rakús (xrakus04)
 *        	 	       Patrik Jacola (xjacol00)
 *          		   Monika Kubincová (xkubin24)
 *
 * Dátum: 	  7.4. 2020
 *
 * Verzia: 	  1.0
 ********************************************************************************/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Math = Kalkulator.Calculator.Math.Math;
using Kalkulator.Calculator.Math;

namespace Kalkulator.Tests
{
	/// <summary>
	/// Testy pre matematickú knižnicu
	/// </summary>
	[TestClass]
	public class MathTests
	{
		/// Kalkulator.Calculator.Math.Math object.
		private readonly DMath math;
		
		/// Hodnota presnosti pre float aritmetiku
		private const double Accuracy = 1e-6;

		/// <summary>
		/// Construct testov nad matematickou knižnicou
		/// </summary>
		public MathTests()
		{
			this.math = new Math();
		}

		/// <summary>
		/// Testy pre operáciu Add - sčítanie
		/// </summary>
								[TestMethod]
		public void AddTest()
		{
			Assert.AreNotEqual(5000, this.math.Add(-1500, -3500));		// FALSE tests
			Assert.AreNotEqual(-28, this.math.Add(13, 15));
			Assert.AreNotEqual(0, this.math.Add(3.5, 1.5), Accuracy);
			Assert.AreNotEqual(-25.5, this.math.Add(-25.51, 0), Accuracy);
			Assert.AreNotEqual(42.1, this.math.Add(0, 42.123), Accuracy);
			Assert.AreNotEqual(0.1, this.math.Add(0, 0), Accuracy);
			
			Assert.AreEqual(0, this.math.Add(0, 0));					// TRUE tests
			Assert.AreEqual(28, this.math.Add(13, 15));
			Assert.AreEqual(7, this.math.Add(8, -1));
			Assert.AreEqual(-6, this.math.Add(-8, 2));
			Assert.AreEqual(5, this.math.Add(3.5, 1.5), Accuracy);
			Assert.AreEqual(1111110, this.math.Add(123123, 987987));
			Assert.AreEqual(-5000, this.math.Add(-1500, -3500));
			Assert.AreEqual(50, this.math.Add(-100, 150));
			Assert.AreEqual(42.123, this.math.Add(0, 42.123, Accuracy));
		}

		/// <summary>
		/// Testy pre operáciu Substract - odčítanie
		/// </summary>
								[TestMethod]
		public void SubstractTest()
		{
			Assert.AreNotEqual(-5000, this.math.Substract(-1500, -3500));		// FALSE tests
			Assert.AreNotEqual(5, this.math.Substract(13, 18));
			Assert.AreNotEqual(2.1, this.math.Substract(3.5, 1.5), Accuracy);
			Assert.AreNotEqual(-43, this.math.Substract(42.123, 1), Accuracy);
			Assert.AreNotEqual(42, this.math.Substract(42.123, 0), Accuracy);
			Assert.AreNotEqual(1, this.math.Substract(-1, -5.9), Accuracy);
			
			Assert.AreEqual(-1, this.math.Substract(0, 1));				// TRUE tests
			Assert.AreEqual(0, this.math.Substract(-5, -5));
			Assert.AreEqual(190, this.math.Substract(84, -106));
			Assert.AreEqual(-2, this.math.Substract(13, 15));
			Assert.AreEqual(-384, this.math.Substract(-128, 256));
			Assert.AreEqual(-864198, this.math.Substract(123456, 987654));
			Assert.AreEqual(2, this.math.Substract(3.5, 1.5), Accuracy);
			Assert.AreEqual(42.123, this.math.Substract(42.123, 0), Accuracy);
			Assert.AreEqual(0, this.math.Substract(1, 1));
		}
		
		/// <summary>
		/// Testy pre operáciu Multiply - násobenie
		/// </summary>
								[TestMethod]
		public void MultiplyTest()
		{
			Assert.AreNotEqual(1, this.math.Multiply(-0, 5));		// FALSE tests
			Assert.AreNotEqual(195, this.math.Multiply(13, -15));
			Assert.AreNotEqual(0, this.math.Multiply(1, -1));
			Assert.AreNotEqual(5.5, this.math.Multiply(1.5, 3.5), Accuracy);
			Assert.AreNotEqual(42.123, this.math.Multiply(42.123, 2), Accuracy);
			Assert.AreNotEqual(-80, this.math.Multiply(10, 8));
			
			Assert.AreEqual(0, this.math.Multiply(0, 0));			// TRUE tests
			Assert.AreEqual(0, this.math.Multiply(0, 1));
			Assert.AreEqual(0, this.math.Multiply(1, 0));
			Assert.AreEqual(195, this.math.Multiply(13, 15));
			Assert.AreEqual(-320, this.math.Multiply(10, -32));
			Assert.AreEqual(-231.6765, this.math.Multiply(-42.123, 5.5), Accuracy);
			Assert.AreEqual(231.6765, this.math.Multiply(-42.123, -5.5), Accuracy);
			Assert.AreEqual(117.3, this.math.Multiply(10.2, 11.5), Accuracy);
			Assert.AreEqual(5.25, this.math.Multiply(3.5, 1.5), Accuracy);
		}

		/// <summary>
		/// Testy pre operáciu Divide - delenie
		/// </summary>
								[TestMethod]
		public void DivideTest()
		{
			Assert.AreNotEqual(-1, this.math.Divide(42.123, 42.123), Accuracy);		// FALSE tests
			Assert.AreNotEqual(1.75, this.math.Divide(-3.5, 2), Accuracy);
			Assert.AreNotEqual(5, this.math.Divide(-2, 0.4), Accuracy);
			Assert.AreNotEqual(25, this.math.Divide(0, -25));
			Assert.AreNotEqual(-50, this.math.Divide(0, 50));
			Assert.AreNotEqual(-2, this.math.Divide(-1, 2));
			
			Assert.AreEqual(1, this.math.Divide(1, 1));			// TRUE tests
			Assert.AreEqual(0, this.math.Divide(0, 1));
			Assert.AreEqual(-5, this.math.Divide(-50, 10));
			Assert.AreEqual(-5, this.math.Divide(50, -10));
			Assert.AreEqual(5, this.math.Divide(-50, -10));	
			Assert.AreEqual(5, this.math.Divide(50, 10));			
			Assert.AreEqual(1, this.math.Divide(42.123, 42.123), Accuracy);
			Assert.AreEqual(3, this.math.Divide(369369, 123123));
			Assert.AreEqual(-5, this.math.Divide(-2, 0.4), Accuracy);
			Assert.AreEqual(3.5, this.math.Divide(3.5, 1), Accuracy);
			Assert.AreEqual(-8.4246, this.math.Divide(42.123, -5), Accuracy);
			
			try								// ošetrenie delenia nulou!
			{
				this.math.Divide(-42, 0);
			}
			catch (DivideByZeroException)
			{
			}
			
			try
			{
				this.math.Divide(1, 0);
			}
			catch (DivideByZeroException)
			{
			}
		}
		
		/// <summary>
		/// Testy pre operáciu Log - logaritmus
		/// </summary>
								[TestMethod]
		public void LogTest()
		{
			Assert.AreNotEqual(5, this.math.Log(5.2, 3), Accuracy);		// FALSE tests
			Assert.AreNotEqual(10, this.math.Log(9, 4.5), Accuracy);
			
			Assert.AreEqual(1, this.math.Log(9.99, 9.99), Accuracy);			// TRUE tests
			Assert.AreEqual(1, this.math.Log(10, 10));
			Assert.AreEqual(2, this.math.Log(10, 100));
			Assert.AreEqual(3, this.math.Log(10, 1000));
			Assert.AreEqual(4, this.math.Log(3, 81));
			
			try								// ošetrenia chybových stavov - nesprávne zadaných čísel do danej funkcie
			{
				this.math.Log(-42, 5);
			}
			catch (NotFiniteNumberException)
			{
			}
			
			try
			{
				this.math.Log(42, -5);
			}
			catch (NotFiniteNumberException)
			{
			}
			
			try
			{
				this.math.Log(0, 6);
			}
			catch (NotFiniteNumberException)
			{
			}
			
			try
			{
				this.math.Log(100, 0);
			}
			catch (NotFiniteNumberException)
			{
			}
			
			try
			{
				this.math.Log(1, 99);
			}
			catch (NotFiniteNumberException)
			{
			}
		}

		/// <summary>
		/// Testy pre operáciu Factorial - Faktoriál
		/// </summary>
								[TestMethod]
		public void FactTest()
		{
			Assert.AreNotEqual((ulong) 5, this.math.Fact(3));			// FALSE tests
			Assert.AreNotEqual((ulong) 25, this.math.Fact(4));
			Assert.AreNotEqual((ulong) 2, this.math.Fact(0));
			
																		// TRUE tests
			Assert.AreEqual((ulong) 6.2270208e9, this.math.Fact(13), Accuracy);		// funguje???
			Assert.AreEqual((ulong) 1, this.math.Fact(0));				
			Assert.AreEqual((ulong) 1, this.math.Fact(1));
			Assert.AreEqual((ulong) 2, this.math.Fact(2));
			Assert.AreEqual((ulong) 6, this.math.Fact(3));
			
			// ošetrenie chybových stavov - nesprávne zadaných hodnôt do danej funkcie
			try
			{
				this.math.Fact(-25.5);
			}
			catch (ArgumentOutOfRangeException)
			{
			}
			
			try
			{
				this.math.Fact(-21);
			}
			catch (ArgumentOutOfRangeException)
			{
			}
		}

		/// <summary>
		/// Testy pre operáciu Pow - umocnenie
		/// </summary>
								[TestMethod]
		public void PowTest()
		{
			Assert.AreNotEqual(2, this.math.Pow(1, 1));			// FALSE tests
			Assert.AreNotEqual(2, this.math.Pow(55.5, 3), Accuracy);

			Assert.AreEqual(1, this.math.Pow(50, 0));			// TRUE tests		
			Assert.AreEqual(0, this.math.Pow(0, 9));
			Assert.AreEqual(1, this.math.Pow(1, 42.123), Accuracy);
			Assert.AreEqual(1, this.math.Pow(1, 5));
			Assert.AreEqual(-1, this.math.Pow(-1, 3));
			Assert.AreEqual(1, this.math.Pow(-1, 2));

			// ošetrenie chybových stavov - nesprávne zadaných hodnôt do danej funkcie
			try
			{
				this.math.Pow(0, -1);
			}
			catch (NotFiniteNumberException)
			{
			}
			
			try
			{
				this.math.Pow(-1, 2.5);
			}
			catch (NotFiniteNumberException)
			{
			}
			
			try
			{
				this.math.Pow(-1.5, -2.5);
			}
			catch (NotFiniteNumberException)
			{
			}
		}

		/// <summary>
		/// Testy pre operáciu Root - odmocnenie
		/// </summary>
								[TestMethod]
		public void RootTest()
		{
			Assert.AreNotEqual(1, this.math.Root(0, 82));				// FALSE tests
			Assert.AreNotEqual(1, this.math.Root(1.5, 3.5), Accuracy);
								
			Assert.AreEqual(2, this.math.Root(4, 2));					// TRUE tests
			Assert.AreEqual(2, this.math.Root(8, 3));		
			Assert.AreEqual(0.5, this.math.Root(4, -2), Accuracy);
			
			// ošetrenie chybových stavov - mocnenie na zápornú hodnotu
			try
			{
				this.math.Root(-1.5, -3.5);
			}
			catch (NotFiniteNumberException)
			{
			}			
			
			try
			{
				this.math.Root(-1, 25);			// záporná hodnota pod odmocninou
			}
			catch (NotFiniteNumberException)
			{
			}
			
			try
			{
				this.math.Root(0, -55);		// mocnenie na zápornú hodnotu
			}
			catch (NotFiniteNumberException)
			{
			}

			// ošetrenie chybových stavov - nultá odmocnina
			try
			{
				this.math.Root(42.123, 0);
			}
			catch (DivideByZeroException)
			{
			}

			try
			{
				this.math.Root(69, 0);
			}
			catch (DivideByZeroException)
			{
			}
		}
	}
}
