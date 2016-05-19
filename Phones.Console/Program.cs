namespace OlimClimbing.Phones
{            
    public static class Program
    {                   
        private sealed class Node
        {
            public bool IsDialed;
            public Node[] Child;
        }

        private static int totalCases;
        private static int totalNumbers;
        private static bool broken;
        private static readonly Node root = new Node();

        private static bool Add(string number)
        {
            var currentNode = root;
            for (int index = 0; index < number.Length; index++)
            {
                var digit = number[index];
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
                var finded = currentNode.Child[intedChar];
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

        private static void Main(string[] args)
        {
            totalCases = int.Parse(System.Console.ReadLine());
            for (var i = 0; i < totalCases; i++)
            {
                totalNumbers = int.Parse(System.Console.ReadLine());
                root.Child = null;
                broken = false;
                for (var j = 0; j < totalNumbers; j++)
                {
                    if (broken)
                    {
                        System.Console.ReadLine();
                        continue;
                    }
                    if (Add(System.Console.ReadLine())) continue;
                    broken = true;
                    System.Console.WriteLine("NO");
                }
                if (!broken)
                {
                    System.Console.WriteLine("YES");
                }
            }
        }
    }
}