using System;

namespace OlimpClimbing.AirlineHub
{
    public class Program
    {
        //matrix with distance
        //row summ
        private static void Main()
        {
            //var first = Coord.Parse(Console.ReadLine());
            //var second = Coord.Parse(Console.ReadLine());
            var p = new Pilot();
            //Console.WriteLine($"DistanceHaversine - {p.DistanceHaversine(first, second)}");
            Console.WriteLine($"DistanceHaversine - {p.DistanceHaversine(new Coord(90,0), new Coord(-90,0))}");
            //Console.WriteLine($"DistanceHaversine - {p.DistanceHaversine(first, second)}");
            //Console.WriteLine($"Distance - {p.DistanceHaversine(first, second)}");
            Console.ReadLine();
        }
    }
}
