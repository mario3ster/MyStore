using System.Collections.Generic;
using MyStore.Domain.Nomenclatures;

namespace MyStore.Domain.Operations
{
    public interface IOperationDescriptor
    {
        IStore Store { get; }

        IUser Operator { get; }

        ICollection<OperationalItem> Items { get; }
    }

    public abstract class OperationDescriptor : IOperationDescriptor
    {
        public OperationDescriptor(IStore store, IUser user, ICollection<OperationalItem> items)
        {
            Store = store;
            Operator = user;
            Items = items;
        }

        public IStore Store { get; }

        public IUser Operator { get; }

        public ICollection<OperationalItem> Items { get; }
    }
}