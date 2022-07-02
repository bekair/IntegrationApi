using OrderIntegrationSystem.Common.Dtos;

namespace OrderIntegrationSystem.Business.Interfaces
{
    public interface IOrderBusiness
    {
        Task<string> LoadOrderDocument(string path);
    }
}
