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
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class User : Page
    {
        private Users _users = new Users();
        public User(Users selectUsers)
        {
            InitializeComponent();
            if (selectUsers != null)
                _users = selectUsers;
            DataContext = _users;
            RoleBox.ItemsSource = PoliclinicaEntities.GetContext().Role.ToList();
        }
        private void SeveBtClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_users.FName))
                errors.AppendLine("Пустое имя");
            if (string.IsNullOrWhiteSpace(_users.LName))
                errors.AppendLine("Пустая фамилия");
            if (string.IsNullOrWhiteSpace(_users.JobTitle))
                errors.AppendLine("Пустая должность");
            if (string.IsNullOrWhiteSpace(_users.Specialosition))
                errors.AppendLine("Пустая специализация");
            if (string.IsNullOrWhiteSpace(_users.Login))
                errors.AppendLine("Нет логина");
            if (string.IsNullOrWhiteSpace(_users.Password))
                errors.AppendLine("Нет пароля");
            if (_users.Role1 == null)
                errors.AppendLine("Нет роли");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_users.ID == 0) PoliclinicaEntities.GetContext().Users.Add(_users);
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
