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
        public IUser Operator { get; set; }
        public IStore Store { get; set; }
        public ISupplier Supplier { get; set; }
        public IPayment Payment { get; set; }
    }
}