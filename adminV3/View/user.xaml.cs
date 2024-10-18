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
    /// Logique d'interaction pour user.xaml
    /// </summary>
    public partial class user : UserControl
    {
        DAOUser DAOuser;
        public user()
        {
            InitializeComponent();
            DAOuser = new DAOUser();
            DG_User.ItemsSource = DAOuser.GetUsers();
        }

        private void BT_effacer_Click(object sender, RoutedEventArgs e)
        {
            TB_Nom.Text = "";
            TB_mail.Text = "";
            RB_Admin.IsChecked = false;
            RB_Eleve.IsChecked = false;
            RB_Admin.IsChecked = false;
        }

        private void BT_ajouter_Click(object sender, RoutedEventArgs e)
        {

            User user = new User();
            string nom = "";
            string mail = "";
            string statut = "";
            if (TB_Nom.Text == "" || TB_mail.Text == "" || RB_Admin.IsChecked == false && RB_Eleve.IsChecked == false && RB_Admin.IsChecked == false)
            {
                MessageBox.Show("impossible, les zones sont vides");
            }
            else
            {
                nom = TB_Nom.Text;
                mail = TB_mail.Text;
                if (RB_Admin.IsChecked == true)
                {
                    statut = "admin";
                }
                else if (RB_Eleve.IsChecked == true)
                {
                    statut = "eleve";
                }
                else if (RB_Admin.IsChecked == true)
                {
                    statut = "Professeur";
                }
                DateTime? selectedDate = DP_date.SelectedDate;
                DateOnly date = DateOnly.FromDateTime(selectedDate.Value);
                user.Nom = nom;
                user.Email = mail;
                user.DateDeNaissance = date;
                user.Statut = statut;
                DAOuser.AddUser(user);
                DG_User.ItemsSource = DAOuser.GetUsers();
            }
        }

        private void BT_supprimer_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(TB_id.Text);
            DAOuser.RemoveUser(id);
            DG_User.ItemsSource = DAOuser.GetUsers();

        }

        private void BT_revenir_Click(object sender, RoutedEventArgs e)
        {
            DG_User.ItemsSource = DAOuser.GetUsers();
        }

        private void BT_valider_Click(object sender, RoutedEventArgs e)
        {
            if (RB_Admin2.IsChecked == false && RB_Eleve2.IsChecked == false && RB_Professeur2.IsChecked == false)
            {
                MessageBox.Show("impossible, les zones sont vides");
            }

            else
            {
                if (RB_Admin2.IsChecked == true)
                {
                    DG_User.ItemsSource = DAOuser.GetUsersByStatut("admin");
                }
                else if (RB_Eleve2.IsChecked == true)
                {
                    DG_User.ItemsSource = DAOuser.GetUsersByStatut("eleve");
                }
                else if (RB_Professeur2.IsChecked == true)
                {
                    DG_User.ItemsSource = DAOuser.GetUsersByStatut("Professeur");
                }

            }
        }
    }
}
