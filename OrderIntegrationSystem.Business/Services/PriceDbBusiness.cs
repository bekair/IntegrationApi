using OrderIntegrationSystem.Business.Interfaces;
using OrderIntegrationSystem.Common.Constants;
using OrderIntegrationSystem.Domain.Models;
using OrderIntegrationSystem.SupplierDatabase.DbContexts.Abstracts;
using OrderIntegrationSystem.SupplierDatabase.Entities;

namespace OrderIntegrationSystem.Business.Services
{
    public class PriceDbBusiness : IPriceDbBusiness
    {
        private readonly ISupplierContext _supplierContext;

        public PriceDbBusiness(ISupplierContext supplierContext)
        {
            _supplierContext = supplierContext;
        }

        public void CheckArticleUnitPrices(ICollection<ArticleDetail> articles, string buyerEANCode)
        {
            foreach (var article in articles)
            {
                var priceReferenceUnitPrice = GetUnitPriceForABuyer(article.EANCode, buyerEANCode);
                if (priceReferenceUnitPrice != article.UnitPrice)
                {
                    //TODO: SendNotification(article, priceReferenceUnitPrice);
                    article.UnitPrice = priceReferenceUnitPrice;
                }
            }
        }

        private double GetUnitPriceForABuyer(string articleEanCode, string buyerEANCode)
        {
            var buyerId = _supplierContext.Buyers.Where(x => x.EANCode == buyerEANCode)
                                                 .Select(x => x.Id)
                                                 .FirstOrDefault();
            if (buyerId is 0)
                throw new Exception(string.Format(Constant.ErrorMessage.EntityNotFound, nameof(Buyer)));

            var articleId = _supplierContext.Articles.Where(x => x.EANCode == articleEanCode)
                                                     .Select(x => x.Id)
                                                     .FirstOrDefault();
            if (articleId is 0)
                throw new Exception(string.Format(Constant.ErrorMessage.EntityNotFound, nameof(Article)));

            double? buyerSpecialPrice = _supplierContext.ArticlePrices.Where(x => x.BuyerId == buyerId &&
                                                                                  x.ArticleId == articleId
                                                                      )
                                                                      .Select(x => x.UnitPrice)
                                                                      .FirstOrDefault();

            if (buyerSpecialPrice is not null)
                return buyerSpecialPrice.Value;

            var unitPrice = _supplierContext.Articles.Where(x => x.Id == articleId)
                                                     .Select(x => x.UnitPrice)
                                                     .FirstOrDefault();

            return unitPrice;
        }
    }
}
