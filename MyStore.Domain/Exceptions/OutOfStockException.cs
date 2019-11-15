namespace MyStore.Domain.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    
    [Serializable]
    public class OutOfStockException : ApplicationException
    {
        public OutOfStockException()
        {
        }

        public OutOfStockException(string message) : base(message)
        {
        }

        public OutOfStockException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OutOfStockException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}