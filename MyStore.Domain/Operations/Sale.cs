using MyStore.Domain.Nomenclatures;

namespace MyStore.Domain.Operations
{
    public class Sale : IOperation
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