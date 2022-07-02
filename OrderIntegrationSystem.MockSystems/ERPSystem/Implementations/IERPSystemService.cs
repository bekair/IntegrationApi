namespace OrderIntegrationSystem.MockSystems.ERPSystem.Implementations
{
    public interface IERPSystemService
    {
        void UpdateStock(string eanCode, int quantity);
        bool CheckStockAvailability(string eanCode, int quantity);
    }
}