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
    /// Logique d'interaction pour ViewOffresPro.xaml
    /// </summary>
    public partial class ViewOffresPro : UserControl
    {
        DAOOffresProfessionnelle DAOOffresprofessionnelle;
        OffresProfessionnelle offresProfessionnelle;
        public ViewOffresPro()
        {
            InitializeComponent();
            DAOOffresprofessionnelle = new DAOOffresProfessionnelle();
            DG_offres.ItemsSource = DAOOffresprofessionnelle.GetAllOffresProfessionnelles();
            OffresProfessionnelle offresProfessionnelle = new OffresProfessionnelle();
        }

        private void BT_ajouter_Click(object sender, RoutedEventArgs e)
        {
            offresProfessionnelle = new OffresProfessionnelle();
            DateTime? selectedDate = DP_debut.SelectedDate;
            if (TB_nom.Text == "" || selectedDate==null)
            {
                MessageBox.Show("impossible, les zones sont vides");
            }
            else
            {
                DateOnly date = DateOnly.FromDateTime(selectedDate.Value);
                string nom = TB_nom.Text;
                offresProfessionnelle.Entreprise = nom;
                offresProfessionnelle.DatePoste = date;
                DAOOffresprofessionnelle.AddOffreProfessionnelle(offresProfessionnelle);
                DG_offres.ItemsSource = DAOOffresprofessionnelle.GetAllOffresProfessionnelles();
            }
        }
        private void BT_effacer_Click(object sender, RoutedEventArgs e)
        {
            TB_nom.Text = "";
            DP_debut.SelectedDate = null;
        }

        private void BT_supprimer_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(TB_id.Text);
            DAOOffresprofessionnelle.RemoveOffreProfessionnelle(id);
            DG_offres.ItemsSource = DAOOffresprofessionnelle.GetAllOffresProfessionnelles();
        }
    }
}
