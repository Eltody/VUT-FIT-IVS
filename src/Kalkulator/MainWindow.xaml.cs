/**************************************************************
* Názov tímu: Slovenska(j)elita
*
* Autori projektu:      Tomáš Zaťko(xzatko02)
*                       Martin Rakús(xrakus04)
*                       Patrik Jacola(xjacol00)
*                       Monika Kubincová(xkubin24)
**************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kalkulator.Calculator
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// TextLog scroll offsset.
        private const double TextLogScrollOffset = 15.0;

        /// Math operations processor.
        private readonly MathProcessor mathProcessor;

        /// Output result processor.
        private readonly OutputProcessor outputProcessor;

        public MainWindow()
        {
            this.InitializeComponent();
            this.outputProcessor = new OutputProcessor(this.text_display, this.log_display);
            this.mathProcessor = new MathProcessor(this.outputProcessor);
        }

        private void log_display_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            double scroll = this.text_display.HorizontalOffset;
            if (e.Delta > 0)
            {
                scroll -= TextLogScrollOffset;
                this.text_display.ScrollToHorizontalOffset(scroll);
            }
            else
            {
                scroll += TextLogScrollOffset;
            this.text_display.ScrollToHorizontalOffset(scroll);
            }
            this.text_display.UpdateLayout();
        }

        private void number_click(object sender, RoutedEventArgs e)
        {
            this.outputProcessor.PrintNumber(((Button)sender).Content.ToString());
        }

        private void backspace_click(object sender, RoutedEventArgs e)
        {
            this.outputProcessor.Backspace();
        }

        private void about_us(object sender, RoutedEventArgs e)
        {
            About_us about = new About_us();
            about.ShowDialog();
        }

        private void clear_click(object sender, RoutedEventArgs e)
        {
            this.outputProcessor.ClearAns();
            this.outputProcessor.ClearLog();
            MathProcessor.ClearResult();
        }

        private void negation_click(object sender, RoutedEventArgs e)
        {
            this.outputProcessor.InvertAns();
        }

        private void plus_click(object sender, RoutedEventArgs e)
        {
            this.mathProcessor.ProcessAdd(this.GetNumericAns());
        }

        private void minus_click(object sender, RoutedEventArgs e)
        {
            this.mathProcessor.ProcessSubstract(this.GetNumericAns());
        }

        private void multiply_click(object sender, RoutedEventArgs e)
        {
            this.mathProcessor.ProcessMultiply(this.GetNumericAns());
        }

        private void divide_click(object sender, RoutedEventArgs e)
        {
            this.mathProcessor.ProcessDivide(this.GetNumericAns());
        }

        private void exponent_click(object sender, RoutedEventArgs e)
        {
            this.mathProcessor.ProcessPow(this.GetNumericAns());
        }

        private void root_click(object sender, RoutedEventArgs e)
        {
            this.mathProcessor.ProcessRoot(this.GetNumericAns());
        }

        private void logarythm_click(object sender, RoutedEventArgs e)
        {
            this.mathProcessor.ProcessLog(this.GetNumericAns());
        }

        private void factorial_click(object sender, RoutedEventArgs e)
        {
            this.mathProcessor.ProcessFact(this.GetNumericAns());
        }

        private void enter_click(object sender, RoutedEventArgs e)
        {
            this.mathProcessor.CalculateResult(this.GetNumericAns(), false, true);
        }

        private void comma_click(object sender, RoutedEventArgs e)
        {
            this.outputProcessor.PrintComma();
        }

        /// <summary>
		///     Process pressed keys.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">KeyEventArgs.</param>
		private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            bool shiftPressed = (Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift;

            // print number
            if (!shiftPressed && Utils.IsNumericKey(e.Key))
            {
                KeyConverter keyConverter = new KeyConverter();
                this.outputProcessor.PrintNumber(keyConverter.ConvertToString(e.Key));
            }

            // print decimal separator (comma)
            if (!shiftPressed && (e.Key == Key.Decimal || e.Key == Key.OemComma || e.Key == Key.OemPeriod))
            {
                this.outputProcessor.PrintComma();
            }

            // calculate result
            if (e.Key == Key.Enter || e.Key == Key.Return || !shiftPressed && e.Key == Key.OemPlus)
            {
                this.mathProcessor.CalculateResult(this.GetNumericAns(), false, true);
            }

            // remove last number
            if (e.Key == Key.Back)
            {
                this.outputProcessor.Backspace();
            }

            // sum
            if (e.Key == Key.Add || shiftPressed && e.Key == Key.OemPlus)
            {
                this.mathProcessor.ProcessAdd(this.GetNumericAns());
            }

            // sub
            if (e.Key == Key.Subtract || !shiftPressed && e.Key == Key.OemMinus)
            {
                this.mathProcessor.ProcessSubstract(this.GetNumericAns());
            }

            // mult
            if (e.Key == Key.Multiply || shiftPressed && e.Key == Key.D8)
            {
                this.mathProcessor.ProcessMultiply(this.GetNumericAns());
            }

            // div
            if (e.Key == Key.Divide || !shiftPressed && e.Key == Key.OemQuestion)
            {
                this.mathProcessor.ProcessDivide(this.GetNumericAns());
            }

            // fact
            if (shiftPressed && e.Key == Key.D1)
            {
                this.mathProcessor.ProcessFact(this.GetNumericAns());
            }

            // pow
            if (shiftPressed && e.Key == Key.D6)
            {
                this.mathProcessor.ProcessPow(this.GetNumericAns());
            }
        }


        /// <summary>
		///     Get answer parsed double.
		/// </summary>
		/// <returns>Parsed answer to double.</returns>
        private double GetNumericAns()
        {
            double ans;
            double.TryParse(this.text_display.Text, out ans);

            return ans;
        }
    }
}
