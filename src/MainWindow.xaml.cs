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

namespace Kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void number_click(object sender, RoutedEventArgs e)
        {
    //      this.outputProcessor.PrintNumber(((Button)sender).Content.ToString());
        }

        private void backspace_click(object sender, RoutedEventArgs e)
        {
    //      this.outputProcessor.Backspace();
        }

        private void about_us(object sender, RoutedEventArgs e)
        {
    //      AboutWindow about = new AboutWindow();
    //      about.ShowDialog();
        }

        private void clear_click(object sender, RoutedEventArgs e)
        {
    //      this.outputProcessor.ClearAns();
    //      this.outputProcessor.ClearLog();
    //      MathProcessor.ClearResult();
        }

        private void negation_click(object sender, RoutedEventArgs e)
        {
    //      this.outputProcessor.InvertAns();
        }

        private void plus_click(object sender, RoutedEventArgs e)
        {
    //      this.mathProcessor.ProcessAdd(this.GetNumericAns());
        }

        private void minus_click(object sender, RoutedEventArgs e)
        {
    //      this.mathProcessor.ProcessSubstract(this.GetNumericAns());
        }

        private void multiply_click(object sender, RoutedEventArgs e)
        {
    //      this.mathProcessor.ProcessMultiply(this.GetNumericAns());
        }

        private void divide_click(object sender, RoutedEventArgs e)
        {
    //      this.mathProcessor.ProcessDivide(this.GetNumericAns());
        }

        private void exponent_click(object sender, RoutedEventArgs e)
        {
    //      this.mathProcessor.ProcessPow(this.GetNumericAns());
        }

        private void root_click(object sender, RoutedEventArgs e)
        {
    //      this.mathProcessor.ProcessRoot(this.GetNumericAns());
        }

        private void logarythm_click(object sender, RoutedEventArgs e)
        {
    //      this.mathProcessor.ProcessRoot(this.GetNumericAns());
        }

        private void factorial_click(object sender, RoutedEventArgs e)
        {
    //      this.mathProcessor.ProcessFact(this.GetNumericAns());
        }

        private void enter_click(object sender, RoutedEventArgs e)
        {
    //      this.mathProcessor.CalculateResult(this.GetNumericAns(), false, true);
        }
    }
}
