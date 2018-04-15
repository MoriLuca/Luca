using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MessageQueue m = new MessageQueue(@".\Private$\Luca");

        public MainWindow()
        {
            InitializeComponent();
            if (!MessageQueue.Exists(@".\Private$\Luca"))
                MessageQueue.Create(@".\Private$\Luca");

            
            m.Formatter = new XmlMessageFormatter(new Type[] { typeof(Mex) });
            m.ReceiveCompleted += new ReceiveCompletedEventHandler(Reading);
            m.BeginReceive();
        }

        public void Reading(object sender, ReceiveCompletedEventArgs e)
        {
            Mex mex = (Mex)e.Message.Body;
            this.Dispatcher.Invoke((Action)(() =>
            {
                pannello.Children.Add(new Button() { Content = mex.intero + " - " + mex.nome });
            }));
            m.BeginReceive();

        }



        public class Mex
        {
            public int intero { get; set; } = 0;
            public string nome { get; set; } = "Luca";
        }
    }
}
