namespace MyStore.Domain.Operations
{
    public class OperationalItem
    {
        public string Code { get; set; }
        public int Qtty { get; set; }
        public Measure Measure { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}