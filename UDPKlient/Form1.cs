using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDPKlient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string host = textBox1.Text;
            int port = (int)numericUpDown1.Value;
            try
            {
                UdpClient klient = new UdpClient(host, port);
                Byte[] dane = Encoding.ASCII.GetBytes(textBox2.Text);
                klient.Send(dane, dane.Length);
                listBox1.Items.Add("Wysyłanie wiadomości do hosta " + host + ":" + port);
                klient.Close();
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("Błąd: Nie udało się wysłać wiadomości!");
                MessageBox.Show(ex.ToString(), "Błąd");
            }
        }
    }
}
