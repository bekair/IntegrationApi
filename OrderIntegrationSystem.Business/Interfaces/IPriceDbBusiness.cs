using OrderIntegrationSystem.Domain.Models;

namespace OrderIntegrationSystem.Business.Interfaces
{
    public interface IPriceDbBusiness
    {
        void CheckArticleUnitPrices(ICollection<ArticleDetail> articles, string buyerEANCode);
    }
}
