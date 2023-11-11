using System.ComponentModel.Composition;
using System.Windows.Controls;
using CalculatorInterface;

namespace ArithmeticCalcLib
{
    /// <summary>
    /// Calculator plugin definition
    /// </summary>
    [Export(typeof(ICalculator))]
    public class ArithmeticCalcPlugin : ICalculator
    {
        /// <summary>
        /// Name of the plugin
        /// </summary>
        public string Name { get; set; } = "Arithmetic Calc";

        /// <summary>
        /// Returns UserControl of the plugin
        /// </summary>
        /// <returns>Plugin UserControl</returns>
        public UserControl GetUserControl()
        {
            return new ArithmeticCalc();
        }
    }
}
