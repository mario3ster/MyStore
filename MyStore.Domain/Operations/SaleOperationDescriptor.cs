using System.Collections.Generic;

namespace MyStore.Domain.Operations
{
    public class SaleOperationDescriptor : IOperationDescriptor
    {
        public SaleOperationDescriptor(ICollection<OperationalItem> items)
        {
            this.Items = items;
        }

        public ICollection<OperationalItem> Items { get; private set; }
    }
}