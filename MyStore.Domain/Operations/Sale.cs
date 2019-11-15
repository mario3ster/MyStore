namespace MyStore.Domain.Operations
{
    using MyStore.Domain.Nomenclatures;
    
    public class Sale : Operation, IActiveOperation
    {    
        public OpCode Commit(IStore store, IOperationDescriptor descriptor)
        {        
            foreach (var item in descriptor.Items)
            {
                 store.TakeOutOfWarehouse(item.Code, item.Qtty);
            }
           
           return new OpCode(1);
        }
    }
}