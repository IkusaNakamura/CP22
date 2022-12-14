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
    /// Логика взаимодействия для ViewCards.xaml
    /// </summary>
    public partial class ViewCards : Page
    {
        public ViewCards()
        {
            InitializeComponent();
            
            try
            {
                DGCards.ItemsSource = PoliclinicaEntities.GetContext().MedCards.ToList();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) //обновление страницы при возвращении
        {
            PoliclinicaEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGCards.ItemsSource = PoliclinicaEntities.GetContext().Patients.ToList();
        }

        private void addCard_Click(object sender, RoutedEventArgs e)
        {
            ManegerFrames.MainFrame.Navigate(new PagesForms.MedCard(null));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void BtEdit_Click(object sender, RoutedEventArgs e)//Редактирование
        {
            ManegerFrames.MainFrame.Navigate(new PagesForms.MedCard((sender as Button).DataContext as MedCards));
        }

        private void delbt_Click(object sender, RoutedEventArgs e)
        {
            var cardsTiRemoving = DGCards.SelectedItems.Cast<MedCards>().ToList();
            if (MessageBox.Show($"Следующие {cardsTiRemoving.Count()} объекты будут безвозвратно удалены.\nПродолжить?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PoliclinicaEntities.GetContext().MedCards.RemoveRange(cardsTiRemoving);
                    PoliclinicaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Удалено успешно");
                    DGCards.ItemsSource = PoliclinicaEntities.GetContext().MedCards.ToList();
                }
                catch (Exception eeee)
                {
                    MessageBox.Show(eeee.Message);
                }
            }
        }

        private void vueEdit_Click(object sender, RoutedEventArgs e)
        {
            ManegerFrames.MainFrame.Navigate(new ViewPatientInfo((sender as Button).DataContext as MedCards));
        }

        private void SearchBT_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
