namespace MyStore.Domain.Operations
{
    using MyStore.Domain.Nomenclatures;


    public class Sale : Operation
    {
        public Sale(IOperationDescriptor opDescriptor)
           : base(opDescriptor)
        {
        }

        public override void UpdateStore()
        {
            foreach (var item in base.OperationDescriptor.Items)
            {
                base.OperationDescriptor.Store.TakeOutOfWarehouse(item.Code, item.Qtty);
            }
        }
    }
}