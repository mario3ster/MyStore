namespace MyStore.Tests.Nomenclatures
{
    using System;
    using NUnit.Framework;
    using MyStore.Domain.Nomenclatures;

    public class NomenclaturesTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckIfCanAddItemToNewNumenclature()
        {
            // Arrange
            var items = new Nomenclature<Item>(); 

            var item = new Item { 
                Id = 1,
                Name = "Item 1", 
                Code = "x1001",
                Barcode = "123456789",
                Description = "Desc", 
                Picture = "", 
                CategoryID = 1,
                Priority = 1,
                SuppliersId = new int[] { 1, 2, 3 }, 
                IsDeleted = false
            };

            // Act
            items.Add(item);

            //Assert
            Assert.AreEqual(items.Entities.Count, 1);
        }
    
        [Test]
        public void CheckIfCanAddStoreToNewNomenclature()
        {
            var stores = new Nomenclature<Store>(); 

            var store = new Store() { 
                Id = 1, 
                Name = "Store One", 
                Description = "Store One Desc", 
                Address = "606-3727 Ullamcorper. StreetRoseville NH 11523", 
                Phone = "+359 9902020929", 
                CategoryID = 1,
                IsDeleted = false
            };

            // Act
            stores.Add(store);

            //Assert
            Assert.AreEqual(stores.Entities.Count, 1);
        }

        [Test]
        public void CheckIfCanAddSupplierToNewNomenclature()
        {
            var suppliers = new Nomenclature<Supplier>(); 

            var supplier = new Supplier() { 
                Id = 1,
                Name = "Supplier One", 
                Address = "Hiroko Potter P.O. Box 887 2508 Dolor. Av.Muskegon KY 12482", 
                Phone = "+359 2222222222", 
                CategoryID = 1,
                IsDeleted = false
            };

            // Act
            suppliers.Add(supplier);

            //Assert
            Assert.AreEqual(suppliers.Entities.Count, 1);
        }
    }
}