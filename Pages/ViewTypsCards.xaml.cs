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
    /// Логика взаимодействия для ViewTypsCards.xaml
    /// </summary>
    public partial class ViewTypsCards : Page
    {
        public ViewTypsCards()
        {
            InitializeComponent();
            
            try
            {
                DGTypsCards.ItemsSource = PoliclinicaEntities.GetContext().CardTyps.ToList();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
        
        private void BtEdit_Click(object sender, RoutedEventArgs e)//Редактирование
        {
            ManegerFrames.MainFrame.Navigate(new PagesForms.CardsType((sender as Button).DataContext as CardTyps));
        }



        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) //обновление страницы при возвращении
        {
            PoliclinicaEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGTypsCards.ItemsSource = PoliclinicaEntities.GetContext().CardTyps.ToList();
        }

        private void addCardType_Click(object sender, RoutedEventArgs e)
        {
            ManegerFrames.MainFrame.Navigate(new PagesForms.CardsType(null));
        }

        private void delbt_Click(object sender, RoutedEventArgs e)
        {
            var typsTiRemoving = DGTypsCards.SelectedItems.Cast<CardTyps>().ToList();
            if (MessageBox.Show($"Следующие {typsTiRemoving.Count()} объекты будут безвозвратно удалены.\nПродолжить?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PoliclinicaEntities.GetContext().CardTyps.RemoveRange(typsTiRemoving);
                    PoliclinicaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Удалено успешно");
                    DGTypsCards.ItemsSource = PoliclinicaEntities.GetContext().CardTyps.ToList();
                }
                catch (Exception eeee)
                {
                    MessageBox.Show(eeee.Message);
                }
            }
        }
    }
}
