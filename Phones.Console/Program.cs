using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OlimClimbing.Phone
{
    public static class Program
    {
        public class Node
        {
            public Node(char value = default(char))
            {
                Digit = value;
            }

            public char Digit { get; private set; }
            public bool IsDialed { get; set; }
            public Dictionary<char, Node> Child { get; set; }


        }

        public class DigitalTree
        {


            private readonly Node root;

            public DigitalTree()
            {
                this.root = new Node();
            }

            public bool Add(string number)
            {
                var currentNode = root;
                foreach (var digit in number)
                {
                    //Create node for adding
                    var nodeToAdd = new Node(digit);

                    //No nodes
                    if (currentNode.Child == null)
                    {
                        currentNode.Child = new Dictionary<char, Node> { { digit, nodeToAdd } };
                        currentNode = nodeToAdd;
                        continue;
                    }

                    //Find node
                    Node finded;
                    if (currentNode.Child.TryGetValue(digit, out finded))
                    {
                        if (finded.IsDialed)
                        {
                            return false;
                        }
                        currentNode = finded;
                    }
                    else
                    {
                        currentNode.Child.Add(digit, nodeToAdd);
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


            List<string> lines = new List<string>();
            string l;
            while ((l = Console.ReadLine()) != null)
            {

                lines.Add(l);
            }


            var testCases = new List<string[]>();
            var testCasesCount = int.Parse(lines[0]);
            int totalStrreaded = 0;


            for (int i = 0; i < testCasesCount; i++)
            {
                var currentHeadOfTestCase = i + totalStrreaded + 1;
                var phonesCount = int.Parse(lines[currentHeadOfTestCase]);
                totalStrreaded += phonesCount;
                var testcase = new string[phonesCount];
                for (int j = 0; j < phonesCount; j++)
                {
                    testcase[j] = lines[currentHeadOfTestCase + 1 + j];
                }
                testCases.Add(testcase);
            }

            foreach (var testCase in testCases)
            {
                
                Console.WriteLine(Is(testCase) ? "YES" : "NO");
            }

            
        }

        public static bool Is(string[] phones)
        {
            var tree = new DigitalTree();
            return phones.All(p => tree.Add(p));
        }
    }
}