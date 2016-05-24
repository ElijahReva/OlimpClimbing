namespace OlimpClimbing.AirlineHub
{
    public class Coord
    {
        private float _latitude;
        private float _longitude;

        public Coord(float latitude, float longitude)
        {
            this._latitude = latitude;
            this._longitude = longitude;
        }

        public float LatitudeRadians => _latitude.ToRadians();

        public float LongitudeRadians => _longitude.ToRadians();


        public static Coord Parse(string input)
        {
            var flo = input.Split();
            return new Coord(float.Parse(flo[0]), float.Parse(flo[1]));
        }
    }
}