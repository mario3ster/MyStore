using System;

namespace MyStore.Domain.Operations
{
    using MyStore.Domain.Nomenclatures;
    using MyStore.Domain.Payments;

    public class Delivery : IOperation
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