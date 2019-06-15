using System;
using System.Xml.Serialization;

namespace PKCK.Classes
{
    public class modification
    {
        [XmlElement]
        public string firstname { get; set; }
        [XmlElement]
        public string lastname { get; set; }
        [XmlIgnore]
        public DateTime modificationDate { get; set; }

        [XmlElement("modificationDate")]
        public string tempModificationDate
        {
            get { return modificationDate.ToShortDateString(); }
            set { modificationDate = DateTime.Parse(value); }
        }
    }
}
