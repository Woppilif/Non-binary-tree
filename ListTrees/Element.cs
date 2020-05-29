
using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ListTrees
{
    
    class Element
    {
        [JsonProperty]
        public string MyProperty2 { get; private set; }
        public FileStream MyProperty { get; private set; }
        public Element(string name)
        {
            MyProperty2 = name;
            //MyProperty = CreateFile("files/"+name);
        }

        public Element()
        {

        }

        public override string ToString()
        {
            return MyProperty2.ToString();
        }

        public override int GetHashCode()
        {
            return MyProperty.Name.GetHashCode();
        }

        static FileStream CreateFile(string name)
        {
            using (FileStream fs = File.Create(name))
            {
                AddText(fs, "This is some text");
                AddText(fs, "This is some more text,");
                AddText(fs, "\r\nand this is on a new line");
                AddText(fs, "\r\n\r\nThe following is a subset of characters:\r\n");

                for (int i = 1; i < 120; i++)
                {
                    AddText(fs, Convert.ToChar(i).ToString());
                }
                return fs;
            }
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}
