using PKCK.Classes;
using System.IO;
using System.Xml.Serialization;

namespace PKCK.Operations
{
    public class LoadFile
    {
        public document document;
        public LoadFile(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(document));
            using (Stream reader = new FileStream(path, FileMode.Open))
            {
                document = (document)serializer.Deserialize(reader);
            }
        }
    }
}
