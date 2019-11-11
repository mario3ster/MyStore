namespace MyStore.Domain.Nomenclatures
{
    using System.Collections.Generic;

    public class Item : INomenclatureUnit
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        public string Brand { get; set; }
    }
}