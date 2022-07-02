using OrderIntegrationSystem.SupplierDatabase.Entities;

namespace OrderIntegrationSystem.SupplierDatabase.DbContexts.Abstracts
{
    public interface ISupplierContext
    {
        ICollection<Article> Articles { get; set; }
        ICollection<Buyer> Buyers { get; set; }
        ICollection<ArticleBuyerPrice> ArticlePrices { get; set; }
    }
}
