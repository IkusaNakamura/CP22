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
    /// Логика взаимодействия для Roles.xaml
    /// </summary>
    public partial class Roles : Page
    {
        private Role _role = new Role();
        public Roles(Role selectRole)
        {
            InitializeComponent();
            if (selectRole != null)
                _role = selectRole;

            DataContext = _role;
        }

        private void SeveBtClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_role.NameRole))
                errors.AppendLine("Нет названия роли");

            if (errors.Length >0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_role.ID == 0) PoliclinicaEntities.GetContext().Role.Add(_role);
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
