namespace OrderIntegrationSystem.Common.Dtos
{
    public class ArticleDetailDto
    {
        public string EANCode { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
