namespace MyStore.Tests.Domain.Nomenclatures
{
    using NUnit.Framework;
    using MyStore.Domain.Nomenclatures;
    using MyStore.Tests.Utilities;
    using System.Linq;
    using System.Collections.Generic;
    using MyStore.Domain.Exceptions;
    using System;

    public class NomenclaturesTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void When_AddNewItem_Expect_ToHaveItInTheNomenclature()
        {
            // Arrange
            var items = new Nomenclature<Item>();             
            var item = NomenclatureEntityGenerator<Item>.GenerateOne();

            // Act            
            items.Add(item);

            //Assert
            var itemCode = item.Code;
            Assert.AreEqual(1, items.Count);
            Assert.AreEqual(item, items.GetByCode(itemCode));
        }

        [Test]
        public void When_AddCoupleOfItems_Expect_ToGetThemBackOrdered()
        {            
            var nom = new Nomenclature<Item>();             
            var items = NomenclatureEntityGenerator<Item>.GenerateMany(3).Select(x => x).ToList();
         
            nom.AddMany(items);

            byte numberOfItemsGenerated = 3;
            ICollection<Item> nomenclatureEntities = nom.GetEntities((0, numberOfItemsGenerated));

            Assert.AreEqual(nomenclatureEntities.Count, numberOfItemsGenerated);

            for (int i = 1; i < numberOfItemsGenerated; i++)
            {
                Assert.Less(nomenclatureEntities.ElementAt(i - 1).Priority, nomenclatureEntities.ElementAt(i).Priority);
            }            
        }

         [Test]
        public void When_IDeleteItem_Expect_ToBeOutOfScope()
        {
            var nomenclature = new Nomenclature<Item>();             
            var items = NomenclatureEntityGenerator<Item>.GenerateMany(5).Select(x => x).ToList();
                               
            nomenclature.AddMany(items);
            nomenclature.DeleteItem(items.Last().Code);
       
            Assert.AreEqual(4, nomenclature.Count);
        }
    
        [Test]
        public void When_AddDuplicateEntities_Expect_DuplicateNomenclatureEntityException()
        {
            var nomenclature = new Nomenclature<Item>();             
            var item = NomenclatureEntityGenerator<Item>.GenerateOne();
                                 
            nomenclature.Add(item);            
        
            Assert.Catch(typeof(DuplicateNomenclatureEntityException), () => nomenclature.Add(item));
        }

        [Test]
        public void When_TryToGetEntityByNullCode_Expect_ArgumentException()
        {
            var nomenclature = new Nomenclature<Item>();            
        
            Assert.Catch(typeof(ArgumentException), () => nomenclature.GetByCode(null));
        }

        [Test]
        public void When_AddNewSupplier_Expect_ToHaveItInTheNomenclature()
        {
            var suppliers = new Nomenclature<Supplier>(); 
            var supplier = NomenclatureEntityGenerator<Supplier>.GenerateOne();

            suppliers.Add(supplier);
         
            string supplierCode = supplier.Code;
            Assert.AreEqual(1, suppliers.Count);
            Assert.AreEqual(supplier, suppliers.GetByCode(supplierCode));
        }

         [Test]
        public void When_AddCoupleOfSuppliers_Expect_ToGetThemBack()
        {
            var suppliers = new Nomenclature<Supplier>();             
            var suppliersList = NomenclatureEntityGenerator<Supplier>.GenerateMany(4).Select(x => x).ToList();

            suppliers.AddMany(suppliersList);

            var numUnitsInNomenclature = suppliers.GetEntities((0, 4)).Count;
            Assert.AreEqual(4, numUnitsInNomenclature);
        }

        [Test]
        public void When_TryToTakeOutFromWarehouseMoreThanAvailable_Expect_Exception()
        {
            String itemCode = "item501.5";
            IStore store = new Store("store02");

            store.AddToWarehouse(itemCode, 100); 

            Assert.Catch(typeof(OutOfStockException), () => store.TakeOutOfWarehouse(itemCode, 101));
        }
    }
}