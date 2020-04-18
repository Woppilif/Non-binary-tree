using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ListTrees
{
    class Element
    {
        public int MyProperty { get; private set; }
        public Element(int x)
        {
            MyProperty = x;
        }

        public override string ToString()
        {
            return MyProperty.ToString();
        }

        //public override bool Equals(object obj)
        //{
        //    var temp = obj as Element;
        //    if (temp.MyProperty == this.MyProperty) return true;
        //    return false;
        //}

        //public override int GetHashCode()
        //{
        //    return this.MyProperty.GetHashCode();
        //}
    }
}
