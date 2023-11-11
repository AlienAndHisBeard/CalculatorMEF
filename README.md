# A task from the forth laboratories of Programming languages on .NET (08.11.2023)

The solution contains a few projects demonstrating System.ComponentModel.Composition with a WPF app:
- ICalc interface with implementations in 2 plugins,
- ICalculator interface used for specifing Plugin contract of ComponentModel composition,
- 2 plugins built to Plugins directory,
- Plugins loaded by CalculatorLoader with ComponentModel Composition,
- Plugins directory watched for changes (new plugins)
- Main CalculatorMEF wpf app to show UserControls of the loaded plugins as tabs,
- Main CalculatorMEF app and plugins loader have no references to Plugins implementations

Plugins from directory Libraries have to be built to Plugins directory to be shown in the main app.


TODO: Rename projects and directories