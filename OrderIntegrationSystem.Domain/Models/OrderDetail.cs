namespace OrderIntegrationSystem.Domain.Models
{
    public class OrderDetail
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string EANCodeBuyer { get; set; }
        public string EANCodeSupplier { get; set; }
        public string Comment { get; set; }
        public ICollection<ArticleDetail> ArticleList { get; set; }
    }
}
