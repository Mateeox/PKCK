using System.Xml.Serialization;

namespace PKCK.Classes
{
    public class invoiceCustomer
    {
        [XmlAttribute]
        public string customerRef { get; set; }
    }
}