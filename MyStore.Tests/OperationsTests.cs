namespace MyStore.Tests.Operations
{
    using NUnit.Framework;
    using MyStore.Domain.Nomenclatures;
    using MyStore.Domain.Operations;
    using System.Collections.Generic;

    public class OperationsTests
    {
        // private Supplier GetSupplier()
        // {
        //     return new Supplier()
        //     {             
        //         Name = "Milky Foods Ltd",
        //         Address = "London, strImaginary str.3",
        //         Phone = "0991819912"
        //     };
        // }

        // private Store GetStore()
        // {
        //     return new Store()
        //     {             
        //         Name = "Store One",
        //         Address = "London, Temza str. 43",
        //         Phone = "34545555544"
        //     };
        // }

        // private User GetUser()
        // {
        //      return new User()
        //     {                
        //         Name = "OperatorOne",
        //         Email = "operator@gmail.com"
        //     };
        // }

        // private Supply GetSupply()
        // {
        //      var yogurt = new SupplyItem()
        //     {
        //         ItemId = 1,
        //         Qtty = 100,
        //         Measure = Measure.Qtty,
        //         UnitPrice = 0.75m,
        //         Currency = "BGN"
        //     };

        //     var mozzarela = new SupplyItem()
        //     {
        //         ItemId = 2,
        //         Qtty = 50,
        //         Measure = Measure.Qtty,
        //         UnitPrice = 1.45m,
        //         Currency = "BGN"
        //     };

        //     return new Supply()
        //     {
        //         Items = new SupplyItem[] { yogurt, mozzarela }
        //     };
        // }

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
            IOperation operation = opManager.CreateOperation(opDescriptor);
            var opCode = opManager.CommitOperation();
        
            Assert.NotNull(opCode);
            Assert.AreEqual(store.CheckAvailability(itemCodes[0]), 120);
            Assert.AreEqual(store.CheckAvailability(itemCodes[1]), 50);
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
            IOperation operation = opManager.CreateOperation(opDescriptor);
            var opCode = opManager.CommitOperation();
        
            Assert.NotNull(opCode);
            Assert.AreEqual(store.CheckAvailability(itemCodes[0]), 98);
            Assert.AreEqual(store.CheckAvailability(itemCodes[1]), 96);
        }

        // [Test]
        // public void CheckIfCanMakePayment()
        // {
        //     var payment = new Payment(10.45m, "BGN", Sign.Plus);
        //     var cashDesk = new CashDesk();

        //     int paymentId = cashDesk.CommitPayment();

        //     cashDesk
        // }

    }
}