namespace MyStore.Tests.Utilities
{
    using System;
    using System.Collections.Generic;
    using MyStore.Domain.Nomenclatures;

    internal static class NomenclatureEntityGenerator<TEntity> where TEntity : NomenclatureEntity, new()
    {
        private static int priorityIncrementor = 0;

        internal static TEntity GenerateOne()
        {
            priorityIncrementor++;

            return new TEntity()
            {
                Name = NomenclatureAttrGenerator.GetRandomName(),
                Code = NomenclatureAttrGenerator.GetRandomCode(),
                Priority = priorityIncrementor,
                IsDeleted = false                
            };            
        }

        internal static IEnumerable<TEntity> GenerateMany(byte numOfEntities)
        {            
            for(int i = 0; i < numOfEntities; i++)
            {
                yield return GenerateOne(); 
            }            
        }
    }

    internal static class NomenclatureAttrGenerator
    {
        internal static string GetRandomName()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 8);
        }

        internal static string GetRandomCode()
        {
            return Guid.NewGuid().ToString();
        }
    }
}