using OrderIntegrationSystem.Common.Constants;
using OrderIntegrationSystem.Common.Parsers.Interfaces;
using OrderIntegrationSystem.Domain.Models;

namespace OrderIntegrationSystem.Common.Parsers.Implementations
{
    public class OrderParser : IOrderParser
    {
        public OrderDetail ParseFile(IEnumerable<string> fileLineValueList)
        {
            if (fileLineValueList is null || !fileLineValueList.Any())
            {
                throw new ArgumentNullException(
                    null,
                    string.Format(Constant.ErrorMessage.NullOrEmptyMessage, nameof(fileLineValueList))
                );
            }

            return ParseOrderDetail(fileLineValueList);
        }

        private static OrderDetail ParseOrderDetail(IEnumerable<string> fileLineValueList)
        {
            var orderDetails = fileLineValueList.First();
            var fileTypeIdentifier = orderDetails[..3];
            if (fileTypeIdentifier is not Constant.FileType.ORD)
            {
                throw new Exception(Constant.ErrorMessage.WrongFileTypeIdentifier);
            }

            var orderDetail = new OrderDetail
            {
                OrderNumber = orderDetails[3..23].TrimEnd(),
                OrderDate = new DateTime(
                    year: Convert.ToInt32(orderDetails[23..27].TrimEnd()),
                    month: Convert.ToInt32(orderDetails[27..29].TrimEnd()),
                    day: Convert.ToInt32(orderDetails[29..31].TrimEnd()),
                    hour: Convert.ToInt32(orderDetails[32..34].TrimEnd()),
                    minute: Convert.ToInt32(orderDetails[34..36].TrimEnd()),
                    0
                ),
                EANCodeBuyer = orderDetails[36..49].TrimEnd(),
                EANCodeSupplier = orderDetails[49..62].TrimEnd(),
                Comment = orderDetails[62..].TrimEnd(),
                ArticleList = ParseArticles(fileLineValueList.Skip(1))
            };

            return orderDetail;
        }

        private static ICollection<ArticleDetail> ParseArticles(IEnumerable<string> articleStringList)
        {
            ICollection<ArticleDetail> articles = new List<ArticleDetail>();
            foreach (var article in articleStringList)
            {
                var articleDetail = new ArticleDetail
                {
                    EANCode = article[..13].TrimEnd(),
                    Description = article[13..78].TrimEnd(),
                    Quantity = Convert.ToInt32(article[78..88].TrimEnd()),
                    UnitPrice = double.Parse(article[88..].Replace('.', ','))
                };

                articles.Add(articleDetail);
            }

            return articles;
        }
    }
}