using System.Xml.Serialization;

namespace PKCK.Classes
{
    public class vatValue
    {
        [XmlAttribute]
        public string type { get; set; }
        [XmlIgnore]
        public decimal value { get; set; }

        [XmlText]
        public string tempValue
        {
            get { return value.ToString(); }
            set { this.value = decimal.Parse(value); }
        }
    }
}