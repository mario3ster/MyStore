using System.Collections.Generic;

namespace MyStore.Domain.Operations
{
    public interface IOperationDescriptor
    {
        ICollection<OperationalItem> Items { get; }
    }
}