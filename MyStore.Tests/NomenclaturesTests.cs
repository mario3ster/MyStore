namespace MyStore.Tests.Nomenclatures
{
    using System;
    using NUnit.Framework;
    using MyStore.Domain.Nomenclatures;
    using System.Linq;
    using MyStore.Tests.Utilities;

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
            var item = ItemsGenerator.GenerateOne();

            // Act            
            items.Add(item);

            //Assert
            Assert.AreEqual(items.Count, 1);
            Assert.AreEqual(item, items.GetByCode("yog101"));
        }

        public void When_AddCoupleOfItems_Expect_ToGetThemBackOrdered()
        {
            // Arrange
            var nom = new Nomenclature<Item>();             
            var items = ItemsGenerator.GenerateMany(3);

            // Act            
            nom.AddMany(items);

            //Assert
            var numUnitsInNomenclature = nom.GetUnits(1, 3).Count;
            Assert.AreEqual(numUnitsInNomenclature, 3);
        }
    
        [Test]
        public void When_AddNewStore_Expect_ToBePersisted()
        {
            var stores = new Nomenclature<Store>(); 

            var store = new Store() {                
                Name = "Store One", 
                Code = UnitCodeGenerator.GetRandomCode(), 
                Description = "Store One Desc", 
                Address = "606-3727 Ullamcorper. StreetRoseville NH 11523", 
                Phone = "+359 9902020929", 
                Priority = 1,
                IsDeleted = false
            };

            // Act
            stores.Add(store);

            //Assert
            Assert.AreEqual(stores.Count, 1);
        }

        [Test]
        public void When_AddNewSupplier_Expect_ToBePersisted()
        {
            var suppliers = new Nomenclature<Supplier>(); 

            var supplier = new Supplier() {                 
                Name = "Supplier One", 
                Code = UnitCodeGenerator.GetRandomCode(), 
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