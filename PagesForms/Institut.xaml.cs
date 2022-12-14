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
    /// Логика взаимодействия для Institut.xaml
    /// </summary>
    public partial class Institut : Page
    {
        private Institution _Institut = new Institution();
        public Institut(Institution selectInst)
        {
            InitializeComponent();
            if (selectInst != null) _Institut = selectInst;
            DataContext = _Institut;
        }
        private void SeveBtClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_Institut.Name))
                errors.AppendLine("Нет названия");
            if (string.IsNullOrWhiteSpace(_Institut.Adres))
                errors.AppendLine("Нет адреса");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_Institut.Uid == 0) PoliclinicaEntities.GetContext().Institution.Add(_Institut);
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
