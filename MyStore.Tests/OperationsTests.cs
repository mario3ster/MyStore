namespace MyStore.Tests.Operations
{
    using NUnit.Framework;
    using MyStore.Domain.Nomenclatures;
    using MyStore.Domain.Operations;
    using MyStore.Domain.Payments;
    using MyStore.Domain.Math;
    using System.Linq;

    public class OperationsTests
    {
        private ISupplier GetSupplier()
        {
            return new Supplier()
            {
                Id = 88718,
                Name = "Milky Foods Ltd",
                Address = "London, strImaginary str.3",
                Phone = "0991819912"
            };
        }

        private IStore GetStore()
        {
            return new Store()
            {
                Id = 88718,
                Name = "Store One",
                Address = "London, Temza str. 43",
                Phone = "34545555544"
            };
        }

        private IUser GetUser()
        {
             return new User()
            {
                Id = 88718,
                Name = "OperatorOne",
                Email = "operator@gmail.com"
            };
        }

        private Supply GetSupply()
        {
             var yogurt = new SupplyItem()
            {
                ItemId = 1,
                Qtty = 100,
                Measure = Measure.Qtty,
                UnitPrice = 0.75m,
                Currency = "BGN"
            };

            var mozzarela = new SupplyItem()
            {
                ItemId = 2,
                Qtty = 50,
                Measure = Measure.Qtty,
                UnitPrice = 1.45m,
                Currency = "BGN"
            };

            return new Supply()
            {
                Items = new SupplyItem[] { yogurt, mozzarela }
            };
        }

        [Test]
        public void CheckIfCanCommitNewDeleveryIntoMyShop()
        {
            var delivery = new Delivery()
            {
                Supply = GetSupply(),
                Operator = GetUser(),
                Store = GetStore(),
                Supplier = GetSupplier(),
                Payment = new Payment(10.45m, "BGN", Sign.Minus)
            };
            
            var operationManager = new OperationManager();

            operationManager.AddOperation(delivery);
            operationManager.CommitOperations();

            var lastOperation = operationManager.Operations.Last();

            Assert.IsNotNull(lastOperation);
            Assert.IsTrue(operationManager.Operations.Count() == 1);
            Assert.AreEqual(delivery, lastOperation);
            //Assert.AreEqual(delivery, delivery2);
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