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
    /// Логика взаимодействия для ViewPolisy.xaml
    /// </summary>
    public partial class ViewPolisy : Page
    {
        public ViewPolisy()
        {
            InitializeComponent();
            try
            {
                DGUsers.ItemsSource = PoliclinicaEntities.GetContext().Policy.ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void addUser_Click(object sender, RoutedEventArgs e)
        {
            ManegerFrames.MainFrame.Navigate(new PagesForms.PolicyOrg(null));
        }
        private void BtEdit_Click(object sender, RoutedEventArgs e)//Редактирование
        {
            ManegerFrames.MainFrame.Navigate(new PagesForms.PolicyOrg((sender as Button).DataContext as Policy));
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) //обновление страницы при возвращении
        {
            PoliclinicaEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGUsers.ItemsSource = PoliclinicaEntities.GetContext().Policy.ToList();
        }

        private void delbt_Click(object sender, RoutedEventArgs e)
        {
            var policTiRemoving = DGUsers.SelectedItems.Cast<Policy>().ToList();
            if (MessageBox.Show($"Следующие {policTiRemoving.Count()} объекты будут безвозвратно удалены.\nПродолжить?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PoliclinicaEntities.GetContext().Policy.RemoveRange(policTiRemoving);
                    PoliclinicaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Удалено успешно");
                    DGUsers.ItemsSource = PoliclinicaEntities.GetContext().Policy.ToList();
                }
                catch (Exception eeee)
                {
                    MessageBox.Show(eeee.Message);
                }
            }
        }
    }
}
