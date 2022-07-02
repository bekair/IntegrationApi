using OrderIntegrationSystem.SupplierDatabase.DbContexts.Abstracts;
using OrderIntegrationSystem.SupplierDatabase.Entities;

namespace OrderIntegrationSystem.SupplierDatabase.DbContexts
{
    public class SupplierContext : ISupplierContext
    {
        public ICollection<Article> Articles { get; set; }
        public ICollection<Buyer> Buyers { get; set; }
        public ICollection<ArticleBuyerPrice> ArticlePrices { get; set; }

        public SupplierContext()
        {
            SeedData();
        }

        private void SeedData()
        {
            Articles = SeedArticles();
            Buyers = SeedBuyers();
            ArticlePrices = SeedArticleBuyerPrices();
        }

        private static ICollection<Article> SeedArticles()
        {
            return new List<Article>
            {
                new Article
                {
                    Id = 1,
                    Description = "Computer",
                    EANCode = "123456789",
                    UnitPrice = 100.8D
                },
                new Article
                {
                    Id = 2,
                    Description = "Computer Monitor",
                    EANCode = "1241786531",
                    UnitPrice = 15.5D
                },
                new Article
                {
                    Id = 3,
                    Description = "Keyboard",
                    EANCode = "983436473",
                    UnitPrice = 34
                },
                new Article
                {
                    Id = 4,
                    Description = "Mouse",
                    EANCode = "123499879",
                    UnitPrice = 12.87D
                },
                new Article
                {
                    Id = 5,
                    Description = "Gamepad",
                    EANCode = "981456789",
                    UnitPrice = 45.5D
                },
                new Article
                {
                    Id = 6,
                    Description = "Playstation",
                    EANCode = "18129389",
                    UnitPrice = 670.5D
                }
            };
        }

        private static ICollection<Buyer> SeedBuyers()
        {
            return new List<Buyer>
            {
                new Buyer
                {
                    Id=1,
                    EANCode="65123456789376812345678944"
                },
                new Buyer
                {
                    Id=2,
                    EANCode="17123456798378712345678944"
                },
                new Buyer
                {
                    Id=3,
                    EANCode="356754332"
                },
                new Buyer
                {
                    Id=4,
                    EANCode="57843456789378712345678944"
                },
                new Buyer
                {
                    Id=5,
                    EANCode="87123456789289712345678944"
                },
                new Buyer
                {
                    Id=6,
                    EANCode="87123456789378712345678944"
                }
            };
        }

        private static ICollection<ArticleBuyerPrice> SeedArticleBuyerPrices()
        {
            return new List<ArticleBuyerPrice>
            {
                new ArticleBuyerPrice
                {
                    Id=1,
                    BuyerId=4,
                    ArticleId=1,
                    UnitPrice=85.6D
                },
                new ArticleBuyerPrice
                {
                    Id=2,
                    BuyerId=3,
                    ArticleId=1,
                    UnitPrice=95.6D
                },
                new ArticleBuyerPrice
                {
                    Id=3,
                    BuyerId=6,
                    ArticleId=2,
                    UnitPrice=9.6D
                },
                new ArticleBuyerPrice
                {
                    Id=4,
                    BuyerId=4,
                    ArticleId=3,
                    UnitPrice=23.46D
                },
                new ArticleBuyerPrice
                {
                    Id=5,
                    BuyerId=1,
                    ArticleId=3,
                    UnitPrice=19.6D
                }
            };
        }
    }
}
