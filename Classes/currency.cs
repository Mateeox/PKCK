
using System.Xml.Serialization;

namespace PKCK.Classes
{
    public class currency
    {
        [XmlAttribute]
        public string curr { get; set; }
        [XmlIgnore]
        public decimal toPLN { get; set; }

        [XmlElement("toPLN")]
        public string tempValue
        {
            get { return toPLN.ToString(); }
            set { toPLN = decimal.Parse(value); }
        }
    }
}
