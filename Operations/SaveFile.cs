using PKCK.Classes;
using System.IO;
using System.Xml.Serialization;

namespace PKCK.Operations
{
    public class SaveFile
    {
        public SaveFile(string path, document document)
        {
            XmlSerializer xs = new XmlSerializer(typeof(document));
            TextWriter txtWriter = new StreamWriter(path);
            xs.Serialize(txtWriter, document);
            txtWriter.Close();
        }
    }
}
