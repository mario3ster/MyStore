namespace MyStore.Domain.Operations
{
    using System;
    
    public abstract class Operation
    {
        public OpCode Identifier
        {
            get
            {
                return new OpCode(Guid.NewGuid());
            }
        }
    }
}