namespace MyStore.Domain.Nomenclatures
{
    using System;
    using System.Collections.Generic;

    public class Nomenclature<T>
    {
        public ICollection<T> Entities { get; private set; }

        public Nomenclature()
        {
            Entities = new List<T>();
        }

        public void Add(T item)
        {
            Entities.Add(item);
        }
    }
}