/**************************************************************
* Názov tímu: Slovenská (j)elita
*
* Autori projektu:      Tomáš Zaťko(xzatko02)
*                       Martin Rakús(xrakus04)
*                       Patrik Jacola(xjacol00)
*                       Monika Kubincová(xkubin24)
**************************************************************/

using System;
using System.Windows.Controls;

namespace Kalkulator.Calculator
{
	/// <summary>
	/// Procesor pre mat. logiku
	/// </summary>
	public class MathProcessor
	{
		/// Operátory
		private enum Operator
		{
			None,
			Add,
			Substract,
			Multiply,
			Divide,
			Fact,
			Pow,
			Root,
			Log
		}

		/// Zvolený operátor
		private static Operator selectedOperator = Operator.None;

		/// Matematická knižnica
		private readonly Math.Math math;

		/// Output procesor
		private readonly OutputProcessor outputProcessor;
		
		/// Očakáva ďalšie číslo
		public static bool WaitingForNumber;
		
		/// Výsledok výpočtu
		private static double result;

		/// <summary>
		/// Math procesor
		/// </summary>
		/// <param name="outputProcessor">Output result procesor</param>
		public MathProcessor(OutputProcessor outputProcessor)
		{
			this.outputProcessor = outputProcessor;
			this.math = new Math.Math();
		}

		/// <summary>
		/// Operácia sčítanie
		/// </summary>
		/// <param name="ans">Answer - číslo typu double</param>
		public void ProcessAdd(double ans)
		{
			this.outputProcessor.PrintLog("+");
			this.CalculateResult(ans);
			selectedOperator = Operator.Add;
		}

		/// <summary>
		/// Operácia odčítanie
		/// </summary>
		/// <param name="ans">Answer - číslo typu double</param>
		public void ProcessSubstract(double ans)
		{
			this.outputProcessor.PrintLog("-");
			this.CalculateResult(ans);
			selectedOperator = Operator.Substract;
		}

		/// <summary>
		/// Operácia násobenie
		/// </summary>
		/// <param name="ans">Answer - číslo typu double</param>
		public void ProcessMultiply(double ans)
		{
			this.outputProcessor.PrintLog("*");
			this.CalculateResult(ans);
			selectedOperator = Operator.Multiply;
		}

		/// <summary>
		/// Operácia delenie
		/// </summary>
		/// <param name="ans">Answer - číslo typu double</param>
		public void ProcessDivide(double ans)
		{
			this.outputProcessor.PrintLog("÷");
			this.CalculateResult(ans);
			selectedOperator = Operator.Divide;
		}

		/// <summary>
		/// Operácia faktoriál
		/// </summary>
		/// <param name="ans">Answer - číslo typu double</param>
		public void ProcessFact(double ans)
		{
			this.outputProcessor.PrintLog("!");
			this.outputProcessor.IsTextDisplay = true;
			this.CalculateResult(ans, false);
			selectedOperator = Operator.Fact;
		}

		/// <summary>
		/// Operácia umocnenie
		/// </summary>
		/// <param name="ans">Answer - číslo typu double</param>
		public void ProcessPow(double ans)
		{
			this.outputProcessor.PrintLog("^");
			this.CalculateResult(ans);
			selectedOperator = Operator.Pow;
		}

		/// <summary>
		/// Operácia odmocnenie
		/// </summary>
		/// <param name="ans">Answer - číslo typu double</param>
		public void ProcessRoot(double ans)
		{
			this.outputProcessor.PrintLog("√");
			this.CalculateResult(ans);
			selectedOperator = Operator.Root;
		}

		/// <summary>
		/// Operácia logaritmus
		/// </summary>
		/// <param name="ans">Answer - číslo typu double</param>
		public void ProcessLog(double ans)
		{
			this.outputProcessor.PrintLog("log");
			this.CalculateResult(ans);
			selectedOperator = Operator.Log;
		}
		
		/// <summary>
		/// Vyčisti výsledok
		/// </summary>
		public static void ClearResult()
		{
			result = 0.0;
			selectedOperator = Operator.None;
			WaitingForNumber = false;
		}

		/// <summary>
		/// Výpočet výsledku operácie
		/// </summary>
		/// <param name="ans">Answer - číslo typu double</param>
		/// <param name="waitingForNumber">Očakáva sa ďalšie číslo</param>
		/// <param name="clear">Po výpočte vyčisti displejové okná</param>
		public void CalculateResult(double ans, bool waitingForNumber = true, bool clear = false)
		{
			if (WaitingForNumber)	// pokiaľ sa čaká na výsledok - nepočíta sa výsledok (result)
			{
				return;
			}
			try
			{
				switch (selectedOperator)
				{
					case Operator.None:
						result = ans;
						break;

					case Operator.Add:
						result = this.math.Add(result, ans);
						break;

					case Operator.Substract:
						result = this.math.Substract(result, ans);
						break;

					case Operator.Multiply:
						result = this.math.Multiply(result, ans);
						break;

					case Operator.Divide:
						result = this.math.Divide(result, ans);
						break;

					case Operator.Fact:
						result = this.math.Fact(ans);
						break;

					case Operator.Pow:
						result = this.math.Pow(result, ans);
						break;

					case Operator.Root:
						result = this.math.Root(ans, result);
						break;

					case Operator.Log:
						result = this.math.Log(result, ans);
						break;
				}
			}
			catch (Exception)
			{
				this.outputProcessor.ClearText();
				this.outputProcessor.ClearLog();
				ClearResult();
				this.outputProcessor.PrintError();

				return;
			}
			this.outputProcessor.PrintText(result);
			WaitingForNumber = waitingForNumber;
			if (clear)
			{
				this.outputProcessor.ClearLog();
				ClearResult();
			}
		}
	}
}
