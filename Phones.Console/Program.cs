using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OlimClimbing.Phone
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

        private static void Main(string[] args)
        {
            //var lines = File.ReadAllLines("phone.in").ToList();
            List<string> lines = new List<string>();
            string l;
            while ((l = Console.ReadLine()) != null)
            {

                lines.Add(l);
            }


            var testCasesCount = int.Parse(lines[0]);//[0] & 0x0f;
            int totalLinesReaded = 0;

            for (int i = 0; i < testCasesCount; i++)
            {
                var currentHeadOfTestCase = totalLinesReaded + i + 1;
                var phonesCount = int.Parse(lines[currentHeadOfTestCase]);
                totalLinesReaded += phonesCount;
                var tree = new DigitalTree();
                bool broken = false;
                for (int j = 0; j < phonesCount; j++)
                {                                                        
                    if (tree.Add(lines[currentHeadOfTestCase + 1 + j])) continue;
                    broken = true;
                    break;
                }
                if (broken)
                {
                    Console.WriteLine("NO");
                    continue;
                }
                Console.WriteLine("YES");
                
            }
            //Console.ReadKey();
        } 
    }
}