using OrderIntegrationSystem.SupplierDatabase.Abstracts;

namespace OrderIntegrationSystem.SupplierDatabase.Entities
{
    public class ArticleBuyerPrice : EntityBase
    {
        public int ArticleId { get; set; }
        public int BuyerId { get; set; }
        public double UnitPrice { get; set; }
        public Article Article { get; set; }
        public Buyer Buyer { get; set; }
    }
}
