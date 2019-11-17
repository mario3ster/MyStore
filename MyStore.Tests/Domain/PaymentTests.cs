namespace MyStore.Tests.Domain.Operations
{
    using NUnit.Framework;
    using MyStore.Domain.Payments;
    using MyStore.Domain.Math;
    using MyStore.Domain.Exceptions;
    using MyStore.Domain.Operations;

    public class PaymentsTests
    {
        [Test]
        public void When_AddSomePaymentsAndExpenses_Expect_ToHaveCorrectBalance()
        {
            IPayment[] payments = new Payment[] 
            {
                new Payment(200.00M, "BGN", Sign.Plus, new OpCode(1)), 
                new Payment(450.00M, "BGN", Sign.Plus, new OpCode(2)), 
                new Payment(1100.00M, "BGN", Sign.Plus, new OpCode(3)), 
                new Payment(550.00M, "BGN", Sign.Minus, new OpCode(4))
            }; 

            var cashier = new Cashier();

            foreach (var payment in payments)
            {
                cashier.CommitPayment(payment);
            }

            Assert.AreEqual(1200.00M, cashier.GetBalance());
        }

        [Test]
        public void When_HaveMoreExpencesThanTotalInCashier_Expect_Exception()
        {
            IPayment[] payments = new Payment[] 
            {
                new Payment(220.00M, "BGN", Sign.Plus, new OpCode(1)), 
                new Payment(329.00M, "BGN", Sign.Plus, new OpCode(2)), 
                new Payment(550.00M, "BGN", Sign.Minus, new OpCode(3))
            }; 

            var cashier = new Cashier();

            Assert.Catch(typeof(RunOutOfMoneyException), () => 
                {
                    foreach (var payment in payments)
                    {
                        cashier.CommitPayment(payment);
                    }
                });
        }
    }
}