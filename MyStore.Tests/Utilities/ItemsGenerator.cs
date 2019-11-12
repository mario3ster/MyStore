namespace MyStore.Tests.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MyStore.Domain.Nomenclatures;

    internal static class ItemsGenerator
    {
        internal static Item GenerateOne()
        {
            return new Item
            {
                Name = "Yogurt",
                Code = UnitCodeGenerator.GetRandomCode(),
                Barcode = "123456789",
                Description = "Desc",                
                Picture = new byte[100],
                Priority = 1,
                IsDeleted = false
            };
        }

        internal static List<Item> GenerateMany(byte numOfItems)
        {            
            var items = Enumerable.Repeat<Item>(GenerateOne(), 3).ToList();         

            return items;
        }
    }

    internal static class UnitCodeGenerator
    {
        internal static string GetRandomCode()
        {
            return Guid.NewGuid().ToString();
        }
    }
}