using AutoMapper;
using OrderIntegrationSystem.Business.Interfaces;
using OrderIntegrationSystem.Common.Constants;
using OrderIntegrationSystem.Common.FileOperations.Interfaces;
using OrderIntegrationSystem.Common.Helpers;
using OrderIntegrationSystem.Common.Parsers.Interfaces;
using OrderIntegrationSystem.MockSystems.ERPSystem.Implementations;
using System.Text;

namespace OrderIntegrationSystem.Business.Services
{
    public class OrderBusiness : IOrderBusiness
    {
        private readonly IFileReader _fileReader;
        private readonly IOrderParser _orderParser;
        private readonly IPriceDbBusiness _priceDbBusiness;
        private readonly HttpClient _httpClient;
        private readonly IERPSystemService _erpSystemService;

        public OrderBusiness(IFileReader fileReader,
            HttpClient httpClient,
            IOrderParser orderParser,
            IPriceDbBusiness priceDbBusiness,
            IERPSystemService erpSystemService)
        {
            _fileReader = fileReader;
            _httpClient = httpClient;
            _orderParser = orderParser;
            _priceDbBusiness = priceDbBusiness;
            _erpSystemService = erpSystemService;
        }

        public async Task<string> LoadOrderDocument(string path)
        {
            var lines = _fileReader.ReadFile(path);
            var receivedOrder = _orderParser.ParseFile(lines);
            _priceDbBusiness.CheckArticleUnitPrices(receivedOrder.ArticleList, receivedOrder.EANCodeBuyer);

            var articles = receivedOrder.ArticleList;
            var enumeratorArticles = articles.GetEnumerator();
            while (enumeratorArticles.MoveNext()) 
            {
                var article = enumeratorArticles.Current;
                var isStockAvailable = _erpSystemService.CheckStockAvailability(article.EANCode, article.Quantity);
                if (!isStockAvailable)
                {
                    //TODO: SendNotificationAccountManager
                    throw new Exception(string.Format(Constant.ErrorMessage.StockNotAvailable, article.EANCode));
                }
                _erpSystemService.UpdateStock(article.EANCode, article.Quantity);
            }

            string xmlString = XMLHelper.CreateOrderXML(receivedOrder);
            var requestContent = new StringContent(xmlString, Encoding.UTF8, "application/json");
            //Assume to send HTTP Request with trycatch
            try
            {
                var response = await _httpClient.PostAsync("order/receive", requestContent);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
            }
            
            return xmlString;
        }
    }
}
