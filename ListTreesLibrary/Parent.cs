using System;

namespace ListTreesLibrary
{
    public class Parent<T>
    {
        public T Value { get; set; }

        public CustomList<Child<T>> Children;

        public Parent(T value)
        {
            Value = value;
            Children = new CustomList<Child<T>>();
        }

        public override bool Equals(object obj)
        {
            var temp = obj as Parent<T>;
            if (temp == null) return false;
            if (temp.Value.GetHashCode() == this.Value.GetHashCode()) return true;
            return false;
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
