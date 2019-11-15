namespace MyStore.Domain.Payments
{
    using System.Collections.Generic;
    using MyStore.Domain.Operations;
    using Domain.Math;
    using MyStore.Domain.Exceptions;

    public class Cashier
    {
        private readonly List<IPayment> payments;

        public Cashier()
        {
             payments = new List<IPayment>();
        }

        public OpCode CommitPayment(IPayment payment)
        {            
            if(payment.Sign == Sign.Minus)
            {
                decimal balance = GetBalance();

                if(balance < payment.Total)
                {
                    throw new RunOutOfMoneyException();    
                }
            }

            payments.Add(payment);

            return new OpCode(1);
        }

        public decimal GetBalance()
        {
            decimal balance = 0.0M;

            foreach (var payment in payments)
            {
                if (payment.Sign == Sign.Plus)
                {
                    balance += payment.Total;                    
                }
                else 
                {
                    balance -= payment.Total;
                }                
            }

            return balance;
        }
    }
}