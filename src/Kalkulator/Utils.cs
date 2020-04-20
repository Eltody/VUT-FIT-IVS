/**************************************************************
* Názov tímu: Slovenská (j)elita
*
* Autori projektu:      Tomáš Zaťko(xzatko02)
*                       Martin Rakús(xrakus04)
*                       Patrik Jacola(xjacol00)
*                       Monika Kubincová(xkubin24)
**************************************************************/

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Kalkulator.Calculator
{
	/// <summary>
	/// Užitočné funkcie
	/// </summary>
	public static class Utils
	{
		/// <summary>
		/// Kontrola, či je zvolené tlačítko číslo
		/// </summary>
		/// <param name="key">Key object</param>
		/// <returns></returns>
		public static bool IsNumericKey(Key key)
		{
			return key >= Key.D0 && key <= Key.D9 || key >= Key.NumPad0 && key <= Key.NumPad9;
		}

		/// <summary>
		/// Odstránenie medzier zo zadaného stringu
		/// </summary>
		/// <param name="s">String pre odstránenie medzier</param>
		/// <returns>Zadaný string bez medzier</returns>
		public static string RemoveSpaces(string s)
		{
			return Regex.Replace(s, @"\s", "");
		}

		/// <summary>
		/// Odstránenie zadaných znakov zo stringu
		/// </summary>
		/// <param name="s">String, z ktorého budú znaky vymazané</param>
		/// <param name="chars">Znaky pre vymazanie</param>
		/// <returns>Zadaný string bez konkrétnych znakov</returns>
		public static string RemoveChars(string s, IEnumerable<char> chars)
		{
			return chars.Aggregate(s, (current, c) => current.Replace(c.ToString(), string.Empty));
		}
	}
}
