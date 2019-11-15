namespace MyStore.Domain.Exceptions
{
    using System;
    
    public class DuplicateNomenclatureEntityException : ApplicationException
    {        
        public DuplicateNomenclatureEntityException() : base ("Entity already exists in the nomenclature.")
        {            
        }
    }
}