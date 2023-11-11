using System.ComponentModel.Composition;
using System.Windows.Controls;
using CalculatorInterface;

namespace SetCalcLib
{
    /// <summary>
    /// Calculator plugin definition
    /// </summary>
    [Export(typeof(ICalculator))]
    public class SetCalcPlugin : ICalculator
    {
        /// <summary>
        /// Name of the plugin
        /// </summary>
        public string Name { get; set; } = "Set calculator";

        /// <summary>
        /// Returns UserControl of the plugin
        /// </summary>
        /// <returns>Plugin UserControl</returns>
        public UserControl GetUserControl()
        {
            return new SetCalcControl();
        }
    }
}
