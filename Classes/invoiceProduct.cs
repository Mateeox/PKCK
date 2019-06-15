using System.Xml.Serialization;

namespace PKCK.Classes
{
    public class invoiceProduct
    {
        [XmlAttribute]
        public string productRef { get; set; }
    }
}