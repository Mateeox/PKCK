using System;
using System.Xml.Serialization;

namespace PKCK.Classes
{
    public class author
    {
        [XmlElement]
        public string firstname { get; set; }
        [XmlElement]
        public string lastname { get; set; }
        [XmlIgnore]
        public DateTime creationDate { get; set; }

        [XmlElement("creationDate")]
        public string TempDate
        {
            get { return creationDate.ToShortDateString(); }
            set { creationDate = DateTime.Parse(value); }
        }
    }
}
