using Microsoft.AspNetCore.Mvc;
using OrderIntegrationSystem.Business.Interfaces;

namespace OrderIntegrationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBusiness _orderBusiness;

        public OrderController(IOrderBusiness orderBusiness)
        {
            _orderBusiness = orderBusiness;
        }

        [HttpGet("LoadOrderDocument")]
        public async Task<ContentResult> LoadOrderDocument(string path)
        {
            var orderDetails = await _orderBusiness.LoadOrderDocument(path);
            return new ContentResult
            {
                Content = orderDetails,
                ContentType = "application/xml",
                StatusCode = 200
            };
        }
    }
}