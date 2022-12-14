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
    /// Логика взаимодействия для MedCards.xaml
    /// </summary>
    public partial class MedCard : Page
    {
        private MedCards _medCards = new MedCards();
        public MedCard(MedCards selectMedCard)
        {
            InitializeComponent();
            if (selectMedCard != null) _medCards = selectMedCard;
            DataContext = _medCards;
            PatientBox.ItemsSource = PoliclinicaEntities.GetContext().Patients.ToList();
            CardBox.ItemsSource = PoliclinicaEntities.GetContext().CardTyps.ToList();
            InstBox.ItemsSource = PoliclinicaEntities.GetContext().Institution.ToList();
        }
        private void SeveBtClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_medCards.Institution1 == null)
                errors.AppendLine("Не выбрано учреждение.");
            if (_medCards.Patients == null)
                errors.AppendLine("Не выбран пациент.");
            if (_medCards.CardTyps == null)
                errors.AppendLine("Не выбран тип карты.");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_medCards.ID == 0) PoliclinicaEntities.GetContext().MedCards.Add(_medCards);
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
