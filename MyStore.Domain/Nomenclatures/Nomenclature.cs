namespace MyStore.Domain.Nomenclatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MyStore.Domain.Exceptions;

    public class Nomenclature<TEntity> where TEntity : NomenclatureEntity
    {
        private readonly ICollection<TEntity> entities;

        private ICollection<TEntity> Entities
        {
            get
            {
                return entities.Where(x => x.IsDeleted == false).ToList();                 
            }           
        }

        public Nomenclature()
        {
            entities = new List<TEntity>();
        }

        public void Add(TEntity item)
        {
            var entity = Entities.Where(unit => unit.GetHashCode() == item.GetHashCode()).FirstOrDefault();

            if(entity != null)
            {
                throw new DuplicateNomenclatureEntityException();
            }

            entities.Add(item);
        }

        public void AddMany(ICollection<TEntity> _entities)
        {
            foreach (var entity in _entities)
            {
                this.Add(entity);
            }
        }

        public long Count
        {
            get
            {
                return Entities.Count;
            }
        }

        public TEntity GetByCode(string code)
        {
            if(code is null)
            {
                throw new ArgumentException ("Nomenclature item code is required.");
            }

            TEntity foundEntity = Entities.Where(unit => unit.Code == code).FirstOrDefault();

            if(foundEntity is null) 
            {
                throw new ArgumentException("There is no entity with specified code in the nomenclature");
            }

            return foundEntity;
        }

        public ICollection<TEntity> GetEntities((int start, int end) range)
        {
            var units = Entities.Skip(range.start).Take(range.end - range.start)
                .OrderBy(x => x.Priority);

            return units.ToList();
        }     

        public void DeleteItem(string code)
        {
            var entity = this.GetByCode(code);            

            entity.IsDeleted = true;
        }
    }
}