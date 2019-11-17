namespace MyStore.Domain.Operations
{
    using MyStore.Domain.Nomenclatures;    

    public class Delivery : Operation
    {
        public ISupplier Supplier { get; set; }

       public Delivery(IOperationDescriptor opDescriptor)
            : base(opDescriptor)
       {
       }

       public override void UpdateStore()
       {
            foreach (var item in base.OperationDescriptor.Items)
            {
                 base.OperationDescriptor.Store.AddToWarehouse(item.Code, item.Qtty);
            }
       }
    }
}