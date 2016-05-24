using System;
using System.Linq;

namespace OlimpClimbing.Different
{
    public static class Program
    {
        private static void Main()
        {
            string l;
            while ((l = Console.ReadLine()) != null)
            {
                long[] pair = l.Split(' ').Select(long.Parse).ToArray();
                Console.WriteLine(Math.Abs(pair[0]-pair[1]));
            }
        }
    }
}
