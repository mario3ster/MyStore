namespace MyStore.Domain.Nomenclatures
{
    public abstract class NomenclatureEntity
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual int Priority { get; set; }
    }
}