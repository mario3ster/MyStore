namespace MyStore.Domain.Operations
{
    public abstract class OperationItem
    {
        public int ItemId { get; set; }
        public int Qtty { get; set; }
        public object Measure { get; set; }
        public decimal UnitPrice { get; set; }
        public string Currency { get; set; }
    }
}