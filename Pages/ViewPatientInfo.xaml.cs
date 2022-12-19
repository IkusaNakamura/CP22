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
    /// Логика взаимодействия для ViewPatientInfo.xaml
    /// </summary>
    public partial class ViewPatientInfo : Page
    {
        private MedCards _medCards = new MedCards();
      //  private CP22.Patients _patients;
        PoliclinicaEntities _PoliclinicaEntities = new PoliclinicaEntities();
        public ViewPatientInfo(MedCards selectMedCard)
        {
            InitializeComponent();
            _medCards = selectMedCard;
            ///привязка данных к куску с инфой
          //  _patients = _PoliclinicaEntities.Patients.FirstOrDefault(d => d.MedCards == _medCards.Patients);
            //_patients = PoliclinicaEntities.GetContext().Patients.FirstOrDefault(x => x.ID ==_medCards.Patient);
          //  InfoPerson.DataContext = _patients;
          ///сбор списка для датагрид
            //var qerye =
            //    from MedicalHistory in _PoliclinicaEntities.MedicalHistory
            //    where MedicalHistory.Card == _medCards.ID
            //    orderby MedicalHistory.Datetime
            //    select new { MedicalHistory.Datetime, MedicalHistory.Doctor, MedicalHistory.Note};
           // DGNotes.ItemsSource = 
            try
            {
                
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) //обновление страницы при возвращении
        {
            PoliclinicaEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
          //  DGPatients.ItemsSource = PoliclinicaEntities.GetContext().Patients.ToList();
        }
    }
}
