using System;
using System.Collections.Generic;
using Windows.Devices.Geolocation;

namespace ublox.Utility
{
    public static class GeoExtensionMethods
    {
        private const double Circle = 2 * Math.PI;
        private const double DegreesToRadian = Math.PI / 180.0;
        private const double RadianToDegrees = 180.0 / Math.PI;
        private const double EarthRadius = 6378137.0;

        public static IList<Geopoint> GetCirclePoints(this Geopoint center,
            double radius, int nrOfPoints = 50)
        {
            var locations = new List<Geopoint>();
            var latA = center.Position.Latitude * DegreesToRadian;
            var lonA = center.Position.Longitude * DegreesToRadian;
            var angularDistance = radius / EarthRadius;

            var sinLatA = Math.Sin(latA);
            var cosLatA = Math.Cos(latA);
            var sinDistance = Math.Sin(angularDistance);
            var cosDistance = Math.Cos(angularDistance);
            var sinLatAtimeCosDistance = sinLatA * cosDistance;
            var cosLatAtimeSinDistance = cosLatA * sinDistance;

            var step = Circle / nrOfPoints;
            for (double angle = 0; angle < Circle; angle += step)
            {
                var lat = Math.Asin(sinLatAtimeCosDistance + cosLatAtimeSinDistance *
                                    Math.Cos(angle));
                var dlon = Math.Atan2(Math.Sin(angle) * cosLatAtimeSinDistance,
                    cosDistance - sinLatA * Math.Sin(lat));
                var lon = (lonA + dlon + Math.PI) % Circle - Math.PI;

                locations.Add(new Geopoint(new BasicGeoposition
                {
                    Latitude = lat * RadianToDegrees,
                    Longitude = lon * RadianToDegrees
                }));
            }
            return locations;
        }
    }
}