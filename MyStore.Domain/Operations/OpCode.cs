namespace MyStore.Domain.Operations
{
    using System;
    
     /// Represents abstract identifier wrapper
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
