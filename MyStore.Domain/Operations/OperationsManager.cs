namespace MyStore.Domain.Operations
{
    using MyStore.Domain.Nomenclatures;

    public class OperationsManager<TOperation, TOperationDescriptor> where TOperation : IOperation, new()
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

    public class OpCode
    {
        public OpCode(int statusCode)
        {
            StatusCode = statusCode;
        }
        public int StatusCode { get; private set; }
    }
}