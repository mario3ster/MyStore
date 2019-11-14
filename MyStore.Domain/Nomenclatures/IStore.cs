namespace MyStore.Domain.Nomenclatures
{
    public interface IStore
    {
        int CheckAvailability(string itemCode);
        
        void AddToWarehouse(string itemCode, int qtty);

        void TakeOutOfWarehouse(string code, int qtty);
    }
}