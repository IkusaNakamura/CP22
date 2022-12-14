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

namespace CP22.PagesForms
{
    /// <summary>
    /// Логика взаимодействия для CardsType.xaml
    /// </summary>
    public partial class CardsType : Page
    {
        private CardTyps _cardtyps = new CardTyps();
        public CardsType(CardTyps selectType)
        {
            InitializeComponent();
            if (selectType != null)
                _cardtyps = selectType;
            DataContext = _cardtyps;
        }
        private void SeveBtClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_cardtyps.Name))
                errors.AppendLine("Пустое имя");
            

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_cardtyps.ID == 0) PoliclinicaEntities.GetContext().CardTyps.Add(_cardtyps);
            try
            {
                PoliclinicaEntities.GetContext().SaveChanges();
                MessageBox.Show("Сохранено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

   
    }
}
