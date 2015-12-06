using System;
using System.Collections.Generic;

namespace PingerPlugin.Settings
{
    [Serializable]
    public class PingerSettings
    {
        public List<string> Servers { get; set; }

        public int Freqency { get; set; }

        public int Timeout { get; set; }
    }
}