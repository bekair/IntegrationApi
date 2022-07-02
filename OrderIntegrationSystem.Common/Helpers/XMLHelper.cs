using OrderIntegrationSystem.Domain.Models;
using System.Xml.Serialization;

namespace OrderIntegrationSystem.Common.Helpers
{
    public static class XMLHelper
    {
        public static string CreateOrderXML(OrderDetail orderDetail)
        {
            XmlSerializer serializer = new(typeof(OrderDetail));
            using TextWriter writer = new StreamWriter(@"C:\orderDetail.xml");
            serializer.Serialize(writer, orderDetail);

            return writer.ToString();
        }
    }
}