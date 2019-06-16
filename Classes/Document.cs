using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PKCK.Classes
{
    public class document
    {
        public documentInfo documentInfo;
        public customer[] customers;
        public product[] products;
        public invoice[] invoices;
        public currency[] currencies;
    }
}
