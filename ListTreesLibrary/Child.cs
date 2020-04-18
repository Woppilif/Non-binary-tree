using System;

namespace ListTreesLibrary
{
    public class Child<T>
    {
        public T Value { get; set; }
        public Child(T value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            var temp = obj as Child<T>;
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
