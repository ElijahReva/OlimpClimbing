using System;

namespace OlimClimbing.Phones
{
    public static class Program
    {
        public class Node
        {
            public bool IsDialed;
            public Node[] Child;
        }

        public class DigitalTree
        {
            private readonly Node root = new Node();

            public bool Add(string number)
            {
                var currentNode = this.root;
                foreach (var digit in number)
                {
                    var intedChar = digit & 0x0f;
                    //Create node for adding
                    var nodeToAdd = new Node();

                    //No nodes
                    if (currentNode.Child == null)
                    {
                        currentNode.Child = new Node[10];
                        currentNode.Child[intedChar] = nodeToAdd;
                        currentNode = nodeToAdd;
                        continue;
                    }

                    //Get node
                    Node finded = currentNode.Child[intedChar];
                    if (finded != null)
                    {
                        //Checks for already called number
                        if (finded.IsDialed)
                        {
                            return false;
                        }
                        currentNode = finded;
                    }
                    else
                    {
                        currentNode.Child[intedChar] = nodeToAdd;
                        currentNode = nodeToAdd;
                    }
                }
                if (currentNode.Child != null)
                {
                    return false;
                }
                currentNode.IsDialed = true;
                return true;
            }
        }

        private static int totalCases;
        private static int totalNumbers;
        private static DigitalTree tree;
        private static bool broken;

        private static void Main(string[] args)
        {
            totalCases = int.Parse(Console.ReadLine());
            for (var i = 0; i < totalCases; i++)
            {
                totalNumbers = int.Parse(Console.ReadLine());
                tree = new DigitalTree();
                broken = false;
                for (var j = 0; j < totalNumbers; j++)
                {
                    if (broken)
                    {
                        Console.ReadLine();
                        continue;
                    }
                    if (tree.Add(Console.ReadLine())) continue;
                    broken = true;
                    Console.WriteLine("NO");
                }
                if (!broken)
                {
                    Console.WriteLine("YES");
                }
            }
        }
    }
}