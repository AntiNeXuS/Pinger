using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using PluginBase.Interfaces;

namespace TrayApp
{
    internal class PluginManager
    {
        private readonly ITrayMenu _menu;

        public PluginManager(ITrayMenu menu)
        {
            _menu = menu;
            Plugins = new List<IPlugin>();
        }

        public List<IPlugin> Plugins { get; }

        public void LoadPlugins()
        {
            var interfaceFilter = typeof(IPlugin);
            
            var pathToPlugins = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Plugins");
            var plugins = Directory.GetFiles(pathToPlugins, "*Plugin.dll");

            foreach (var pluginPath in plugins)
            {
                try
                {
                    var pluginAssembly = Assembly.LoadFrom(pluginPath);

                    foreach (var type in pluginAssembly.GetTypes())
                    {
                        if (interfaceFilter.IsAssignableFrom(type))
                        {
                            var pluginInstance = (IPlugin)Activator.CreateInstance(type);
                            if (pluginInstance.Initialize(_menu) == true)
                            {
                                Plugins.Add(pluginInstance);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    
                }
            }
        }
    }
}