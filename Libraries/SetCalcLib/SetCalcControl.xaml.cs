using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using CalcInterface;

namespace SetCalcLib;

/// <summary>
///     Interaction logic for SetCalcControl.xaml
/// </summary>
public partial class SetCalcControl : UserControl, ICalc
{
    public SetCalcControl()
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
    /// <param name="a">set A of numbers/words separeted by semicolon</param>
    /// <param name="b">set B of numbers/words separeted by semicolon</param>
    /// <param name="op">specified operator of the calculator</param>
    /// <returns>Result of the operation</returns>
    /// <exception cref="ArgumentException">Thrown if the operator is not valid</exception>
    public string Calculate(string a, string b, string op)
    {
        string[] setA = a.Split(",");
        string[] setB = b.Split(",");

        var result = op switch
        {
            "+" => SetsUnion(setA, setB),
            "*" => SetsComplement(setA, setB),
            _ => throw new ArgumentException("Invalid operator")
        };

        return string.Join(", ", result);
    }

    /// <summary>
    /// Calculate set union
    /// </summary>
    /// <param name="setA"></param>
    /// <param name="setB"></param>
    /// <returns>Set union of sets A and B</returns>
    private IEnumerable<string> SetsUnion(IEnumerable<string> setA, IEnumerable<string> setB)
    {
        var result = setA.ToList();
        result.AddRange(setB.ToList());

        return result.Distinct();
    }

    /// <summary>
    /// Calculate sets compliment
    /// </summary>
    /// <param name="setA"></param>
    /// <param name="setB"></param>
    /// <returns>Set compliment of sets A and B</returns>
    private IEnumerable<string> SetsComplement(IEnumerable<string> setA, IEnumerable<string> setB)
    {
        return setB.Where(setA.Contains).ToList();
    }
}