using System;
using System.Messaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
                if (mex.intero > 10) pannello.Background = new SolidColorBrush(Colors.Black);
                else pannello.Background = new SolidColorBrush(Colors.Red);
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
