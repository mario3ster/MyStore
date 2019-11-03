namespace MyStore.Domain.Nomenclatures
{
    public class Supplier : ISupplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int CategoryID { get; set; }
        public bool IsDeleted { get; set; }
    }
}