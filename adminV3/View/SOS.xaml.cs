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
using M2Mqtt;


namespace adminV3.View
{
    /// <summary>
    /// Logique d'interaction pour SOS.xaml
    /// </summary>
    public partial class SOS : UserControl
    {
        public SOS()
        {

            InitializeComponent();
            
        }

        private void BT_SOS_Click(object sender, RoutedEventArgs e)
        {
            //// Créez une instance du client MQTT
            //MqttClient client = new MqttClient(""); // Remplacez par l'adresse de votre broker

            //// Connectez-vous au broker
            //string clientId = Guid.NewGuid().ToString();
            //client.Connect(clientId);

            //// Préparez le message à envoyer
            //string topic = "test/topic"; // Remplacez par le topic que vous souhaitez utiliser
            //string message = "";
            //byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            //// Publiez le message sur le topic
            //client.Publish(topic, messageBytes, MqttMsgBase.QOS_0, false);

            //// Déconnectez-vous du broker
            //client.Disconnect();

            //Console.WriteLine("Message envoyé !");
        }
    }
}
