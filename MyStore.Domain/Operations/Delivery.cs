namespace MyStore.Domain.Operations
{
    using MyStore.Domain.Nomenclatures;    

    public class Delivery : Operation, IActiveOperation
    {
        public OpCode Commit(IStore store, IOperationDescriptor descriptor)
        {
            foreach (var item in descriptor.Items)
            {
                 store.AddToWarehouse(item.Code, item.Qtty);
            }
           
           return new OpCode(1);
        }
    }
}