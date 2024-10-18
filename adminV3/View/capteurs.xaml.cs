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
using adminV3.service.DAO;

namespace adminV3.View
{
    /// <summary>
    /// Logique d'interaction pour capteurs.xaml
    /// </summary>
    public partial class capteurs : UserControl
    {
        DAOCo2 DAOCO2;
        DAOTemperature DAOtemperature;
        DAOLuminosite DAOLum;
        public capteurs()
        {
            InitializeComponent();
            DAOCO2 = new DAOCo2();
            DAOtemperature = new DAOTemperature();
            DAOLum = new DAOLuminosite();
            DG_CO2.ItemsSource = DAOCO2.GetAllCo2();
            DG_LUM.ItemsSource = DAOLum.GetAllLuminosites();
            DG_TEMP.ItemsSource = DAOtemperature.GetAllTemperatures();
        }


        private void BT_total_Click(object sender, RoutedEventArgs e)
        {
            DateTime? selectedDate = DP_date.SelectedDate;
            if (selectedDate == null & TB_bysalle.Text == "")
            {
                MessageBox.Show("impossible, les zones sont vides");
            }
            else if (selectedDate == null)
            {
                MessageBox.Show("impossible, la date est vide");
            }
            else if (TB_bysalle.Text == "")
            {
                MessageBox.Show("impossible, la salle est vide");
            }

            else if (selectedDate.HasValue)
            {
                int id = Convert.ToInt32(TB_bysalle.Text);
                // Conversion de DateTime en DateOnly
                DateOnly date = DateOnly.FromDateTime(selectedDate.Value);
                DG_CO2.ItemsSource = DAOCO2.GetCo2ByAfficheurIdAndDate(id, date);
                DG_LUM.ItemsSource = DAOLum.GetLuminositeByAfficheurIdAndDate(id, date);
                DG_TEMP.ItemsSource = DAOtemperature.GetTemperatureByAfficheurIdAndDate(id, date);
                // Affichage du résultat
            }

        }

        private void BT_salle_Click(object sender, RoutedEventArgs e)
        {
            if (TB_bysalle.Text == "")
            {
                MessageBox.Show("impossible, la salle est vide");
            }
            else
            {
                int id = Convert.ToInt32(TB_bysalle.Text);
                DG_CO2.ItemsSource = DAOCO2.GetCo2ByAfficheurId(id);
                DG_LUM.ItemsSource = DAOLum.GetLuminositeByAfficheurId(id);
                DG_TEMP.ItemsSource = DAOtemperature.GetTemperatureByAfficheurId(id);
            }

        }

        private void BT_date_Click(object sender, RoutedEventArgs e)
        {
            DateTime? selectedDate = DP_date.SelectedDate;
            if (selectedDate == null)
            {
                MessageBox.Show("impossible, la date est vide");
            }
            else if(selectedDate.HasValue)
            {
                // Conversion de DateTime en DateOnly
                DateOnly date = DateOnly.FromDateTime(selectedDate.Value);
                DG_CO2.ItemsSource = DAOCO2.GetCo2ByDate(date);
                DG_LUM.ItemsSource = DAOLum.GetLuminositeByDate(date);
                DG_TEMP.ItemsSource = DAOtemperature.GetTemperatureByDate(date);
                // Affichage du résultat
            }
        }

        private void BT_annuler_Click(object sender, RoutedEventArgs e)
        {
            TB_bysalle.Text = "";
            DP_date.SelectedDate = null;
            DG_CO2.ItemsSource = DAOCO2.GetAllCo2();
            DG_LUM.ItemsSource = DAOLum.GetAllLuminosites();
            DG_TEMP.ItemsSource = DAOtemperature.GetAllTemperatures();  
        }
    }
}
