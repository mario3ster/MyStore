namespace MyStore.Domain.Nomenclatures
{
    public class Supplier : NomenclatureEntity, ISupplier
    {

       public Supplier(string code)
       {
           Code = code;
       }
        public Supplier()
       {
         
       }

        public string Address { get; set; }
        public string Phone { get; set; }        
    }
}