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
using adminV3.smart_displayDB;

namespace adminV3.View
{
    /// <summary>
    /// Logique d'interaction pour View_dates.xaml
    /// </summary>
    public partial class View_dates : UserControl
    {
        DAODatesImportantes DAODatesimportantes;
        public View_dates()
        {
            InitializeComponent();
            DAODatesimportantes = new DAODatesImportantes();
            DG_dates.ItemsSource = DAODatesimportantes.GetAllDatesImportantes();

        }

        private void BT_ajouter_Click(object sender, RoutedEventArgs e)
        {
            DateImportante date_imp = new DateImportante();
            string type = "";
            //récupération des données et ajout dans la base de données
            DateTime? selectedDate = DP_Dates.SelectedDate;
            if (selectedDate == null)
            {
                MessageBox.Show("impossible, la date est vide");
            }
            else if (CB_DS == null & CB_Event == null & CB_reunion == null)
            {
                MessageBox.Show("impossible, le type est vide");
            }
            else if (TB_Dates.Text == "")
            {
                MessageBox.Show("impossible, le contenu est vide");
            }
            else
            {
                if (CB_reunion != null)
                {
                    type = "reunion";
                }
                else if (CB_Event != null)
                {
                    type = "Event";
                }
                else if (CB_DS != null)
                {
                    type = "DS";
                }
                // Conversion de DateTime en DateOnly
                DateOnly date = DateOnly.FromDateTime(selectedDate.Value);
                string info = TB_Dates.Text;
                date_imp.Date = date;
                date_imp.Info = info;
                date_imp.Type = type;
                DAODatesimportantes.AddDateImportante(date_imp); 
                DG_dates.ItemsSource = DAODatesimportantes.GetAllDatesImportantes();
            }
        }

        private void BT_effacer_Click(object sender, RoutedEventArgs e)
        {
            TB_Dates.Text = "";
            DP_Dates.SelectedDate = null;
            CB_DS = null;
            CB_Event = null;
            CB_reunion = null;
        }

        private void BT_supprimer_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(TB_id.Text);
            DAODatesimportantes.RemoveDateImportante(id);
            DG_dates.ItemsSource = DAODatesimportantes.GetAllDatesImportantes();
        }

        private void CB_DS_Checked(object sender, RoutedEventArgs e)
        {
            CB_Event = null;
            CB_reunion = null;
        }

        private void CB_reunion_Checked(object sender, RoutedEventArgs e)
        {
            CB_DS = null;
            CB_Event = null;
        }

        private void CB_Event_Checked(object sender, RoutedEventArgs e)
        {
            CB_DS = null;
            CB_reunion = null;
        }
    }
}
