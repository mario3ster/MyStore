using System;

namespace MyStore.Domain.Exceptions
{
    public class DuplicateNomenclatureEntityException : ApplicationException
    {        
        public DuplicateNomenclatureEntityException() : base ("Entity already exists in the nomenclature.")
        {            
        }
    }
}