using System;
using System.Windows;
using System.Windows.Controls;
using CalcInterface;

namespace ArithmeticCalcLib
{
    /// <summary>
    /// Interaction logic for ArithmeticCalc.xaml
    /// </summary>
    public partial class ArithmeticCalc : UserControl, ICalc
    {
        public ArithmeticCalc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Even for calculations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            SolutionTextBox.Text = Calculate(ATextBox.Text, BTextBox.Text, OperatorTextBox.Text);
        }

        /// <summary>
        /// Calculate result of the plugin
        /// </summary>
        /// <param name="a">First calculator parameter of type double</param>
        /// <param name="b">Second calculator parameter of type double</param>
        /// <param name="op">specified operator of the calculator</param>
        /// <returns>Result of the operation</returns>
        /// <exception cref="ArgumentException">Thrown if the operator or any parameter is not valid</exception>
        public string Calculate(string a, string b, string op)
        {
            if (!double.TryParse(a, out double first))
            {
                throw new ArgumentException("First argument is not a number");
            }
            if (!double.TryParse(a, out double second))
            {
                throw new ArgumentException("Second argument is not a number");
            }

            double result = op switch
            {
                "+" => first + second,
                "-" => first - second,
                "*" => first * second,
                "/" => first / second,
                "%" => first % second,
                _ => throw new ArgumentException("Invalid operator")
            };

            return result.ToString();
        }
    }
}