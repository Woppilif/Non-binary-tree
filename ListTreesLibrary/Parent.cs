using System;

namespace ListTreesLibrary
{
    public class Parent<T>: IComparable<Parent<T>> 
    {
        public T Value { get; set; }

        public CustomList<Child<T>> Children;

        public Parent(T value)
        {
            Value = value;
            Children = new CustomList<Child<T>>();
        }

        int IComparable<Parent<T>>.CompareTo(Parent<T> other)
        {
            if (other == null) return 1;
            if (Value.Equals(other.Value)) return 0;
            return 1;
        }
    }
}
