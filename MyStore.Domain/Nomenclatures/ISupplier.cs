namespace MyStore.Domain.Nomenclatures
{
    public interface ISupplier
    {
        int Id { get; set; }
         string Name { get; set; }
         string Address { get; set; }
         string Phone { get; set; }
         int CategoryID { get; set; }
    }
}