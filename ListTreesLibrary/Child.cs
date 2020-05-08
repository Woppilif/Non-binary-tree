using System;
using System.Collections.Generic;

namespace ListTreesLibrary
{
    /// <summary>
    /// Класс сущности потомка
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Child<T> 
    {
        public T Value { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="value">Любые типы данных</param>
        public Child(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Переопределяем метод для сравнения объектов.
        /// </summary>
        /// <param name="obj">Входной параметр - сравниваемый объект</param>
        /// <returns>возвращаем булевый результат</returns>
        public override bool Equals(object obj)
        {
            var temp = obj as Child<T>;
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
