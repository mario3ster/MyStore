using MyStore.Domain.Nomenclatures;
using MyStore.Domain.Operations;

namespace MyStore.Domain.Operations
{    
    public interface IOperation
    {
        OpCode Identifier { get; }

        IOperationDescriptor OperationDescriptor { get; }
    }

    
}

