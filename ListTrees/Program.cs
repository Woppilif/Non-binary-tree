using System;
using ListTreesLibrary;
namespace ListTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random(11111);
            Tree<int> vs = new Tree<int>
            {
                { 1, 1 },
                { 2, 1 },
                { 3, 1 },
                { 4, 2 },
                { 5, 2 },
                { 55, 2 },
                { 56, 2 },
                { 6, 3 },
                { 7, 3 },
                { 8, 4 },
                { 9, 4 },
                { 10, 5 },
                { 11, 5 },

                { 110, 55 },
                { 111, 55 },
                { 210, 56 },
                { 211, 56 }
            };

            int root, times;
            while (true)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "a":
                        root = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(">");
                        times = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < times; i++)
                        {
                            vs.Add(
                                random.Next(root * 10, root * 10 * 4),
                                root
                            );
                        }
                        Console.WriteLine("ok");
                        break;
                    case "o":
                        foreach (var item in vs.vs)
                        {
                            if (item != null)
                            {
                                Console.WriteLine($"p: {item.Value}");
                                foreach (var child in item.Children)
                                {
                                    if (child != null)
                                        Console.WriteLine($"\t{child.Value}");
                                }
                            }
                        }
                        break;
                    case "d":

                        vs.Delete(
                        Convert.ToInt32(Console.ReadLine())
                        );


                        break;
                    case "s":
                        Console.WriteLine(
                            vs.Search(
                            Convert.ToInt32(Console.ReadLine())
                            )

                            );
                        break;

                }
            }

        }
    }
}
