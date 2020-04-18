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
	/// Prehlad a popis matematických funkcií použitých pri implementácií
	/// </summary>
	public interface DMath
	{
		/// <summary>
		/// Sčíta dve čísla
		/// </summary>
		/// <param name="a">Sčítanec</param>
		/// <param name="b">Sčítanec</param>
		/// <returns>Výsledok sčítania</returns>
		double Add(double a, double b);

		/// <summary>
		/// Odčíta dve čísla
		/// </summary>
		/// <param name="a">Menšenec</param>
		/// <param name="b">Menšiteľ</param>
		/// <returns>Výsledok odčítania</returns>
		double Substract(double a, double b);
		
		/// <summary>
		/// Vynásobi dve čísla
		/// </summary>
		/// <param name="num1">Činiteľ</param>
		/// <param name="num2">Činiteľ</param>
		/// <returns>Výsledok násobenia</returns>
		double Multiply(double a, double b);

		/// <summary>
		/// Vydelí dve čísla
		/// </summary>
		/// <param name="a">Delenec</param>
		/// <param name="b">Deliteľ</param>
		/// <returns>Výsledok delenia</returns>
		double Divide(double a, double b);
		
		/// <summary>
		/// Vypočita logaritmus čísla o zadanom základe
		/// </summary>
		/// <param name="a">Základ</param>
		/// <param name="b">Číslo na zlogaritmovanie</param>
		/// <returns>Výsledok po zlogaritmovaní</returns>
		double Log(double a, double b);

		/// <summary>
		/// Vypočíta faktoriál čísla
		/// </summary>
		/// <param name="a">Faktorizované číslo</param>
		/// <returns>Faktoriál čísla</returns>
		ulong Fact(double a);

		/// <summary>
		/// Umocní číslo na zadaný exponent
		/// </summary>
		/// <param name="a">Mocnenec</param>
		/// <param name="b">Exponent</param>
		/// <returns>Výsledok do umocnení</returns>
		double Pow(double a, double b);

		/// <summary>
		/// Vypočíta zadanú odmocninu čísla
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b">Degree.</param>
		/// <returns>Výsledok po odmocnení</returns>
		double Root(double a, double b);
	}
}
