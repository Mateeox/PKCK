using java.io;
using javax.xml.transform;
using javax.xml.transform.sax;
using javax.xml.transform.stream;
using org.apache.fop.apps;
using PKCK.Classes;
using PKCK.Operations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Xsl;

namespace PKCK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        document document;
        public MainWindow()
        {
            InitializeComponent();
            LoadFile lf = new LoadFile(String.Format(@"./{0}", ConfigurationManager.AppSettings["file"]));
            document = lf.document;
            authors.ItemsSource = lf.document.documentInfo.authors;
            modification.ItemsSource = new modification[] { lf.document.documentInfo.modification };
            customers.ItemsSource = lf.document.customers;
            products.ItemsSource = lf.document.products;
            invoices.ItemsSource = lf.document.invoices;
        }

        private void Authors_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            info.IsEnabled = true;
        }

        private void Modification_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            info.IsEnabled = true;
        }

        private void Customers_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            custom.IsEnabled = true;
        }

        private void Products_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            prod.IsEnabled = true;
        }

        private void Invoices_GotFocus(object sender, RoutedEventArgs e)
        {
            invoicelines.ItemsSource = ((invoice)((DataGridCell)e.OriginalSource).DataContext).invoiceLines;
            lines.IsEnabled = true;
        }

        private void Invoices_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            inv.IsEnabled = true;
        }

        private void Invoicelines_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            invline.IsEnabled = true;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            string filename = ConfigurationManager.AppSettings["file"].Split('.')[0];
            string fileextension = "." + ConfigurationManager.AppSettings["file"].Split('.')[1];
            SaveFile sf = new SaveFile(String.Format(@"./{0}_{1}_{2}{3}", filename, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString().Replace(':', '.'), fileextension), document);
        }

        private void PDF_Click(object sender, RoutedEventArgs e)
        {
            PDF.IsEnabled = false;
            string filename = ConfigurationManager.AppSettings["file"].Split('.')[0];
            string fileextension = "." + ConfigurationManager.AppSettings["file"].Split('.')[1];
            string saved_file = String.Format(@"./{0}_{1}_{2}{3}", filename, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString().Replace(':', '.'), fileextension);
            string pdf_file = String.Format(@"./{0}_{1}_{2}.pdf", filename, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString().Replace(':', '.'), fileextension);
            SaveFile sf = new SaveFile(saved_file, document);
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("./report.xslt");
            xslt.Transform(saved_file, "./report.xml");
            xslt.Load("./pdf.xslt");
            xslt.Transform("./report.xml", "./report.fo");
            FopFactory fopFactory = FopFactory.newInstance(new java.net.URI("."));


            //in this stream we will get the generated pdf file
            OutputStream o = new DotNetOutputMemoryStream();
            try
            {
                Fop fop = fopFactory.newFop("application/pdf", o);
                TransformerFactory factory = TransformerFactory.newInstance();
                Transformer transformer = factory.newTransformer();


                //read the template from disc
                Source src = new StreamSource(new File("report.fo"));
                Result res = new SAXResult(fop.getDefaultHandler());
                transformer.transform(src, res);
            }
            finally
            {
                o.close();
            }
            using (System.IO.FileStream fs = System.IO.File.Create(pdf_file))
            {
                //write from the .NET MemoryStream stream to disc the generated pdf file
                var data = ((DotNetOutputMemoryStream)o).Stream.GetBuffer();
                fs.Write(data, 0, data.Length);
            }
            PDF.IsEnabled = true;
        }
    }
}
