using System;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using Pinger.Properties;

namespace Pinger
{
    public class TrayWorker
    {
        #region Privates

        private readonly NotifyIcon _notifyIcon;
        private readonly ContextMenuStrip _contextMenu;

        #region Icons

        private readonly Icon _ok = Icon.FromHandle(Resources.Ok.GetHicon());
        private readonly Icon _bad = Icon.FromHandle(Resources.Bad.GetHicon());

        #endregion
        
        private readonly PingService _pingService;
        private readonly Settings _settings = new Settings();

        #endregion
        
        public TrayWorker()
        {
            _notifyIcon = new NotifyIcon {Text = "Pinger", Icon = Properties.Resources.Main};

            _contextMenu = new ContextMenuStrip();
            _contextMenu.Items.Add("Good", Properties.Resources.Ok);
            _contextMenu.Items.Add("Bad", Properties.Resources.Bad);
            _contextMenu.Items.Add("-");
            _contextMenu.Items.Add("Выход", Properties.Resources.Exit, OnQuit);

            _notifyIcon.ContextMenuStrip = _contextMenu;
            _notifyIcon.Visible = true;

            _pingService = new PingService(_settings.Servers.First(), _settings.Timeout, _settings.Freqency);
            _pingService.PingCompleted += PingCompleted;
        }

        private void PingCompleted(object sender, PingCompletedEventArgs eventArgs)
        {
            _notifyIcon.Icon = eventArgs.Reply.Status == IPStatus.Success ? _ok : _bad;
        }
        
        private void OnQuit(object sender, EventArgs eventArgs)
        {
            _notifyIcon.Visible = false;
            Application.Exit();
        }
    }
}