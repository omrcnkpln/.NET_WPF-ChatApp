using ChatApp.Client.Communication;
using System.Text;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace ChatApp.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MySocketClient _mySocketClient;
        public string readata = null;

        public MainWindow(MySocketClient mySocketClient)
        {
            InitializeComponent();
            _mySocketClient = mySocketClient;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _mySocketClient.Connect();

            Thread aaa = new Thread(_mySocketClient.GetMessages);
            aaa.Start();

            string message = textBox1.Text;
            _mySocketClient.send(message);

            var ddd = _mySocketClient.readata;
            var ggg = textBox2.Text;
            var hhh = ddd + ggg;

            //textBox2.Text = textBox2.Text + _mySocketClient.readata;
            textBox2.Text = hhh;
        }
    }
}
