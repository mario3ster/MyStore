using System.Collections.Generic;
using MyStore.Domain.Nomenclatures;

namespace MyStore.Domain.Operations
{
    public class SaleOperationDescriptor : OperationDescriptor
    {
        public SaleOperationDescriptor(IStore store, 
            IUser user, 
            ICollection<OperationalItem> items)
            : base (store, user, items)
        {
        }
    }
}