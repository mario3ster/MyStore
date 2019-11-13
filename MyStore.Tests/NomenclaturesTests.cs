namespace MyStore.Tests.Nomenclatures
{
    using NUnit.Framework;
    using MyStore.Domain.Nomenclatures;
    using MyStore.Tests.Utilities;
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
            var item = NomenclatureEntityGenerator<Item>.GenerateOne();

            // Act            
            items.Add(item);

            //Assert
            var itemCode = item.Code;
            Assert.AreEqual(items.Count, 1);
            Assert.AreEqual(item, items.GetByCode(itemCode));
        }

        [Test]
        public void When_AddCoupleOfItems_Expect_ToGetThemBackOrdered()
        {
            // Arrange
            var nom = new Nomenclature<Item>();             
            var items = NomenclatureEntityGenerator<Item>.GenerateMany(3).Select(x => x).ToList();

            // Act            
            nom.AddMany(items);

            //Assert
            byte numberOfItemsGenerated = 3;
            var nomenclatureEntities = nom.GetEntities((0, numberOfItemsGenerated));

            Assert.AreEqual(nomenclatureEntities.Count, numberOfItemsGenerated);

            for (int i = 1; i < numberOfItemsGenerated; i++)
            {
                Assert.Less(nomenclatureEntities.ElementAt(i - 1).Priority, nomenclatureEntities.ElementAt(i).Priority);
            }
            
        }

         [Test]
        public void When_HasLogicallyDeletedItems_Expect_ToBeOutOfScope()
        {
            // Arrange
            var nomenclature = new Nomenclature<Item>();             
            var items = NomenclatureEntityGenerator<Item>.GenerateMany(5).Select(x => x).ToList();
                       
            // Act            
            nomenclature.AddMany(items);
            nomenclature.DeleteItem(items.Last().Code);

            //Assert            
            Assert.AreEqual(nomenclature.Count, 4);
        }
    
        [Test]
        public void When_AddNewSupplier_Expect_ToBePersisted()
        {
            var suppliers = new Nomenclature<Supplier>(); 
            var supplier = NomenclatureEntityGenerator<Supplier>.GenerateOne();

            suppliers.Add(supplier);
         
            string supplierCode = supplier.Code;
            Assert.AreEqual(suppliers.Count, 1);
            Assert.AreEqual(supplier, suppliers.GetByCode(supplierCode));
        }

         [Test]
        public void When_AddCoupleOfSuppliers_Expect_ToGetThemBack()
        {
            var suppliers = new Nomenclature<Supplier>();             
            var suppliersList = NomenclatureEntityGenerator<Supplier>.GenerateMany(4).Select(x => x).ToList();

            suppliers.AddMany(suppliersList);

            var numUnitsInNomenclature = suppliers.GetEntities((0, 4)).Count;
            Assert.AreEqual(numUnitsInNomenclature, 4);
        }
    
    }
}