namespace OlimClimbing.Phones
{
    public static class PhonesList
    {
        private sealed class Node
        {
            public bool IsDialed;
            public Node[] Child;
        }

        private static int totalCases;
        private static int totalNumbers;
        private static string number;
        private static bool broken;
        private static readonly Node root = new Node();
        private static Node currentNode = root;

        private static void Main()
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
                    currentNode = root;
                    number = System.Console.ReadLine();
                    for (byte index = 0; index < number.Length; index++)
                    {
                        //No nodes
                        var digit = number[index] & 0x0f;
                        if (currentNode.Child == null)
                        {
                            currentNode.Child = new Node[10];
                            currentNode = currentNode.Child[digit] = new Node();
                            continue;
                        }

                        //Get node
                        if (currentNode.Child[digit] == null)
                        {
                            currentNode = currentNode.Child[digit] = new Node();
                        }
                        else
                        {
                            //Checks for already called number
                            var node = currentNode.Child[digit];
                            if (node.IsDialed)
                            {
                                broken = true;
                            }
                            currentNode = node;
                        }
                    }
                    if (currentNode.Child != null)
                    {
                        broken = true;
                    }
                    currentNode.IsDialed = true;
                }
                System.Console.WriteLine(broken ? "NO" : "YES");
            }
        }
    }
}