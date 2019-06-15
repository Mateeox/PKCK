using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PKCK.Classes
{
    public class customer
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string companyId { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public string zipCode { get; set; }
        public string countryCode { get; set; }
        [XmlAttribute]
        public string customerId { get; set; }
    }
}
