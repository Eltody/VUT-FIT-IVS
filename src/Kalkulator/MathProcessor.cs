/**************************************************************
* Názov tímu: Slovenska(j)elita
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
	///     Math operations processor.
	/// </summary>
	public class MathProcessor
	{
		/// Math operators.
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

		/// Result of calculation.
		private static double result;

		/// Selected math operator.
		private static Operator selectedOperator = Operator.None;

		/// Waiting for next number flag (if true, then skip calculation).
		public static bool WaitingForNumber;

		/// Disassembler marh library.
		private readonly Math.Math math;

		/// Output result processor.
		private readonly OutputProcessor outputProcessor;

		/// <summary>
		///     MathProcessor construct.
		/// </summary>
		/// <param name="outputProcessor">Output result processor.</param>
		public MathProcessor(OutputProcessor outputProcessor)
		{
			this.outputProcessor = outputProcessor;
			this.math = new Math.Math();
		}

		/// <summary>
		///     Clear result.
		/// </summary>
		public static void ClearResult()
		{
			result = 0.0;
			selectedOperator = Operator.None;
			WaitingForNumber = false;
		}

		/// <summary>
		///     Process Add operation.
		/// </summary>
		/// <param name="ans">Answer in double.</param>
		public void ProcessAdd(double ans)
		{
			this.outputProcessor.PrintLog("+");
			this.CalculateResult(ans);
			selectedOperator = Operator.Add;
		}

		/// <summary>
		///     Process Substract operation.
		/// </summary>
		/// <param name="ans">Answer in double.</param>
		public void ProcessSubstract(double ans)
		{
			this.outputProcessor.PrintLog("-");
			this.CalculateResult(ans);
			selectedOperator = Operator.Substract;
		}

		/// <summary>
		///     Process Multiply operation.
		/// </summary>
		/// <param name="ans">Answer in double.</param>
		public void ProcessMultiply(double ans)
		{
			this.outputProcessor.PrintLog("*");
			this.CalculateResult(ans);
			selectedOperator = Operator.Multiply;
		}

		/// <summary>
		///     Process Divide operation.
		/// </summary>
		/// <param name="ans">Answer in double.</param>
		public void ProcessDivide(double ans)
		{
			this.outputProcessor.PrintLog("÷");
			this.CalculateResult(ans);
			selectedOperator = Operator.Divide;
		}

		/// <summary>
		///     Process Fact operation.
		/// </summary>
		/// <param name="ans">Answer in double.</param>
		public void ProcessFact(double ans)
		{
			this.outputProcessor.PrintLog("!");
			this.outputProcessor.ResultInLog = true;
			this.CalculateResult(ans, false);
			selectedOperator = Operator.Fact;
		}

		/// <summary>
		///     Process Pow operation.
		/// </summary>
		/// <param name="ans">Answer in double.</param>
		public void ProcessPow(double ans)
		{
			this.outputProcessor.PrintLog("^");
			this.CalculateResult(ans);
			selectedOperator = Operator.Pow;
		}

		/// <summary>
		///     Process Root operation.
		/// </summary>
		/// <param name="ans">Answer in double.</param>
		public void ProcessRoot(double ans)
		{
			this.outputProcessor.PrintLog("√");
			this.CalculateResult(ans);
			selectedOperator = Operator.Root;
		}

		/// <summary>
		///     Process Log operation.
		/// </summary>
		/// <param name="ans">Answer in double.</param>
		public void ProcessLog(double ans)
		{
			this.outputProcessor.PrintLog("log");
			this.CalculateResult(ans);
			selectedOperator = Operator.Log;
		}

		/// <summary>
		///     Calculate result.
		/// </summary>
		/// <param name="ans">Answer in double.</param>
		/// <param name="waitingForNumber">Set to MathProcessor.WaitingForNumber after calculation.</param>
		/// <param name="clear">Clear result and log after calculation.</param>
		public void CalculateResult(double ans, bool waitingForNumber = true, bool clear = false)
		{
			// if waiting for next number, then do not calculate result
			if (WaitingForNumber)
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
				this.outputProcessor.ClearAns();
				this.outputProcessor.ClearLog();
				ClearResult();
				this.outputProcessor.PrintError();

				return;
			}

			this.outputProcessor.PrintAns(result);
			WaitingForNumber = waitingForNumber;

			if (clear)
			{
				this.outputProcessor.ClearLog();
				ClearResult();
			}
		}
	}
}
