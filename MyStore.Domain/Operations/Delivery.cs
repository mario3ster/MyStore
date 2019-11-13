using System;

namespace MyStore.Domain.Operations
{
    using MyStore.Domain.Nomenclatures;
    using MyStore.Domain.Payments;

    public class Delivery : IStoreOperation
    {
        public Delivery()
        {
        }

        public Supply Supply { get; set; }
        public User Operator { get; set; }
        public Store Store { get; set; }
        public Supplier Supplier { get; set; }
        public IPayment Payment { get; set; }
    }
}