using MyStore.Domain.Nomenclatures;

namespace MyStore.Domain.Operations
{
    public interface IOperation
    {
        OpCode Commit(IStore store, IOperationDescriptor descriptor);
    }
}