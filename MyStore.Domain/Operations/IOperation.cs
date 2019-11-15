using MyStore.Domain.Nomenclatures;

namespace MyStore.Domain.Operations
{    
    public interface IOperation
    {
        OpCode Identifier { get; }
    }

    // No quantities updates into the store's warehouse
    public interface INeutralOperation : IOperation
    {
        OpCode Commit();
    }

    // Updates quantities into the warehouse
    public interface IActiveOperation : IOperation
    {
        OpCode Commit(IStore store, IOperationDescriptor descriptor);
    }
}