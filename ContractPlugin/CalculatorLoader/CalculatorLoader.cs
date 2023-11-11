using System;
using System.IO;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Collections.Generic;
using CalculatorInterface;

namespace CalculatorLoaders
{
    /// <summary>
    /// Watches plugins folder for new plugins and handles/loads them
    /// </summary>
    public class CalculatorLoader
    {
        // import plugins
        [ImportMany(typeof(ICalculator), AllowRecomposition = true)]
        private readonly List<ICalculator> _calculators = new();

        // handle plugins directory
        private readonly string _path;
        public EventHandler? FilesChanged { get; set; }
        private readonly FileSystemWatcher _fileSystemWatcher;

        // aggregate loaded plugins
        private readonly AggregateCatalog _aggregateCatalog;

        /// <summary>
        /// Create plugins loader
        /// </summary>
        /// <param name="pluginsDirectory"> Directory of the plugins</param>
        public CalculatorLoader(string pluginsDirectory)
        {
            _path = pluginsDirectory;
            _aggregateCatalog = new AggregateCatalog();
            _fileSystemWatcher = new FileSystemWatcher(_path);
        }

        /// <summary>
        /// Make composition of the plugins
        /// </summary>
        public void LoadPlugins()
        {
            var compositionBatch = new CompositionBatch();
            compositionBatch.AddPart(this);

            _fileSystemWatcher.NotifyFilter = NotifyFilters.Attributes
                                              | NotifyFilters.CreationTime
                                              | NotifyFilters.DirectoryName
                                              | NotifyFilters.FileName
                                              | NotifyFilters.LastAccess
                                              | NotifyFilters.LastWrite
                                              | NotifyFilters.Security
                                              | NotifyFilters.Size;

            _fileSystemWatcher.Created += OnPluginsDirectoryChange;
            _fileSystemWatcher.Filter = "*.dll";
            _fileSystemWatcher.EnableRaisingEvents = true;

            _aggregateCatalog.Catalogs.Add(new DirectoryCatalog(_path));

            var compositionContainer = new CompositionContainer(_aggregateCatalog);
            compositionContainer.Compose(compositionBatch);
        }

        /// <summary>
        /// Inform Calculator app that plugins changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPluginsDirectoryChange(object sender, FileSystemEventArgs e)
        {
            _aggregateCatalog.Catalogs.Clear();
            _aggregateCatalog.Catalogs.Add(new DirectoryCatalog(_path));

            FilesChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// Get plugins
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICalculator> GetPlugins()
        {
            foreach (var plugin in _calculators)
                yield return plugin;
        }
    }
}
