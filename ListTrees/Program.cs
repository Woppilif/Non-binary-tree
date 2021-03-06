﻿using System;
using System.Linq;
using System.Text.Json;
using ListTreesLibrary;
using Newtonsoft.Json;

namespace ListTrees
{
    class Program
    {
        //static Tree<Element> vs = new Tree<Element>();
        static void Main(string[] args)
        {
            Tree<Element> vs = new Tree<Element>();
            vs.Add(new Element("Hello_1"), new Element("Hello_1"));
            vs.Add(new Element("Hello_2"), new Element("Hello_1"));
            vs.Add(new Element("Hello_3"), new Element("Hello_1"));

            var jsonUtf8Bytes = JsonConvert.SerializeObject(vs);
            Console.WriteLine(jsonUtf8Bytes);
            System.IO.File.WriteAllText(@"path.txt", jsonUtf8Bytes);
            //Console.ReadKey();
            var x = JsonConvert.DeserializeObject<Tree<Element>>(jsonUtf8Bytes);
            Console.ReadKey();
            foreach (var item in x.vs)
            {
                Console.WriteLine($"Parent {item.Value}");

                Console.WriteLine("Children:");
                foreach (var item2 in item.Children)
                {
                    if (item2 != null)
                    {
                        Console.WriteLine(item2.Value);
                    }
                }

            }

            //Random random = new Random(1111);
            //for (int i = 0; i < 10; i++)
            //{
            //    for (int x = 0; x < 10; x++)
            //    {
            //        Add($"Hello_{x}", $"Hello_{i}");
            //    }

            //}



            //Out();

            ////Console.WriteLine("delete------------------------------------");

            //vs.Delete(vs.Search(new Element("Hello_9")));
            //Out();

            //vs.Delete(vs.Search(new Element("Hello_7")));
            //Out();

            //Add($"Hello_9", $"Hello_6");
            //Console.WriteLine("------------------------------------");
            //Out();

            //Console.WriteLine("------------------------------------");
            //vs.Delete(vs.Search(new Element("Hello_6")));
            //Out();


        }

        //static void Out()
        //{
        //    foreach (var item in vs.vs)
        //    {
        //        Console.WriteLine($"Parent {item.Value.MyProperty.Name}");

        //        Console.WriteLine("Children:");
        //        foreach (var item2 in item.Children)
        //        {
        //            if (item2 != null)
        //            {
        //                Console.WriteLine(item2.Value.MyProperty.Name);
        //            }
        //        }

        //    }
        //}

        //static void Add(string child, string parent)
        //{
        //    var el = new Element(child);
        //    var p = new Element(parent);
        //    var s = vs.Search(el);
        //    if (s == null)
        //    {
        //        var res = vs.Add(el, p);
        //        if (res == false)
        //        {
        //            Console.WriteLine($"false w {p} & {el}");
        //        }
        //    }
        //}


    }
}
