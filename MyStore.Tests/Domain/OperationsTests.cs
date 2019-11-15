namespace MyStore.Tests.Domain.Operations
{
    using NUnit.Framework;
    using MyStore.Domain.Nomenclatures;
    using MyStore.Domain.Operations;
    using System.Collections.Generic;

    public class OperationsTests
    {
        [Test]
        public void When_DeliveringItems_Expect_ToHaveThemInStock()
        {
            var storeCode = "Store02";
            IStore store = new Store(storeCode);

            var userCode = "Operator02";
            var supplierCode = "Supplier02";

            string[] itemCodes = new string[2] { "item501.5", "item404.4" };
            var opManager = new OperationsManager<Delivery, DeliveryOperationDescriptor>(userCode, store);
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
            var opDescriptor = new DeliveryOperationDescriptor(supplierCode, deliveredItems);
            IActiveOperation operation = opManager.CreateOperation(opDescriptor);
            var opCode = opManager.CommitOperation();
        
            Assert.NotNull(opCode);
            Assert.AreEqual(120, store.CheckAvailability(itemCodes[0]));
            Assert.AreEqual(50, store.CheckAvailability(itemCodes[1]));
        }

        [Test]
        public void When_SaleItems_Expect_DecreasedQttiesInStore()
        {
            var userCode = "Operator02";
            var storeCode = "Store02";
            IStore store = new Store(storeCode);

            string[] itemCodes = new string[2] { "item501.5", "item404.4" };

            store.AddToWarehouse(itemCodes[0], 100);
            store.AddToWarehouse(itemCodes[1], 100);        

            
            var opManager = new OperationsManager<Sale, SaleOperationDescriptor>(userCode, store);
            var soldItems = new List<OperationalItem>()
                            {
                                new OperationalItem()
                                {
                                    Code = itemCodes[0],
                                    Qtty = 2,
                                    Measure = Measure.Qtty, // To do: measurement based on strategy
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

            var opDescriptor = new SaleOperationDescriptor(soldItems);
            IActiveOperation operation = opManager.CreateOperation(opDescriptor);
            var opCode = opManager.CommitOperation();
        
            Assert.NotNull(opCode);
            Assert.AreEqual(98, store.CheckAvailability(itemCodes[0]));
            Assert.AreEqual(96, store.CheckAvailability(itemCodes[1]));
        }
    }
}