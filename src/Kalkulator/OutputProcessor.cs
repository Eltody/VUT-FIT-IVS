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
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Kalkulator.Calculator
{
	/// <summary>
	/// Procesor pre výstup
	/// </summary>
	public class OutputProcessor
	{
		/// Maximálny počet znakov vypísaných na displeji
		private const int TextMaxLength = 20;

		/// Maximálny počet znakov vypísaných na log displeji
		private const int TextFontLength = 14;

		/// Konštanta pre redukciu veľkosti písma na displeji
		private const double TextFontSizePercentage = 2.5;

		/// Veľkosť písma v displeji
		private const double TextFontSize = 42.0;

		/// Jazyk.
		private const string lang = "sk-SK";

		/// log_display TextBox.
		private readonly TextBox log_display;
		
		/// text_display TextBox.
		private readonly TextBox text_display;

		/// Vypísaný výsledok na hlavnom displeji = true
		public bool IsTextDisplay = true;

		/// Vypísaný výsledok na log displeji = true
		public bool IsLogDisplay;

		/// <summary>
		/// Deklarácia displejov
		/// </summary>
		/// <param name="text_display">Dolný displej - zadávané čísla</param>
		/// <param name="log_display">Horný displej - log výpočtov</param>
		public OutputProcessor(TextBox text_display, TextBox log_display)
		{
			this.text_display = text_display;
			this.log_display = log_display;

			this.text_display.MaxLength = TextMaxLength + 2; // maximálna dĺžka riadka + 2 (znaky "-" a ",")
			this.text_display.FontSize = TextFontSize;	// veľkosť textu
		}

		/// <summary>
		/// Výpis čísel na textový displej / úprava formátu
		/// </summary>
		/// <param name="number">Zadané číslo vo formáte string</param>
		/// <returns>True ak sa číslo vypísalo, false ak nie</returns>
		public bool PrintNumber(string number)
		{
			if (number.Contains("NumPad"))	// V prípade zadávania čísel pomocou numerickej klávesnice odstráni NumPad
			{
				number = number.Remove(0, 6);
			}

			if (this.IsLogDisplay)	// pokiaľ sa výsledok zapíše do log displeju, vyčistí ho
			{
				this.ClearLog();
				MathProcessor.ClearResult();
			}
			this.IsLogDisplay = false;

			if (this.text_display.Text.Length > TextMaxLength && !this.IsTextDisplay)   // kontrola počtu znakov
			{
				return false;
			}

			if (this.text_display.Text == "0" || this.IsTextDisplay)
			{
				this.text_display.Text = number;
			}
			else
			{
				this.text_display.Text += number;
			}

			this.text_display.Text = this.FormatNumericValue(this.text_display.Text);
			this.FixAnsFontSize();
			this.IsTextDisplay = false;
			MathProcessor.WaitingForNumber = false;

			return true;
		}

		/// <summary>
		/// Výpis desatinnej čiarky
		/// </summary>
		public void PrintComma()
		{
			if (this.IsTextDisplay)
			{
				this.text_display.Text = "0,";
			}
			else if (!this.text_display.Text.Contains(","))
			{
				this.text_display.Text += ",";
			}

			this.IsTextDisplay = false;
			MathProcessor.WaitingForNumber = false;
		}

		/// <summary>
		/// Funkcia pre invertovanie čísla
		/// </summary>
		public void InvertNumber()
		{
			if (this.IsTextDisplay || this.IsTextClear())
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
		/// Výpis odpovede
		/// </summary>
		/// <param name="answer">Odpoveď</param>
		public void PrintText(double answer)
		{
			this.text_display.Text = this.FormatNumericValue(answer);
			this.FixAnsFontSize();
			if (!this.IsLogDisplay)
			{
				this.IsTextDisplay = true;
			}
		}

		/// <summary>
		/// Výpis zadávaných čísel
		/// </summary>
		/// <param name="operation">Zadávané operácie</param>
		public void PrintLog(string operation)
		{
			// change last operator
			if (this.log_display.Text.Length != 0 && this.IsTextDisplay && !this.IsLogDisplay)
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

			if (!this.IsTextDisplay)
			{
				this.log_display.Text += (this.IsLogDisplay ? "" : this.text_display.Text) + " " + operation + " ";
			}

			this.log_display.ScrollToHorizontalOffset(this.log_display.Text.Length * this.log_display.FontSize);
			this.IsLogDisplay = false;
		}

		/// <summary>
		/// Vyčistí log displej
		/// </summary>
		public void ClearLog()
		{
			this.log_display.Text = "";
		}

		/// <summary>
		/// Vyčistí text displej
		/// </summary>
		public void ClearText()
		{
			this.text_display.Text = "0";
			this.IsTextDisplay = false;
			this.text_display.FontSize = TextFontSize;
		}
		
		/// <summary>
		/// Výpis erroru na text displej
		/// </summary>
		public void PrintError()
		{
			this.text_display.Text = "Error";
			this.FixAnsFontSize();
			this.IsTextDisplay = true;
		}

		/// <summary>
		/// Zisťuje či text displej obsahuje nejaké hodnoty
		/// </summary>
		/// <returns>True ak je prázdny, false ak nie</returns>
		private bool IsTextClear()
		{
			return this.text_display.Text == "0";
		}

		/// <summary>
		/// Vymaže posledný znak
		/// </summary>
		public void Backspace()
		{
			if (this.IsTextDisplay || this.IsTextClear())
			{
				return;
			}

			if (this.text_display.Text.Length == 1 || this.text_display.Text.Length == 2 && this.text_display.Text.Contains("-"))
			{
				this.ClearText();
				return;
			}

			int removeLength = 1;
			if (string.IsNullOrWhiteSpace(this.text_display.Text.Substring(this.text_display.Text.Length - 2, 1)))	// pokiaľ je pred odstraňovaným znakom medzera odstráni aj tú
			{
				removeLength++;
			}
			this.text_display.Text = this.text_display.Text.Remove(this.text_display.Text.Length - removeLength);

			this.text_display.Text = this.FormatNumericValue(this.text_display.Text);
			this.FixAnsFontSize();
		}

		/// <summary>
		/// Formátuje čísla do slovenského formátu
		/// </summary>
		/// <param name="value">Čísla na formátovanie</param>
		/// <returns>Formátované čísla</returns>
		private string FormatNumericValue(string value)
		{
			long numericValue;
			string formatedValue;
			CultureInfo cultureInfo = new CultureInfo(lang);
			value = OutputProcessor.RemoveSpaces(value);
			int indexOfDecPoint = value.IndexOf(",", StringComparison.Ordinal);
			if (indexOfDecPoint == -1) // nedesatinná hodnota
			{
				long.TryParse(value, out numericValue);
				formatedValue = numericValue.ToString("N", cultureInfo);
				formatedValue = formatedValue.Remove(formatedValue.Length - 3);
			}
			else // desatinná hodnota
			{
				string integerPart = value.Substring(0, indexOfDecPoint);
				long.TryParse(integerPart, out numericValue);
				formatedValue = numericValue.ToString("N", cultureInfo);
				formatedValue = formatedValue.Remove(formatedValue.Length - 3);

				string decimalPart = value.Substring(indexOfDecPoint, value.Length - integerPart.Length);	// formátuje desatinnú časť čísla
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
			CultureInfo cultureInfo = new CultureInfo(lang);
			string formatedValue = value.ToString("R", cultureInfo);

			// remove non numeric chars except spaces
			int formatedValueLenght = OutputProcessor.RemoveChars(formatedValue, new[] {',', '-'}).Length;

			formatedValue = formatedValueLenght > TextMaxLength || formatedValue.Contains("E")
				? value.ToString("g2", cultureInfo)
				: this.FormatNumericValue(formatedValue);

			return formatedValue;
		}

		/// <summary>
		/// Mení veľkosť textu v text displeji
		/// </summary>
		private void FixAnsFontSize()
		{
			string textAnsText = OutputProcessor.RemoveChars(this.text_display.Text, new[] {',', '-'});	// odstráni nenumerické znaky
			double size = TextFontSize;

			if (textAnsText.Length > TextFontLength)
			{
				size -= TextFontSizePercentage * (textAnsText.Length - TextFontLength) *
						((100 - (textAnsText.Length - TextFontLength) * 2) / 100.0);
			}

			this.text_display.FontSize = size;
		}

		/// <summary>
		/// Kontroluje či je vstupná klávesa číslo
		/// </summary>
		/// <param name="key">Klávesa</param>
		/// <returns>Číslo</returns>
		public static bool IsNumericKey(Key key)
		{
			return key >= Key.D0 && key <= Key.D9 || key >= Key.NumPad0 && key <= Key.NumPad9;
		}

		/// <summary>
		/// Odstraňuje medzery z textu
		/// </summary>
		/// <param name="s">Text z ktorého sa majú odstrániť medzery</param>
		/// <returns>Text bez medzier</returns>
		public static string RemoveSpaces(string s)
		{
			return Regex.Replace(s, @"\s", "");
		}


		/// <summary>
		/// Odstraňuje dané znaky z textu
		/// </summary>
		/// <param name="s">Text z ktorého sa majú odstrániť dané znaky</param>
		/// <param name="chars">Znaky ktoré sa majú odstrániť</param>
		/// <returns>Text bez znakov</returns>
		public static string RemoveChars(string s, IEnumerable<char> chars)
		{
			return chars.Aggregate(s, (current, c) => current.Replace(c.ToString(), string.Empty));
		}
	}
}
