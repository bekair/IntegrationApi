using OrderIntegrationSystem.MockSystems.ERPSystem.Implementations;

namespace OrderIntegrationSystem.MockSystems.ERPSystem.Interfaces
{
    public class ERPSystemService : IERPSystemService
    {
        public bool CheckStockAvailability(string eanCode, int quantity)
        {
            return true;
        }

        public void UpdateStock(string eanCode, int quantity)
        {
        }
    }
}
