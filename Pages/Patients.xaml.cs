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
    /// Логика взаимодействия для Patients.xaml
    /// </summary>
    public partial class Patients : Page
    {
        public Patients()
        {
            InitializeComponent();
            
            try
            {
                DGPatients.ItemsSource = PoliclinicaEntities.GetContext().Patients.ToList();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) //обновление страницы при возвращении
        {
            PoliclinicaEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGPatients.ItemsSource = PoliclinicaEntities.GetContext().Patients.ToList();
        }

        private void addPatient_Click(object sender, RoutedEventArgs e)
        {
            ManegerFrames.MainFrame.Navigate(new PagesForms.Patient(null));
        }
        private void BtEdit_Click(object sender, RoutedEventArgs e)//Редактирование
        {
            ManegerFrames.MainFrame.Navigate(new PagesForms.User((sender as Button).DataContext as Users));
        }


        private void delbt_Click(object sender, RoutedEventArgs e)
        {
            var patientsTiRemoving = DGPatients.SelectedItems.Cast<Patients>().ToList();
            if (MessageBox.Show($"Следующие {patientsTiRemoving.Count()} объекты будут безвозвратно удалены.\nПродолжить?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PoliclinicaEntities.GetContext().Patients.RemoveRange((IEnumerable<CP22.Patients>)patientsTiRemoving);
                    PoliclinicaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Удалено успешно");
                    DGPatients.ItemsSource = PoliclinicaEntities.GetContext().Patients.ToList();
                }
                catch (Exception eeee)
                {
                    MessageBox.Show(eeee.Message);
                }
            }
        }
        ///код для базы данных

        //private static PoliclinicaEntities _context;
        //public PoliclinicaEntities()
        //    : base("name=PoliclinicaEntities")
        //{
        //}

        //public static PoliclinicaEntities GetContext()
        //{
        //    if (_context == null) _context = new PoliclinicaEntities();
        //    return _context;
        //}


    }
}
