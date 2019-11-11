namespace MyStore.Domain.Nomenclatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Nomenclature<T> where T : INomenclatureUnit
    {
        private ICollection<T> entities;

        public Nomenclature()
        {
            entities = new List<T>();
        }

        public void Add(T item)
        {
            entities.Add(item);
        }

        public long Count 
        { 
            get 
            {
                return entities.Count;
            }
        }

        public T GetByCode(string code)
        {
            return entities.Where(item => item.Code == code).First();
        }
    }
}