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
    /// Логика взаимодействия для Patients.xaml
    /// </summary>
    public partial class Patient : Page
    {
        private Patients _patients = new Patients();
        
        public Patient(Patients selectPatient)
        {
            InitializeComponent();
            if (selectPatient != null)
                _patients = selectPatient;
            DataContext = _patients;
            OrgBox.ItemsSource = PoliclinicaEntities.GetContext().Policy.ToList();
        }

        private void Click_contactEdit(object sender, RoutedEventArgs e)
        {

        }

        private void SeveBtClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_patients.LName))
                errors.AppendLine("Пустое имя");
            if (string.IsNullOrWhiteSpace(_patients.FName))
                errors.AppendLine("Пустое имя");
            if (string.IsNullOrWhiteSpace(_patients.LName))
                errors.AppendLine("Пустая фамилия");
           
            if (string.IsNullOrWhiteSpace(_patients.Sex))
                    errors.AppendLine("Нет пола");
            if (string.IsNullOrWhiteSpace(_patients.Passport))
                errors.AppendLine("Нет паспорта");
            if (string.IsNullOrWhiteSpace(_patients.Policy))
                errors.AppendLine("Нет полиса");
            if (string.IsNullOrWhiteSpace(_patients.BurthPlase))
                errors.AppendLine("Нет места рождения");
            if (string.IsNullOrWhiteSpace(_patients.BirthCertificateNum))
                errors.AppendLine("Нет свидетельства");
            if (string.IsNullOrWhiteSpace(_patients.BirthСertificateSeria))
                errors.AppendLine("Нет свидетельства");
            if (_patients.Policy1 == null)
                errors.AppendLine("Нет организации");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_patients.ID == 0) PoliclinicaEntities.GetContext().Patients.Add(_patients);
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
