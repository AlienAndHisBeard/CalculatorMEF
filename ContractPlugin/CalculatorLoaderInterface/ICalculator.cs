using System;
using System.Windows.Controls;

namespace CalculatorInterface
{

    /// <summary>
    /// Inteface used for component model composition
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// Name of the plugin
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// UserControl returned by the plugin
        /// </summary>
        /// <returns>Calculator UserControl</returns>
        UserControl GetUserControl();
    }
}
