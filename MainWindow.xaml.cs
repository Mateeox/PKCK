using PKCK.Classes;
using PKCK.Operations;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    }
}
