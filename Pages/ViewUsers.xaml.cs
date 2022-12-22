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
    /// Логика взаимодействия для ViewUsers.xaml
    /// </summary>
    public partial class ViewUsers : Page
    {
        public ViewUsers()
        {
            InitializeComponent();
            try
            {
                DGUsers.ItemsSource = PoliclinicaEntities.GetContext().Users.ToList();
            }
            catch (Exception e) { MessageBox.Show(e.Message); 
            }
           
        }

        private void addUser_Click(object sender, RoutedEventArgs e)
        {
            ManegerFrames.MainFrame.Navigate(new PagesForms.User(null));
        }
        private void BtEdit_Click(object sender, RoutedEventArgs e)//Редактирование
        {
            ManegerFrames.MainFrame.Navigate(new PagesForms.User((sender as Button).DataContext as Users));
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) //обновление страницы при возвращении
        {
            PoliclinicaEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGUsers.ItemsSource = PoliclinicaEntities.GetContext().Users.ToList();
        }

        private void delbt_Click(object sender, RoutedEventArgs e)
        {
            var usersTiRemoving = DGUsers.SelectedItems.Cast<Users>().ToList();
            if (MessageBox.Show($"Следующие {usersTiRemoving.Count()} объекты будут безвозвратно удалены.\nПродолжить?","Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question)== MessageBoxResult.Yes)
            {
                try
                {
                    PoliclinicaEntities.GetContext().Users.RemoveRange(usersTiRemoving);
                    PoliclinicaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Удалено успешно");
                    DGUsers.ItemsSource = PoliclinicaEntities.GetContext().Users.ToList();
                }
                catch (Exception eeee)
                {
                    MessageBox.Show(eeee.Message);
                }
            } 
        }

        private void SearchBT_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
