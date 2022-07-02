namespace OrderIntegrationSystem.Common.Dtos
{
    public class OrderDetailDto
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string EANCodeBuyer { get; set; }
        public string EANCodeSupplier { get; set; }
        public string Comment { get; set; }
        public ICollection<ArticleDetailDto> ArticleList { get; set; }
    }
}
