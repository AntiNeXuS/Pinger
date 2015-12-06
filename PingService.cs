using System;
using System.Net.NetworkInformation;
using System.Text;
using System.Timers;

namespace Pinger
{
    internal class PingService
    {
        #region Privates

        private readonly string _adress;
        private readonly int _timeout;
        private readonly int _freqency;
        private readonly Ping _ping;
        private readonly Timer _timer;

        // буфер для отправки
        private readonly byte[] buffer = Encoding.ASCII.GetBytes("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

        #endregion

        public EventHandler<PingCompletedEventArgs> PingCompleted;

        public PingService(string adress, int timeout, int freqency)
        {
            _adress = adress;
            _timeout = timeout;
            _freqency = freqency * 1000;
            _ping = new Ping();
            _ping.PingCompleted += OnPingCompleted;

            _timer = new Timer();
            _timer.Elapsed += TimerOnElapsed;
            _timer.Start();
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            _ping.SendAsync(_adress, _timeout, buffer);

            if (_timer.Interval < _freqency)
                _timer.Interval = _freqency;
        }

        private void OnPingCompleted(object sender, PingCompletedEventArgs pingCompletedEventArgs)
        {
            PingCompleted?.Invoke(sender, pingCompletedEventArgs);
        }
    }
}