namespace MyStore.Tests.Nomenclatures
{
    using System;
    using NUnit.Framework;
    using MyStore.Domain.Nomenclatures;
    using System.Linq;

    public class NomenclaturesTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void When_AddNewItem_Expect_ToBePersisted()
        {
            // Arrange
            var items = new Nomenclature<Item>(); 

            var item = new Item { 
                Name = "Yogurt", 
                Code = "yog101",
                Barcode = "123456789",
                Description = "Desc", 
                Brand = "Danone", 
                Picture = ""
            };

            // Act
            items.Add(item);

            //Assert
            Assert.AreEqual(items.Count, 1);
            Assert.AreEqual(item, items.GetByCode("yog101"));
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
            Assert.AreEqual(stores.Count, 1);
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
            Assert.AreEqual(suppliers.Count, 1);
        }
    }
}