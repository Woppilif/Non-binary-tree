using System;

namespace ListTreesLibrary
{
    public class Child<T> : IComparable<Child<T>>
    {
        public T Value { get; set; }
        public Child(T value)
        {
            Value = value;
        }
        int IComparable<Child<T>>.CompareTo(Child<T> other)
        {
            if (other == null) return 1;
            if (Value.Equals(other.Value)) return 0;
            return 1;
        }
    }
}
