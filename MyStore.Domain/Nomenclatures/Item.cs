namespace MyStore.Domain.Nomenclatures
{
    public class Item : NomenclatureEntity
    {      
        public string Barcode { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public string Brand { get; set; }     
    }
}