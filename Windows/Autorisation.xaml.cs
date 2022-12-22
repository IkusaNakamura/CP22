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
using System.Windows.Shapes;

namespace CP22.Windows
{
    /// <summary>
    /// Логика взаимодействия для Autorisation.xaml
    /// </summary>
    public partial class Autorisation : Window
    {
        bool isLogin = false;
        public Autorisation()
        {
            InitializeComponent();
            
        }
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                pwdTextBox.Text = pwdPasswordBox.Password; // скопируем в TextBox из PasswordBox
                pwdTextBox.Visibility = Visibility.Visible; // TextBox - отобразить
                pwdPasswordBox.Visibility = Visibility.Collapsed; // PasswordBox - скрыть
            }
            else
            {
                pwdPasswordBox.Password = pwdTextBox.Text; // скопируем в PasswordBox из TextBox 
                pwdTextBox.Visibility = Visibility.Collapsed; // TextBox - скрыть
                pwdPasswordBox.Visibility = Visibility.Visible; // PasswordBox - отобразить
            }
        }
        
        private void loginBT(object sender, RoutedEventArgs e)
        {
            if (checkBoxPwd.IsChecked.Value) pwdPasswordBox.Password = pwdTextBox.Text; // скопируем в PasswordBox из TextBox 
            if (ManegerFrames.LoginInSys(Login.Text, pwdPasswordBox))
            {
                Owner.Show();
                Owner.IsHitTestVisible = true;
                isLogin = true;
                Hide();
                pwdPasswordBox.Password = null;
                pwdTextBox.Text = null;
                Login.Text = null;
            }
            else
            {
                isLogin = false;
                MessageBox.Show("Неверный логин или пароль","Ошибка входа");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!isLogin) { Owner.Close(); }             
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            isLogin = false;
        }
    }
}
