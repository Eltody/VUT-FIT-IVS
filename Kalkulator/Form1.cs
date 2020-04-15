using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class Kalkulator : Form
    {
        public Kalkulator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void print0(object sender, EventArgs e)
        {
            if (display.Text != "0")
            {
                display.Text = display.Text + "0";
            }
        }

        private void print1(object sender, EventArgs e)
        {
            if (display.Text == "0")
            {
                display.Text = display.Text.Remove(display.Text.Length - (display.Text.Length));
            }
            display.Text = display.Text + "1";
        }

        private void print2(object sender, EventArgs e)
        {
            if (display.Text == "0")
            {
                display.Text = display.Text.Remove(display.Text.Length - (display.Text.Length));
            }
            display.Text = display.Text + "2";
        }

        private void print3(object sender, EventArgs e)
        {
            if (display.Text == "0")
            {
                display.Text = display.Text.Remove(display.Text.Length - (display.Text.Length));
            }
            display.Text = display.Text + "3";
        }

        private void print4(object sender, EventArgs e)
        {
            if (display.Text == "0")
            {
                display.Text = display.Text.Remove(display.Text.Length - (display.Text.Length));
            }
            display.Text = display.Text + "4";
        }

        private void print5(object sender, EventArgs e)
        {
            if (display.Text == "0")
            {
                display.Text = display.Text.Remove(display.Text.Length - (display.Text.Length));
            }
            display.Text = display.Text + "5";
        }

        private void print6(object sender, EventArgs e)
        {
            if (display.Text == "0")
            {
                display.Text = display.Text.Remove(display.Text.Length - (display.Text.Length));
            }
            display.Text = display.Text + "6";
        }

        private void print7(object sender, EventArgs e)
        {
            if (display.Text == "0")
            {
                display.Text = display.Text.Remove(display.Text.Length - (display.Text.Length));
            }
            display.Text = display.Text + "7";
        }

        private void print8(object sender, EventArgs e)
        {
            if (display.Text == "0")
            {
                display.Text = display.Text.Remove(display.Text.Length - (display.Text.Length));
            }
            display.Text = display.Text + "8";
        }

        private void print9(object sender, EventArgs e)
        {
            if (display.Text == "0")
            {
                display.Text = display.Text.Remove(display.Text.Length - (display.Text.Length));
            }
            display.Text = display.Text + "9";
        }

        private void button_exponent(object sender, EventArgs e)
        {
            display.Text = display.Text + "^";
        }

        private void button_root(object sender, EventArgs e)
        {
            display.Text = display.Text + "√";
        }

        private void button_plus(object sender, EventArgs e)
        {
            display.Text = display.Text + "+";
        }

        private void button_minus(object sender, EventArgs e)
        {
            display.Text = display.Text + "-";
        }

        private void button_multiply(object sender, EventArgs e)
        {
            display.Text = display.Text + "*";
        }

        private void button_dot(object sender, EventArgs e)
        {
            display.Text = display.Text + ",";
        }

        private void button_divide(object sender, EventArgs e)
        {
            display.Text = display.Text + "/";
        }

        private void button_factorial(object sender, EventArgs e)
        {
            display.Text = display.Text + "!";
        }

        private void button_logarythm(object sender, EventArgs e)
        {
            display.Text = display.Text + "ln";
        }

        private void button_equals(object sender, EventArgs e)
        {
            
        }

        private void button_backspace(object sender, EventArgs e)
        {
            display.Text = display.Text.Remove(display.Text.Length - 1);
            if (display.Text.Length == 0)
            {
                display.Text = "0";
            }
        }

        private void button_clear(object sender, EventArgs e)
        {
            if (display.Text.Length != 0)
            {
                display.Text = display.Text.Remove(display.Text.Length - (display.Text.Length));
                display.Text = "0";
            }
        }
    }
}
