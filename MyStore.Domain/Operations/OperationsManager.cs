namespace MyStore.Domain.Operations
{
    using System;
    using MyStore.Domain.Nomenclatures;

    public class OperationsManager<TOperation, TOperationDescriptor> where TOperation : IActiveOperation, new()
                                                                     where TOperationDescriptor : IOperationDescriptor
    {
        private string userCode;
        private IStore store;
        private TOperationDescriptor opDescriptor;
        private TOperation executedOperation;

        public OperationsManager(string userCode, IStore store)
        {
            this.store = store;
            this.userCode = userCode;            
        }

        public TOperation CreateOperation(TOperationDescriptor opDescriptor)
        {
            this.opDescriptor = opDescriptor;

            executedOperation = new TOperation();

            return executedOperation;
        }

        public OpCode CommitOperation()
        {
            return executedOperation.Commit(store, opDescriptor);                        
        }
    }

    /// Represents ID of new commited operation
    public class OpCode
    {        
        private readonly object value;

        public OpCode(int value)
        {
            this.value = value;
        }

        public OpCode(Guid value)
        {
            this.value = value;
        }

        public object StatusCode 
        { 
            get
            {
                return value;
            }
        }
    }
}