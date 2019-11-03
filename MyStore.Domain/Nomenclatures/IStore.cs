namespace MyStore.Domain.Nomenclatures
{
    public interface IStore
    {
         int Id { get; set; }
         string Name { get; set; }
         string Description { get; set; }
         string Address { get; set; }
         string Phone { get; set; }
         int CategoryID { get; set; }
    }
}