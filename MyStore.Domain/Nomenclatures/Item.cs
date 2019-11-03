namespace MyStore.Domain.Nomenclatures
{
    using System.Collections.Generic;

    public class Item
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int CategoryID { get; set; }
        public int Priority { get; set; }
        public bool IsDeleted { get; set; }
        public int Id { get; set; }
        public ICollection<int> SuppliersId { get; set; }
    }
}