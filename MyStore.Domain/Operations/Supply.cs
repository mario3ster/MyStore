namespace MyStore.Domain.Operations
{
    public class Supply
    {
        public Supply()
        {
        }

        public SupplyItem[] Items { get; set; }
        public decimal Total { get; internal set; }
    }
}