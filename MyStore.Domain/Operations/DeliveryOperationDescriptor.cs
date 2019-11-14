namespace MyStore.Domain.Operations
{
    using System.Collections.Generic;

    public class DeliveryOperationDescriptor : IOperationDescriptor
    {
        private string supplierCode;

        public DeliveryOperationDescriptor(string supplierCode, ICollection<OperationalItem> items)
        {
            this.supplierCode = supplierCode;
            this.Items = items;
        }

        public ICollection<OperationalItem> Items { get; private set; }       
    }
}