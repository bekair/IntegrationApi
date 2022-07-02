using OrderIntegrationSystem.Domain.Models;

namespace OrderIntegrationSystem.Common.Parsers.Interfaces
{
    public interface IOrderParser
    {
        OrderDetail ParseFile(IEnumerable<string> fileLineValueList);
    }
}
