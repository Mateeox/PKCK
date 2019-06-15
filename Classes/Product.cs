using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PKCK.Classes
{
    public class product
    {
        [XmlAttribute]
        public string productId { get; set; }
        public string name { get; set; }
        public string producer { get; set; }
        public price price { get; set; }
    }
}
