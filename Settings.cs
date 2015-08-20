using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Pinger
{
    internal class Settings
    {
        internal List<string> Servers { get; }

        internal int Freqency { get; }

        internal int Timeout { get; }

        public Settings()
        {
            try
            {
                var serverList = ConfigurationManager.AppSettings["ServerList"];
                var splitter = ConfigurationManager.AppSettings["SplitCharacter"];
                Servers = serverList.Split(splitter[0]).ToList();
                Freqency = int.Parse(ConfigurationManager.AppSettings["PingFreq"]);
                Timeout = int.Parse(ConfigurationManager.AppSettings["Timeout"]);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Невозможно загрузить конфигурацию", e);
            }
        }
    }
}