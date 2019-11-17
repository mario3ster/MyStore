namespace MyStore.Tests.Domain.Operations
{
    using NUnit.Framework;
    using MyStore.Domain.Nomenclatures;
    using MyStore.Domain.Operations;
    using System.Collections.Generic;
    using MyStore.Tests.Utilities;

    public class OperationsTests
    {
        [Test]
        public void When_DeliverItems_Expect_ToHaveThemInStock()
        {
            IUser user = NomenclatureEntityGenerator<User>.GenerateOne();;
            IStore store = new Store("Store02");
            ISupplier supplier = new Supplier("Supplier02");

            string[] itemCodes = new string[2] { "item501.5", "item404.4" };
            
            var deliveredItems = new List<OperationalItem>()
                            {
                                new OperationalItem()
                                {
                                    Code = itemCodes[0],
                                    Qtty = 120,
                                    Measure = Measure.Qtty, // To do: measurement based on strategy
                                    Price = 0.75m,
                                    Currency = "BGN"
                                },
                                new OperationalItem()
                                {
                                    Code = itemCodes[1],
                                    Qtty = 50,
                                    Measure = Measure.Qtty,
                                    Price = 1.45m,
                                    Currency = "BGN"
                                }
                            };
            var opDescriptor = new DeliveryOperationDescriptor(supplier, store, user, deliveredItems);
            Operation delivery = new Delivery(opDescriptor);
            
            delivery.UpdateStore();

            Assert.AreEqual(120, store.CheckAvailability(itemCodes[0]));
            Assert.AreEqual(50, store.CheckAvailability(itemCodes[1]));
        }

        [Test]
        public void When_Sale_Expect_DecreasedQttiesInStore()
        {
            IUser user = NomenclatureEntityGenerator<User>.GenerateOne();;
            IStore store = new Store("Store02");

            string[] itemCodes = new string[2] { "item501.5", "item404.4" };

            store.AddToWarehouse(itemCodes[0], 100);
            store.AddToWarehouse(itemCodes[1], 100);        
            
            var itemsForSale = new List<OperationalItem>()
                            {
                                new OperationalItem()
                                {
                                    Code = itemCodes[0],
                                    Qtty = 2,
                                    Measure = Measure.Qtty, 
                                    Price = 0.75m,
                                    Currency = "BGN"
                                },
                                new OperationalItem()
                                {
                                    Code = itemCodes[1],
                                    Qtty = 4,
                                    Measure = Measure.Qtty,
                                    Price = 1.45m,
                                    Currency = "BGN"
                                }
                            };

            IOperationDescriptor opDescriptor = new SaleOperationDescriptor(store, user, itemsForSale);
            var sale = new Sale(opDescriptor);

            sale.UpdateStore();
        
            Assert.AreEqual(98, store.CheckAvailability(itemCodes[0]));
            Assert.AreEqual(96, store.CheckAvailability(itemCodes[1]));
        }

    //     [Test]
    //     public void When_MakeSalesOperations_Expect_ToBePersisted()
    //     {
    //         // To do: Add 3 Sale operations

    //         IOperationDescriptor opDescriptor = new SaleOperationDescriptor(store, user, itemsForSale);
    //         var sale = new Sale(opDescriptor);
    //         var persistenceManager = new PersistenceManager();
    //         var reportManager = new ReportManager();

            
    //         sale.UpdateStore();

    //         // Issue transaction about: 
    //         // 1. The sale operation and: 
    //         // 2. Associated payment; 
    //         // 3. The changes in the warehouse;
    //         var opCode = persistenceManager.Commit(sale); 

    //         Assert.NotNull(opCode);
    //         Assert.AreEqual(3, reportManager.GetOperations(typeof(Sale)));
    //     }
    }
}