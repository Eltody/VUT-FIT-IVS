/**************************************************************
 * Matematická knižnica pre 2. projekt IVS - Kalkulačka
 *
 * Názov tímu: Slovenska (j)elita
 *
 * Autori projektu:    Tomáš Zaťko (xzatko02)
 *            	       Martin Rakús (xrakus04)
 *           		   Patrik Jacola (xjacol00)
 *            		   Monika Kubincová (xkubin24)
 *
 * Dátum: 	  2.4. 2020
 *
 * Verzia: 	  1.0
 **************************************************************/

using System;

namespace Kalkulator.Calculator.Math
{
	/// <summary>
	/// Prehlad a popis matematických funkcií použitých pri implementácií
	/// </summary>
	public interface DMath
	{
		/// <summary>
		///     Sums two numbers.
		/// </summary>
		/// <param name="num1">Summand1.</param>
		/// <param name="num2">Summand2.</param>
		/// <returns>The result of the addition.</returns>
		double Add(double a, double b);

		/// <summary>
		///     Substracts two numbers.
		/// </summary>
		/// <param name="minuend">Minuend.</param>
		/// <param name="subtrahend">Subtrahend.</param>
		/// <returns>The result of the substraction.</returns>
		double Substract(double a, double b);

		/// <summary>
		///     Divides two numbers.
		/// </summary>
		/// <param name="divident">Divident.</param>
		/// <param name="divisor">Divisor.</param>
		/// <returns>The result of the division.</returns>
		/// <exception cref="DivideByZeroException"></exception>
		double Divide(double a, double b);

		/// <summary>
		///     Multiplies two numbers.
		/// </summary>
		/// <param name="num1">Factor1.</param>
		/// <param name="num2">Factor2.</param>
		/// <returns>The summary of the Multiplication.</returns>
		double Multiply(double a, double b);

		/// <summary>
		///     Computes a factorial from a number.
		/// </summary>
		/// <param name="num">Factoriated number.</param>
		/// <returns>Factorial from the number.</returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		ulong Fact(double a);

		/// <summary>
		///     Exponentiation with general exponent.
		/// </summary>
		/// <param name="basis">Base.</param>
		/// <param name="exponent">Exponent.</param>
		/// <returns>Returns a specified number raised to the specified power.</returns>
		/// <exception cref="NotFiniteNumberException"></exception>
		double Pow(double a, double b);

		/// <summary>
		///     Root with general degree.
		/// </summary>
		/// <param name="radicand">Radicand.</param>
		/// <param name="degree">Degree.</param>
		/// <returns>Returns the n-th root of a specified number.</returns>
		/// <exception cref="DivideByZeroException"></exception>
		double Root(double a, double b);

		/// <summary>
		///     Logarithm with general base.
		/// </summary>
		/// <param name="basis">Base.</param>
		/// <param name="antilogarithm">Antilogarithm.</param>
		/// <returns>Returns the logarithm of a specified number in a specified base.</returns>
		/// <exception cref="NotFiniteNumberException"></exception>
		double Log(double a, double b);
	}
}
