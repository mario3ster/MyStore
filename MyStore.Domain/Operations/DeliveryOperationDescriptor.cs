namespace MyStore.Domain.Operations
{
    using System.Collections.Generic;
    using MyStore.Domain.Nomenclatures;

    public class DeliveryOperationDescriptor : OperationDescriptor
    {
        private ISupplier supplier;

        public DeliveryOperationDescriptor(
            ISupplier supplier, 
            IStore store, 
            IUser user, 
            ICollection<OperationalItem> items) 
            : base (store, user, items)
        {
            this.supplier = supplier;
        }  
    }
}