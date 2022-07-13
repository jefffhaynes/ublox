using System;
using System.Collections.Generic;
using ublox.Core.Messages;

namespace ublox.Core
{
    public class SatelliteInfoEventArgs : EventArgs
    {
        internal SatelliteInfoEventArgs(NavSvInfo navSvInfo)
        {
            Satellites = navSvInfo.Satellites;
        }

        public List<SvInfo> Satellites { get; }
    }
}
