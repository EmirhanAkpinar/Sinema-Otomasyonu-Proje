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
    public partial class Salon1 : Form
    {
        public Salon1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=5.180.104.138\\MSSQLSERVER2012;Initial Catalog=test;Persist Security Info=True;User ID=emirhan;Password=jtZ86c~5");
        public void Salon1_Load(object sender, EventArgs e)
        {
            addbuttons();
        }
        SqlCommand cmd;
        SqlDataReader dr;
        int counter;
        int tiklanan;
        void addbuttons()
        {
            int button_x = 5;
            int button_y = 5;
            baglanti.Open();
            string sorgu = "Select Max(koltukno) From salon1";
            int deger;
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            deger = Convert.ToInt32(komut.ExecuteScalar()) + 1;
            baglanti.Close();








            for (int i = 1; i <= deger - 1; i++)
            {
                baglanti.Open();
                cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "select * from salon1 where koltukno="+i;
                dr = cmd.ExecuteReader();
                
              
                Button btn = new Button();
                dr.Read();
                if (Convert.ToBoolean(dr[1]) == false)
                {
                    btn.BackColor = Color.Green; btn.Enabled = true;
                    comboBox1.Items.Add(i);
                }
                else
                {
                    btn.BackColor = Color.Red; btn.Enabled = false;
                }

                btn.Text = "" + i;
                btn.Tag = i;
                btn.Height = 50;
                btn.Width = 50;
                btn.Location = new Point(button_x, button_y);
                button_x += 60;
                btn.Name = Convert.ToString(counter);
                panel1.Controls.Add(btn);

                btn.Click += new EventHandler(buttonClick);

                counter++;
                if (counter % 10 == 0)
                {
                    button_y += 90;
                    button_x = 5;
                }
                baglanti.Close();
            }
        }
        void buttonClick(object sender, EventArgs e)
        {
            Button tiklananBtn = (Button)sender;

            tiklanan = Convert.ToInt32(tiklananBtn.Tag);
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            panel1.Controls.Clear();

            addbuttons();
        }
    }
}
