using System;
using System.Runtime.Serialization;

namespace MyStore.Domain.Exceptions
{
    [Serializable]
    internal class OutOfStockException : ApplicationException
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