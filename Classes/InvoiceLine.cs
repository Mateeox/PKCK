using System.Xml.Serialization;

namespace PKCK.Classes
{
    public class invoiceLine
    {
        public invoiceProduct invoiceProduct { get; set; }
        public uint quantity { get; set; }
        public vatValue vatValue { get; set; }
    }
}