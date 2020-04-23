/**************************************************************
 * Profiling (StdDeviation) pre 2. projekt IVS - Kalkulačka
 *
 * Názov tímu: Slovenska (j)elita
 *
 * Autori projektu:    Tomáš Zaťko (xzatko02)
 *            	       Martin Rakús (xrakus04)
 *           		   Patrik Jacola (xjacol00)
 *            		   Monika Kubincová (xkubin24)
 **************************************************************/

using System;
using System.IO;
using Math = Kalkulator.Calculator.Math.Math;
using System.Collections.Generic;


namespace Kalkulator
{
	/// <summary>
	/// Program pre výpočet výberovej smerodatnej odchylky z postupnosti čísel, ktoré program načíta zo STDIN
	/// </summary>
	internal static class StdDeviation
	{

		/// <summary>
		/// Načítanie čísel zo STDIN a výpis na STDOUT
		/// </summary>
		private static void Main()
		{
			List<double> nums;
			try
			{
				nums = ReadNumbers();
			}
			catch (InvalidDataException e)
			{
				Console.WriteLine(e.Message);
				return;
			}

			double result;
			try
			{
				result = CalcStdDeviation(nums);
			}
			catch (ArgumentException e)
			{
				Console.WriteLine(e.Message);
				return;
			}

			Console.WriteLine(@"Result: {0}", result);
		}

		/// <summary>
		/// Načítanie čísel zo STDIN
		/// </summary>
		/// <returns>Parsed numbers in list of double values.</returns>
		private static List<double> ReadNumbers()
		{
			List<double> nums = new List<double>();
			string line;

			while ((line = Console.ReadLine()) != null)
			{
				double number;
				if (!double.TryParse(line.Replace(".", ","), out number))
				{
					throw new InvalidDataException("Invalid input data (not a number).");
				}
				nums.Add(number);
			}

			return nums;
		}

		/// <summary>
		/// Vypočítanie výberovej smerodatnej odchýlky
		/// </summary>
		/// <param name="nums">Zadané čísla pre výpočet vyberovej smerodatnej odchylky</param>
		/// <returns>Smerodatná odchýlka zadaných čísel</returns>
		private static double CalcStdDeviation(List<double> nums)
		{
			int n = nums.Count;
			if (n < 2)          // ošetrenie, pokiaľ je čísel menej ako dve
			{
				throw new ArgumentException("Error - invalid data input, min. 2 numbers required");
			}
			Math math = new Math();
			double arithmAvg = 0.0;
			double deviation = 0.0;
			foreach (double num in nums)
			{
				arithmAvg = math.Add(arithmAvg, num);
				deviation = math.Add(deviation, math.Pow(num, 2.0));
			}

			// výpočet priemeru
			arithmAvg = math.Divide(arithmAvg, n);

			// vzorec pre výpočet výberovej smerodatnej odchylky
			return math.Root(math.Divide(math.Substract(deviation, math.Multiply(n, math.Pow(arithmAvg, 2))), math.Substract(n, 1)), 2);
		}
	}
}
