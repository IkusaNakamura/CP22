using System;
using System.Collections.Generic;
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

namespace CP22.Pages
{
    /// <summary>
    /// Логика взаимодействия для ViewContacts.xaml
    /// </summary>
    public partial class ViewContacts : Page
    {
        public ViewContacts()
        {
            InitializeComponent();
            try
            {

            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) //обновление страницы при возвращении
        {
            PoliclinicaEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
           // DGPatients.ItemsSource = PoliclinicaEntities.GetContext().Patients.ToList();
        }

        private void SearchBT_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
