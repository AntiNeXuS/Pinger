using System;
using System.Windows.Forms;
using TrayApp.Properties;

namespace TrayApp
{
    internal class TrayWorker
    {
        #region Privates

        private readonly NotifyIcon _notifyIcon;

        #endregion

        #region Constructors

        public TrayWorker(TrayMenu menu)
        {
            _notifyIcon = new NotifyIcon {Text = "TrayPluginSystem", Icon = Resources.Main};
            
            menu.AddSeparator();
            menu.Add(new ToolStripMenuItem("Выход", Resources.Exit, OnQuit));

            _notifyIcon.ContextMenuStrip = menu.ContextMenu;
            _notifyIcon.Visible = true;
        }

        #endregion
        
        private void OnQuit(object sender, EventArgs eventArgs)
        {
            _notifyIcon.Visible = false;
            Application.Exit();
        }
    }
}