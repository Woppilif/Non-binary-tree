using System;
using System.Collections;
using System.Collections.Generic;

namespace ListTreesLibrary
{
    /// <summary>
    /// Класс, реализующий работу структуры типа дерево с использованием списков
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Tree<T>
    {
        private IDeletable<T> _deletable { get; set; }

        /// <summary>
        /// Список всех родительских вершин
        /// </summary>
        public CustomList<Parent<T>> vs = new CustomList<Parent<T>>();

        /// <summary>
        /// Добавление в структуру новых элементов
        /// </summary>
        /// <param name="item">Добавляемый элемент</param>
        /// <param name="parent">Родитель, к которому элемент добавляется</param>
        public bool Add(T item, T parent)
        {
            if (vs.Value == null)
            {
                vs.Append(new Parent<T>(parent));
                return true;
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
                        return true;
                    }
                }
                return false;
            }
            citem.Value.Children.Append(new Child<T>(item));
            return true;
        }

        /// <summary>
        /// Поиск элемента
        /// </summary>
        /// <param name="item">Элемент, который необходимо найти</param>
        /// <returns>Найденный объект или его стандартное значение: 
        /// Для int - 0, для строки - empty.string для ссылочных типов - null</returns>
        public T Search(T item)
        {
            var citem = vs.Search(new Parent<T>(item));
            if (citem == null)
            {
                Child<T> tempChild = new Child<T>(item);
                foreach (var parent1 in vs)
                {
                    if (parent1 == null) continue;
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

        /// <summary>
        /// Удаление необходимого элемента
        /// </summary>
        /// <param name="item">Сам элемент</param>
        public void Delete(T item)
        {
            var citem = vs.Search(new Parent<T>(item));//Поиск элемента в списке родителей
            if(citem == null)//Иначе смотрим элемент в списке потомков
            {
                Child<T> tempChild = new Child<T>(item);
                foreach (var parent1 in vs)
                {
                    if (parent1 == null) continue;
                    var res = parent1.Children.Search(tempChild);
                    if (res != null)
                    {
                        res.Delete(tempChild);
                        _deletable.DeleteItem(tempChild.Value);
                        return;
                    }
                }
                return;
            }
            //Для удаления с конца
            //В некоторых ситуациях при удалении с головы, можно пропустить элементы
            //Те удаляем элемент, а расположенные элементы ниже (после него) могут остаться 
            //в списке родителей, если они таковыми были. Поэтому производим удаление с конца.
            var temp = citem.Value.Children;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            while (temp != null)
            {
                if (temp.Value == null) break;
                Delete(temp.Value.Value);
                temp = temp.Prev;
            }
            //Для удаления с конца END
            var let = new Parent<T>(item);
            vs.Delete(let);
            _deletable.DeleteItem(let.Value);
            Delete(item);
            return;
        }

        public void SetDeletable(IDeletable<T> item)
        {
            _deletable = item;
        }
    }
}
