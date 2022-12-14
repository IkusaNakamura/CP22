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
    /// Логика взаимодействия для PolicyOrg.xaml
    /// </summary>
    public partial class PolicyOrg : Page
    {
        private Policy _policy = new Policy();
        public PolicyOrg(Policy selectPolicy)
        {
            InitializeComponent();
            if (selectPolicy != null)
                _policy = selectPolicy;
            DataContext = _policy;
        }
        private void SeveBtClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_policy.InsuranceOrganization))
                errors.AppendLine("Пустое название");
            if (string.IsNullOrWhiteSpace(_policy.Adres))
                errors.AppendLine("Нет адреса");
            if (string.IsNullOrWhiteSpace(_policy.RepresentativeFN))
                errors.AppendLine("Пустое имя");
            if (string.IsNullOrWhiteSpace(_policy.RepresentativeLN))
                errors.AppendLine("Пустая фамилия");
            
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_policy.ID == 0) PoliclinicaEntities.GetContext().Policy.Add(_policy);
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
