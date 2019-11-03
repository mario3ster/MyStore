namespace MyStore.Domain.Operations
{
    using System;
    using MyStore.Domain.Operations;
    using System.Collections.Generic;

    public class OperationManager
    {
        private readonly List<IStoreOperation> operations;

        public OperationManager()
        {
            operations = new List<IStoreOperation>();
        }

        public ICollection<IStoreOperation> Operations 
        { 
            get
            {
                return operations;
            }
        }

        public void AddOperation(IStoreOperation delivery)
        {
            operations.Add(delivery);
        }

        public void CommitOperations()
        {
            //throw new NotImplementedException();
        }
    }
}