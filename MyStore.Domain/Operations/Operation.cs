namespace MyStore.Domain.Operations
{
    using System;
    
  public abstract class Operation : IOperation
    {
        public Operation(IOperationDescriptor operationDescriptor)
        { 
            OperationDescriptor = operationDescriptor;
        }

        public OpCode Identifier
        {
            get
            {
                return new OpCode(Guid.NewGuid());
            }
        }

        public IOperationDescriptor OperationDescriptor { get; }

        public abstract void UpdateStore();
    }
}