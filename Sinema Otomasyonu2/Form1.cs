using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sinema_Otomasyonu2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        SqlConnection baglanti = new SqlConnection("Data Source=5.180.104.138\\MSSQLSERVER2012;Initial Catalog=test;Persist Security Info=True;User ID=emirhan;Password=jtZ86c~5");


        private void Form1_Load(object sender, EventArgs e)
        {

            baglanti.Open();
            string sorgu = "Select Max(koltukno) From salon1";
            int deger;
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            deger = Convert.ToInt32(komut.ExecuteScalar()) + 1;
            baglanti.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Salon1 salon1 = new Salon1();
            salon1.Show();
            this.Hide();
        }


        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salon2 salon2 = new Salon2();
            salon2.Show();
            this.Hide();
        }

    }
}
