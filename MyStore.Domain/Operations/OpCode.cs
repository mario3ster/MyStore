namespace MyStore.Domain.Operations
{
    using System;
    
     /// Represents abstract app identifier
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

        public virtual object Value 
        { 
            get
            {
                return value;
            }
        }
    }
}
