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

namespace exercisecrud
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=ROG-GL552JX;Initial Catalog=exerciseCRUD;Persist Security Info=True;User ID=sa;Password=Ajpramudita2315");
        
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAllRecords();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string status = "";
            if(radioButton1.Checked==true)
            {
                status = radioButton1.Text;
            }
            else
            {
                status = radioButton2.Text;
            }
            SqlCommand com = new SqlCommand("exec dbo.Obat_Insert'"+int.Parse(textBox1.Text)+"','"+textBox2.Text+ "','" + comboBox1.Text + "','" + status +"','" +DateTime.Parse (dateTimePicker1.Text) + "'", con);
            com.ExecuteNonQuery();
            MessageBox.Show("Berhasil Menyimpan");
            LoadAllRecords();
        }
        void LoadAllRecords()
        {
            SqlCommand com = new SqlCommand("exec dbo.Obat_View", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string status = "";
            if (radioButton1.Checked == true)
            {
                status = radioButton1.Text;
            }
            else
            {
                status = radioButton2.Text;
            }
            SqlCommand com = new SqlCommand("exec dbo.Obat_Update'" + int.Parse(textBox1.Text) + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + status + "','" + DateTime.Parse(dateTimePicker1.Text) + "'", con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Berhasil Update");
            LoadAllRecords();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Konfirmasi Hapus Data ini ?", "Hapus", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand com = new SqlCommand("exec dbo.Obat_Delete'" + int.Parse(textBox1.Text) + "'", con);
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Berhasil Hapus");
                LoadAllRecords();
            }
        }
    }
}
