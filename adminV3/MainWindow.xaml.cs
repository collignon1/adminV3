using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Extensions.Options;
using adminV3.View;


namespace adminV3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void classes_Click(object sender, RoutedEventArgs e)
        {

            vide.Children.Clear();
            View_classes view_classes = new View_classes();
            vide.Children.Add(view_classes);
        }

        private void date_Click(object sender, RoutedEventArgs e)
        {
            vide.Children.Clear();
            View_dates view_Date = new View_dates();
            vide.Children.Add(view_Date);
        }

        private void capteur_Click(object sender, RoutedEventArgs e)
        {
            vide.Children.Clear();
            capteurs Capteur = new capteurs();
            vide.Children.Add(Capteur);
        }

        private void SOS_Click(object sender, RoutedEventArgs e)
        {
            vide.Children.Clear();
            SOS sos = new SOS();
            vide.Children.Add(sos);
        }

        private void user_Click(object sender, RoutedEventArgs e)
        {
            vide.Children.Clear();
            user User = new user();
            vide.Children.Add(User);
        }

        private void offres_Click(object sender, RoutedEventArgs e)
        {
            vide.Children.Clear();
            ViewOffresPro Offres = new ViewOffresPro();
            vide.Children.Add(Offres);
        }
    }
}