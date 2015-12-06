using System.Windows.Forms;

namespace TrayApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var contextMenu = new TrayMenu();
            var pluginManager = new PluginManager(contextMenu);
            pluginManager.LoadPlugins();

            var worker = new TrayWorker(contextMenu);

            Application.Run();
        }
    }
}
