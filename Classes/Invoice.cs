using System;
using System.Xml.Serialization;

namespace PKCK.Classes
{
    public class invoice
    {
        public int invoiceNumber { get; set; }
        public invoiceCustomer invoiceCustomer { get; set; }
        [XmlIgnore]
        public DateTime invoiceDate { get; set; }
        public string additionalText { get; set; }
        public invoiceLine[] invoiceLines { get; set; }

        [XmlElement("invoiceDate")]
        public string tempInvoiceDate
        {
            get { return invoiceDate.ToShortDateString(); }
            set { invoiceDate = DateTime.Parse(value); }
        }
    }
}
