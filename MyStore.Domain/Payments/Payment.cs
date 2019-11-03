namespace MyStore.Domain.Payments
{
    using MyStore.Domain.Math;

    public class Payment : IPayment
    {
        public decimal Total { get; private set; }

        public string Curency { get; private set; }

        public Sign Sign { get; private set; }

        public Payment(decimal total, string curency, Sign sign)
        {
            this.Total = total;
            this.Curency = curency;
            this.Sign = sign;
        }
    }
}