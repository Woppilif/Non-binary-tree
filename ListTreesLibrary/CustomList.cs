using System;
using System.Collections;
using System.Collections.Generic;

namespace ListTreesLibrary
{
    public class CustomList<TItem> : IEnumerable<TItem>
    {
        public TItem Value { get; set; }
        public CustomList<TItem> Next { get; set; }
        public CustomList<TItem> Prev { get; set; }
        public CustomList()
        {
            Value = default;
            Next = null;
            Prev = null;
        }
        public CustomList(TItem item)
        {
            Value = item;
            Next = null;
            Prev = null;
        }
        public CustomList<TItem> Append(TItem value)
        {
            CustomList<TItem> currentValue = this;
            if(currentValue.Prev == null && (currentValue.Value == null || currentValue.Value.Equals(default))) //&& 
            {
                currentValue.Value = value;
                return currentValue;
            }
            if (currentValue.Next == null)
            {
                CustomList<TItem> item = new CustomList<TItem>(value);
                currentValue.Next = item;
                item.Prev = currentValue;
                return currentValue;
            }
            currentValue.Next.Append(value);
            return null;
        }

        public CustomList<TItem> Search(TItem value)
        {
            CustomList<TItem> currentValue = this;
            while(currentValue != null)
            {
                if (currentValue.Value == null) return null;
                if (currentValue.Value.Equals(value)) return currentValue;
                currentValue = currentValue.Next;
            }
            return null;
        }

        public bool Delete(TItem value)
        {
            CustomList<TItem> currentValue = Search(value);
            if (currentValue == null) return false;
            if (currentValue.Value.Equals(value))
            {
                if (currentValue.Prev == null)
                {
                    if (currentValue.Next != null)
                    {
                        currentValue.Value = currentValue.Next.Value;
                        DeleteLinks(currentValue.Next);
                    }
                    else
                        currentValue.Value = default;
                    return true;
                }
                DeleteLinks(currentValue);
                return true;
            }
            return true;
        }
        private bool DeleteLinks(CustomList<TItem> currentValue)
        {
            if (currentValue.Next != null)
                currentValue.Next.Prev = currentValue.Prev;
            if (currentValue.Prev != null)
                currentValue.Prev.Next = currentValue.Next;
            return true;
        }
        IEnumerator<TItem> IEnumerable<TItem>.GetEnumerator()
        {
            yield return this.Value;

            if (this.Next != null)
            {
                foreach(TItem item in this.Next)
                {
                    yield return item;
                }
            }
            
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        } 
    }
}
