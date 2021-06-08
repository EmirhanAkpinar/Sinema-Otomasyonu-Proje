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
    public partial class Salon2 : Form
    {
        public Salon2()
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


        public void ButtonTransparent(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.Transparent;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
        }









        void addbuttons()
        {
            int button_x = 8;
            int button_y = 8;
            baglanti.Open();
            string sorgu = "Select Max(koltukno) From salon2";
            int deger;
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            deger = Convert.ToInt32(komut.ExecuteScalar()) + 1;
            baglanti.Close();








            for (int i = 1; i <= deger - 1; i++)
            {
                baglanti.Open();
                cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "select * from salon2 where koltukno="+i;
                dr = cmd.ExecuteReader();
                
              
                Button btn = new Button();
                dr.Read();
                if (Convert.ToBoolean(dr[1]) == false)
                {
                    btn.BackgroundImage = Image.FromFile(Application.ExecutablePath + @"\..\..\..\images\bos.png");
                    btn.BackgroundImageLayout = ImageLayout.Zoom;
                    btn.Enabled = true;
                    comboBox1.Items.Add(i);
                }
                else
                {
                    btn.BackgroundImage = Image.FromFile(Application.ExecutablePath + @"\..\..\..\images\dolu.png");
                    btn.BackgroundImageLayout = ImageLayout.Zoom;
                    btn.Enabled = false;
                }

                btn.Text = "" + i;
                btn.Tag = i;
                btn.Height = 60;
                btn.Width = 60;
                btn.Location = new Point(button_x, button_y);
                button_x += 60;
                btn.Name = Convert.ToString(counter);
                btn.Cursor = Cursors.Hand;
                ButtonTransparent(btn);
                panel1.Controls.Add(btn);

                btn.Click += new EventHandler(buttonClick);

                counter++;
                if (counter % 10 == 0)
                {
                    button_y += 95;
                    button_x = 7;
                }
                baglanti.Close();
            }
        }
        void buttonClick(object sender, EventArgs e)
        {
            Button tiklananBtn = (Button)sender;

            tiklanan = Convert.ToInt32(tiklananBtn.Tag);
            comboBox1.SelectedItem = tiklanan;


        }

    

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                if (bunifuTextBox1.Text != null)
                {
                    cmd = new SqlCommand();
                    baglanti.Open();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "update salon2 set koltukdurum=1,satinalan='" + bunifuTextBox1.Text + "' where koltukno=" + comboBox1.SelectedItem + "";
                    cmd.ExecuteNonQuery();
                    baglanti.Close();

                    comboBox1.Items.Clear();
                    panel1.Controls.Clear();
                    addbuttons();
                    bunifuTextBox1.Text = null;
                }
                else
                {
                }

            }
            else
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
