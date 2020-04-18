using System;
using System.Collections;
using System.Collections.Generic;

namespace ListTreesLibrary
{
    public class Tree<T> : IEnumerable<T>
    {
        public CustomList<Parent<T>> vs = new CustomList<Parent<T>>();

        public void Add(T item, T parent)
        {
            if (vs.Value == null)
            {
                vs.Append(new Parent<T>(parent));
                return;
            }
            var citem = vs.Search(new Parent<T>(parent));
            if (citem == null)
            {
                Child<T> tempChild = new Child<T>(parent);
                foreach (var parent1 in vs)
                {
                    var res = parent1.Children.Search(tempChild);
                    if (res != null)
                    {
                        Parent<T> parent2 = new Parent<T>(parent);
                        vs.Append(parent2);
                        parent2.Children.Append(new Child<T>(item));
                        return;
                    }
                }
                return;
            }
            citem.Value.Children.Append(new Child<T>(item));
            return;
        }

        public T Search(T item)
        {
            var citem = vs.Search(new Parent<T>(item));
            if (citem == null)
            {
                Child<T> tempChild = new Child<T>(item);
                foreach (var parent1 in vs)
                {
                    var res = parent1.Children.Search(tempChild);
                    if (res != null)
                    {
                        return res.Value.Value;
                    }
                }
            }
            else
                return citem.Value.Value;
            return default;
        }

        public void Delete(T item)
        {
            var citem = vs.Search(new Parent<T>(item));
            if(citem == null)
            {
                Child<T> tempChild = new Child<T>(item);
                foreach (var parent1 in vs)
                {
                    if (parent1 == null) continue;
                    var res = parent1.Children.Search(tempChild);
                    if (res != null)
                    {
                        res.Delete(tempChild);
                        return;
                    }
                }
                return;
            }
            //Для удаления с конца
            var temp = citem.Value.Children;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            while(temp != null)
            {
                Delete(temp.Value.Value);
                temp = temp.Prev;
            }
            //Для удаления с конца END
            vs.Delete(new Parent<T>(item));
            Delete(item);
            return;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
