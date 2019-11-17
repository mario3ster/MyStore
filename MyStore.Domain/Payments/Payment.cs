namespace MyStore.Domain.Payments
{
    using System;
    using MyStore.Domain.Math;
    using MyStore.Domain.Operations;

    public class Payment : IPayment
    {
        public decimal Total { get; private set; }

        public string Curency { get; private set; }

        public DateTime Date { get; private set; }

        public Sign Sign { get; private set; }

        public OpCode OperationCode { get; private set; }

        public Payment(decimal total, string curency, Sign sign, OpCode operationCode)
        {
            Total = total;
            Curency = curency;
            Sign = sign;
            OperationCode = operationCode;
        }
    }
}