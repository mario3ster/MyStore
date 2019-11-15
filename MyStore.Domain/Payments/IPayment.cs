namespace MyStore.Domain.Payments
{
    using System;
    using MyStore.Domain.Math;
    
    public interface IPayment
    {
        decimal Total { get; }

        string Curency { get; }

        Sign Sign { get; }

        DateTime Date { get; }
    }
}