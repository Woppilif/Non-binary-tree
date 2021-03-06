﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace ListTreesLibrary
{
    /// <summary>
    /// Основной класс, реализующий двунаправленный несвязный список
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public class CustomList<TItem> : IEnumerable<TItem>, ICollection<TItem>
    {
        public TItem Value { get; set; }
        public CustomList<TItem> Next { get; set; }
        public CustomList<TItem> Prev { get; set; }

        public int Count { get; set; }

        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public CustomList()
        {
            Value = default;
            Next = null;
            Prev = null;
        }

        /// <summary>
        /// Конструктор с параметром - входным значением любого типа
        /// </summary>
        /// <param name="item"></param>
        public CustomList(TItem item)
        {
            Value = item;
            Next = null;
            Prev = null;
        }

        /// <summary>
        /// Добавление в конец списка
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Созданный объект или null</returns>
        public CustomList<TItem> Append(TItem value)
        {
            CustomList<TItem> currentValue = this;
            if(currentValue.Prev == null && (currentValue.Value == null || currentValue.Value.Equals(default)))
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

        /// <summary>
        /// Поиск искомого объекта
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Удаление искомого объекта
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Удаление ссылочных связей между элементами списка
        /// </summary>
        /// <param name="currentValue"></param>
        /// <returns></returns>
        private bool DeleteLinks(CustomList<TItem> currentValue)
        {
            if (currentValue.Next != null)
                currentValue.Next.Prev = currentValue.Prev;
            if (currentValue.Prev != null)
                currentValue.Prev.Next = currentValue.Next;
            return true;
        }

        /// <summary>
        /// Итератор для прохода по элементам
        /// </summary>
        /// <returns></returns>
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
            yield return this.Value;

            if (this.Next != null)
            {
                foreach (TItem item in this.Next)
                {
                    yield return item;
                }
            }
        }

        public void Add(TItem item)
        {
            this.Append(item);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(TItem item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(TItem[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TItem item)
        {
            throw new NotImplementedException();
        }
    }
}
