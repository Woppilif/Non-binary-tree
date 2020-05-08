using System;
using System.Collections.Generic;

namespace ListTreesLibrary
{
    /// <summary>
    /// Родительский класс, содержащий поле для значения и список  его потомков
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Parent<T> 
    {
        public T Value { get; set; }

        public CustomList<Child<T>> Children;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="value">Любые типы данных</param>
        public Parent(T value)
        {
            Value = value;
            Children = new CustomList<Child<T>>();
        }

        /// <summary>
        /// Переопределяем метод для сравнения объектов.
        /// </summary>
        /// <param name="obj">Входной параметр - сравниваемый объект</param>
        /// <returns>возвращаем булевый результат</returns>
        public override bool Equals(object obj)
        {
            var temp = obj as Parent<T>;
            if (temp == null) return false;
            if (temp.Value.ToString() == this.Value.ToString()) return true;
            return false;
        }

        /// <summary>
        /// Переопределяем этот метод для сравнения значений объектов, а не ссылок на них
        /// </summary>
        /// <returns>целое число - хеш код</returns>
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
