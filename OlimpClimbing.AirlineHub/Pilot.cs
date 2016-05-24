using System;

namespace OlimpClimbing.AirlineHub
{
    public class Pilot
    {
        public float DistanceHaversine(Coord a, Coord b)
        {
            var lat = a.LatitudeRadians - b.LatitudeRadians;
            var lng = a.LongitudeRadians - b.LongitudeRadians;
            var h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) +
                          Math.Cos(a.LatitudeRadians) * Math.Cos(b.LatitudeRadians) *
                          Math.Sin(lng / 2) * Math.Sin(lng / 2);
            return (float) (2 * Math.Asin(Math.Min(1, Math.Sqrt(h1))));
            
        }
    }

    public static class NumericExtensions
    {
        public static float ToRadians(this float val)
        {
            return (float) ((Math.PI / 180) * val);
        }
    }
}
