using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Printing;
using System.Windows;
using System.Windows.Threading;

namespace RockPaperScissors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int port = 12345;
        StreamReader reader;
        StreamWriter writer;
        DispatcherTimer timer;
        bool sent_text = false;
        bool read_text = false;
        string my_text = "";
        string op_text = "";
        int count = 0;
        int myCount = 0;
        int opCount = 0;
        public MainWindow()
        {
            InitializeComponent();
            setButtons(false);
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 5);
        }
        private void setButtons(bool enable)
        {
            button_rock.IsEnabled = enable;
            button_scissors.IsEnabled = enable;
            button_paper.IsEnabled = enable;

        }
        private void button_start_Click_1(object sender, RoutedEventArgs e)
        {
            if ((bool)radio_server.IsChecked)
            {
                startServer();
            }
            else if ((bool)radio_client.IsChecked)
            {
                startClient();
            }
            setButtons(true);
            button_start.IsEnabled = false;
            timer.Start();
        }
        private void startServer()
        {
            TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Parse(text_ip.Text), port));
            listener.Start();
            TcpClient server = listener.AcceptTcpClient();
            server.ReceiveTimeout = 50;
            reader = new(server.GetStream());
            writer = new(server.GetStream());
            writer.AutoFlush = true;
        }
        private void startClient()
        {
            TcpClient client = new TcpClient();
            client.Connect(text_ip.Text, port);
            client.ReceiveTimeout = 50;
            reader = new(client.GetStream());
            writer = new(client.GetStream());
            writer.AutoFlush = true;

        }

        private void button_rock_Click(object sender, RoutedEventArgs e)
        {
            send("R");
        }

        private void button_scissors_Click(object sender, RoutedEventArgs e)
        {
            send("S");
        }

        private void button_paper_Click(object sender, RoutedEventArgs e)
        {
            send("P");
        }
        private void send(string text)
        {
            if (sent_text) return; 
            writer.WriteLine(text);
            sent_text = true;
            my_text = text;
            setButtons(false);
        }
        private string read()
        {             
            if (read_text) return "";

            try
            {
                string text;
                text = reader.ReadLine();
                read_text = true;
                op_text = text;
                text_debug.Text += "send" + text + Environment.NewLine;

                return text;
            }
            catch { return ""; }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            string text = read();
            if(sent_text && read_text)
            {
                int state = Compare(my_text, op_text);
                string res = "";
                if(state == 0) { res = "Draw"; }
                else if(state == 1) { res = "Winnig"; myCount++; }
                else if(state == 2) { res = "Loss"; opCount++; }
                lbl_state.Content =  res;
                sent_text = false;
                read_text = false;
                count++;
                my_text = "";
                op_text = "";
                if (count < 3) setButtons(true);
                else { if (myCount > opCount) lbl_count.Content = "You won with the score: " + myCount.ToString() + ":" + opCount.ToString();
                       else if (myCount < opCount) lbl_count.Content = "You loose with the score: " + myCount.ToString() + ":" + opCount.ToString();  };
            }
        }

        private int Compare(string hand1, string hand2)
        {
            if (hand1 == hand2) return 0;
            else if (hand1 == "R")
            {
                if (hand2 == "S") { return 1; }
                else{ return 2; }
            }
            else if (hand1 == "S")
            {
                if (hand2 == "P") { return 1; }
                else { return 2; }
            }
            else if (hand1 == "P")
            {
                if (hand2 == "R") { return 1; }
                else  { return 2; }
            }
             return 0;

        }
    }                     
            
}
