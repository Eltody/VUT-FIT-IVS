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
using System.Linq;
using System.Globalization;

namespace Kalkulator.Calculator
{
	/// <summary>
	/// Procesor pre výstup
	/// </summary>
	public class OutputProcessor
	{
		/// Maximálny počet znakov vypísaných na displeji
		private const int TextAnsMaxLength = 20;
		/// Limit for basic font size for text_display, then then reduced.
		private const int TextAnsBasicFontLimit = 14;
		/// Konštanta pre redukciu veľkosti písma na displeji
		private const double TextAnsValueOfFontSizeReduction = 2.5;
		/// Veľkosť písma v displeji
		private const double TextAnsBasicFontSize = 42.0;

		/// Culture.
		private const string Culture = "cs-CZ";

		/// log_display TextBox.
		private readonly TextBox log_display;
		
		/// text_display TextBox.
		private readonly TextBox text_display;

		/// Vypísaný výsledok na displeji = true
		public bool IsAnswer = true;

		/// Indicates whether the result is displayed in log (eg. factorial).
		public bool ResultInLog;
		
		/// Indicates whether the memory operator is used.
		public bool IsMemoryOperator = true;

		/// <summary>
		///     OutputProcessor construct.
		/// </summary>
		/// <param name="text_display">text_display TextBox.</param>
		/// <param name="log_display">log_display TextBox.</param>
		public OutputProcessor(TextBox text_display, TextBox log_display)
		{
			this.text_display = text_display;
			this.log_display = log_display;

			// + 2 becouse '-' and ',' char
			this.text_display.MaxLength = TextAnsMaxLength + 2;
			this.text_display.FontSize = TextAnsBasicFontSize;
		}

		/// <summary>
		///     Print number to text_display TextBox in proper format.
		/// </summary>
		/// <param name="number">Pressed number in string format.</param>
		/// <returns>True, if number was printed, false otherwise.</returns>
		public bool PrintNumber(string number)
		{
			// remove "NumPad" from converted string number if NumPad numbers are used
			if (number.Contains("NumPad"))
			{
				number = number.Remove(0, 6);
			}

			// if result is in log, then clear log
			if (this.ResultInLog)
			{
				this.ClearLog();
				MathProcessor.ClearResult();
			}
			this.ResultInLog = false;

			// max length was reached
			if (this.text_display.Text.Length > TextAnsMaxLength && !this.IsAnswer)
			{
				return false;
			}

			if (this.text_display.Text == "0" || this.IsAnswer || this.IsMemoryOperator)
			{
				this.text_display.Text = number;
			}
			else
			{
				this.text_display.Text += number;
			}

			this.text_display.Text = this.FormatNumericValue(this.text_display.Text);
			this.FixAnsFontSize();
			this.IsAnswer = false;
			this.IsMemoryOperator = false;
			MathProcessor.WaitingForNumber = false;

			return true;
		}

		/// <summary>
		/// Výpis desatinnej čiarky
		/// </summary>
		public void PrintComma()
		{
			if (this.IsAnswer)
			{
				this.text_display.Text = "0,";
			}
			else if (!this.text_display.Text.Contains(","))
			{
				this.text_display.Text += ",";
			}

			this.IsAnswer = false;
			MathProcessor.WaitingForNumber = false;
		}

		/// <summary>
		/// Funkcia pre invertovanie Ans
		/// </summary>
		public void InvertAns()
		{
			if (this.IsAnswer || this.IsAnsClear())
			{
				return;
			}

			if (this.text_display.Text.Contains("-"))
			{
				this.text_display.Text = this.text_display.Text.Substring(1, this.text_display.Text.Length - 1);
			}
			else
			{
				this.text_display.Text = "-" + this.text_display.Text;
			}
		}

		/// <summary>
		/// Vypíš odpoveď
		/// </summary>
		/// <param name="answer">Odpoveď</param>
		public void PrintAns(double answer)
		{
			this.text_display.Text = this.FormatNumericValue(answer);
			this.FixAnsFontSize();
			if (!this.ResultInLog)
			{
				this.IsAnswer = true;
			}
		}

		/// <summary>
		///     Print text log.
		/// </summary>
		/// <param name="operation">Operation in string format.</param>
		public void PrintLog(string operation)
		{
			// change last operator
			if (this.log_display.Text.Length != 0 && this.IsAnswer && !this.ResultInLog)
			{
				// remove last whitespace
				this.log_display.Text = this.log_display.Text.Remove(this.log_display.Text.Length - 1);
				// split text by whitespaces to array
				string[] textArray = this.log_display.Text.Split(' ');
				// remove operator (last array item)
				textArray = textArray.Take(textArray.Length - 1).ToArray();
				// join array to string
				this.log_display.Text = string.Join(" ", textArray);
				// add operator
				this.log_display.Text += " " + operation + " ";
			}

			if (!this.IsAnswer)
			{
				this.log_display.Text += (this.ResultInLog ? "" : this.text_display.Text) + " " + operation + " ";
			}

			this.log_display.ScrollToHorizontalOffset(this.log_display.Text.Length * this.log_display.FontSize);
			this.ResultInLog = false;
		}

		/// <summary>
		///     Clear log.
		/// </summary>
		public void ClearLog()
		{
			this.log_display.Text = "";
		}

		/// <summary>
		///     Clear answer.
		/// </summary>
		public void ClearAns()
		{
			this.text_display.Text = "0";
			this.IsAnswer = false;
			this.text_display.FontSize = TextAnsBasicFontSize;
		}
		
		/// <summary>
		/// Výpis erroru na  text_display
		/// </summary>
		public void PrintError()
		{
			this.text_display.Text = "Error";
			this.FixAnsFontSize();
			this.IsAnswer = true;
		}

		/// <summary>
		///     Is answer clear?
		/// </summary>
		/// <returns>True, if answer is clear, false otherwise.</returns>
		private bool IsAnsClear()
		{
			return this.text_display.Text == "0";
		}

		/// <summary>
		///     Remove last number.
		/// </summary>
		public void Backspace()
		{
			if (this.IsAnswer || this.IsAnsClear())
			{
				return;
			}

			if (this.text_display.Text.Length == 1 || this.text_display.Text.Length == 2 && this.text_display.Text.Contains("-"))
			{
				this.ClearAns();
				return;
			}

			int removeLength = 1;
			// if penultimate char is whitespace, then remove it too
			if (string.IsNullOrWhiteSpace(this.text_display.Text.Substring(this.text_display.Text.Length - 2, 1)))
			{
				removeLength++;
			}
			this.text_display.Text = this.text_display.Text.Remove(this.text_display.Text.Length - removeLength);

			this.text_display.Text = this.FormatNumericValue(this.text_display.Text);
			this.FixAnsFontSize();
		}

		/// <summary>
		///     Format numeric value in string to czech number format.
		/// </summary>
		/// <param name="value">Numeric value in string format to be formatted.</param>
		/// <returns>Formated numeric value in string format.</returns>
		private string FormatNumericValue(string value)
		{
			long numericValue;
			string formatedValue;
			CultureInfo cultureInfo = new CultureInfo(Culture);
			value = Utils.RemoveSpaces(value);
			int indexOfDecPoint = value.IndexOf(",", StringComparison.Ordinal);
			if (indexOfDecPoint == -1) // value isn't decimal
			{
				// format number
				long.TryParse(value, out numericValue);
				formatedValue = numericValue.ToString("N", cultureInfo);
				// remove decimal places
				formatedValue = formatedValue.Remove(formatedValue.Length - 3);
			}
			else // value is decimal
			{
				// format non decimal part of number
				string integerPart = value.Substring(0, indexOfDecPoint);
				long.TryParse(integerPart, out numericValue);
				formatedValue = numericValue.ToString("N", cultureInfo);
				// remove decimal places
				formatedValue = formatedValue.Remove(formatedValue.Length - 3);

				// format decimal part of number
				string decimalPart = value.Substring(indexOfDecPoint, value.Length - integerPart.Length);
				formatedValue += decimalPart;
			}

			return formatedValue;
		}

		/// <summary>
		///     Format numeric value in double format to czech number format.
		/// </summary>
		/// <param name="value">Numeric value in double format to be formatted.</param>
		/// <returns>Formated numeric value in string format.</returns>
		private string FormatNumericValue(double value)
		{
			CultureInfo cultureInfo = new CultureInfo(Culture);
			string formatedValue = value.ToString("R", cultureInfo);

			// remove non numeric chars except spaces
			int formatedValueLenght = Utils.RemoveChars(formatedValue, new[] {',', '-'}).Length;

			formatedValue = formatedValueLenght > TextAnsMaxLength || formatedValue.Contains("E")
				? value.ToString("g2", cultureInfo)
				: this.FormatNumericValue(formatedValue);

			return formatedValue;
		}

		/// <summary>
		///     Fix font size of ans text box.
		/// </summary>
		private void FixAnsFontSize()
		{
			// remove non numeric chars, expect spaces
			string textAnsText = Utils.RemoveChars(this.text_display.Text, new[] {',', '-'});
			double size = TextAnsBasicFontSize;

			if (textAnsText.Length > TextAnsBasicFontLimit)
			{
				size -= TextAnsValueOfFontSizeReduction * (textAnsText.Length - TextAnsBasicFontLimit) *
						((100 - (textAnsText.Length - TextAnsBasicFontLimit) * 2) / 100.0);
			}

			this.text_display.FontSize = size;
		}
	}
}
