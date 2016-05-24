using System;
using System.Collections.Generic;

namespace OlimpClimbing.CD
{
    public static class CD
    {
        private static readonly int[] ints = new int[2];
        private static int count;
        private static HashSet<int> hash;
        private static int splitterIndex;
        private static int i;
        private static string l;

        private static void Main()
        {
            while ((l = System.Console.ReadLine()) != "0 0")
            {
                splitterIndex = l.IndexOf(' ');
                ints[0] = int.Parse(l.Substring(0, splitterIndex));
                ints[1] = int.Parse(l.Substring(splitterIndex, l.Length - splitterIndex));
                count = Math.Max(ints[0], ints[1]);
                hash = new HashSet<int>(new int[count]);
                hash.Clear();
                count = 0;
                for (i = 0; i < ints[0]; i++)
                {
                    hash.Add(int.Parse(System.Console.ReadLine()));
                }
                for (i = 0; i < ints[1]; i++)
                {
                    if (hash.Contains(int.Parse(System.Console.ReadLine())))
                    {
                        count++;
                    }
                }
                System.Console.WriteLine(count);
            }
        }
    }
}
