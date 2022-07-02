using OrderIntegrationSystem.SupplierDatabase.Abstracts;

namespace OrderIntegrationSystem.SupplierDatabase.Entities
{
    public class Article : EntityBase
    {
        public string EANCode { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public ICollection<ArticleBuyerPrice> BuyerPriceList { get; set; }
    }
}
