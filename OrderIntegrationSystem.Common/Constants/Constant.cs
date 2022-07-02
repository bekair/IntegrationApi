namespace OrderIntegrationSystem.Common.Constants
{
    public static class Constant
    {
        public static class FileType
        {
            public const string ORD = "ORD";
        }

        public static class ErrorMessage
        {
            public const string NullOrEmptyMessage = "The {0} is null or empty.";
            public const string EntityNotFound = "The {0} could not found.";
            public const string WrongFileTypeIdentifier = $"The file type should always be {FileType.ORD}";
            public const string StockNotAvailable = "Stock is not available for article with the EANCode:{0}";
        }
    }
}
