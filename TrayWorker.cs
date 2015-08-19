using System;
using System.Configuration;
using System.Windows.Forms;

namespace Pinger
{
    public class TrayWorker
    {
        private NotifyIcon _notifyIcon;
        private ContextMenuStrip _contextMenu;

        public TrayWorker()
        {
            _notifyIcon = new NotifyIcon {Text = "Pinger", Icon = Properties.Resources.Main};

            var serverList = ConfigurationManager.AppSettings["ServerList"];
            if (serverList == null) return;

            var splitter = ConfigurationManager.AppSettings["SplitCharacter"];
            var servers = serverList.Split(splitter[0]);
            var freq = ConfigurationManager.AppSettings["PingFreq"];

            _contextMenu = new ContextMenuStrip();
            _contextMenu.Items.Add("Good", Properties.Resources.Ok);
            _contextMenu.Items.Add("Bad", Properties.Resources.Bad);
            _contextMenu.Items.Add("-");
            _contextMenu.Items.Add("Выход", Properties.Resources.Exit, OnQuit);

            _notifyIcon.ContextMenuStrip = _contextMenu;
            _notifyIcon.Visible = true;
        }

        private void OnQuit(object sender, EventArgs eventArgs)
        {
            _notifyIcon.Visible = false;
            Application.Exit();
        }
    }
}