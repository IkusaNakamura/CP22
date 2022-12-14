﻿using System;
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
    /// Логика взаимодействия для ViewRole.xaml
    /// </summary>
    public partial class ViewRole : Page
    {
        public ViewRole()
        {
            InitializeComponent();
            
            try
            {
                DGRole.ItemsSource = PoliclinicaEntities.GetContext().Role.ToList();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        private void addRole_Click(object sender, RoutedEventArgs e)//чистый возврат
        {
            ManegerFrames.MainFrame.Navigate(new PagesForms.Roles(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) //обновление страницы при возвращении
        {
            PoliclinicaEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGRole.ItemsSource = PoliclinicaEntities.GetContext().Role.ToList();
        }

        private void BtEdit_Click(object sender, RoutedEventArgs e)//Редактирование
        {
            ManegerFrames.MainFrame.Navigate(new PagesForms.Roles((sender as Button).DataContext as Role));
        }
    }
}
