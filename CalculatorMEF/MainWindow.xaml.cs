using CalculatorLoaders;
using System;
using System.Configuration;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace CalculatorMEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CalculatorLoader _calculatorLoader;

        /// <summary>
        /// Initialize window and load plugins
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            
            // create plugin loader for the specified plugins directory
            _calculatorLoader = new CalculatorLoader(ConfigurationManager.AppSettings["PluginsPath"]);
            // watch the directory for changes
            _calculatorLoader.FilesChanged += OnFilesChanged;
            // load plugins composition
            _calculatorLoader.LoadPlugins();

            // load UserControls from plugins, create new tabs
            foreach (var pluginData in _calculatorLoader.GetPlugins())
            {
                Plugins.Items.Add(new TabItem
                {
                    Header = pluginData.Name,
                    Content = pluginData.GetUserControl()
                });
            }
        }

        /// <summary>
        /// Handle plugins when plugins in the directory changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnFilesChanged(object? sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(
            new ThreadStart(() =>
            {
                Plugins.Items.Clear();

                // load UserControls from plugins, create new tabs
                foreach (var pluginData in _calculatorLoader.GetPlugins())
                {
                    Plugins.Items.Add(new TabItem
                    {
                        Header = pluginData.Name,
                        Content = pluginData.GetUserControl()
                    });
                }
            })
        );
        }
    }
}
