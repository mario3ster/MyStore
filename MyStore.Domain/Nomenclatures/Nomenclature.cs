namespace MyStore.Domain.Nomenclatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Nomenclature<TEntity> where TEntity : NomenclatureEntity
    {
        private ICollection<TEntity> entities;

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
            return Entities.Where(unit => unit.Code == code).First();
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

            if(entity is null) 
            {
                throw new ArgumentException("There is no entity with this code in the nomenclature");
            }

            entity.IsDeleted = true;
        }
    }
}