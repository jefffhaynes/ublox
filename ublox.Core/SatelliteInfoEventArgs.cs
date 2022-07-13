using System;
using System.Collections.Generic;
using ublox.Core.Messages;

namespace ublox.Core
{
    public class SatelliteInfoEventArgs : EventArgs
    {
        internal SatelliteInfoEventArgs(NavSat navSat)
        {
            Satellites = navSat.Satellites;
        }

        public List<SatelliteDetail> Satellites { get; }
    }
}
