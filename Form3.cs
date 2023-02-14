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

namespace Bilgisel
{
    public partial class Form3 : Form
    {
        DBOperations dbo = new DBOperations();
        Form1 frm1 = new Form1();
        public Form3()
        {
            InitializeComponent();
        }
        public int getId(int x)
        {
            int num;
            if (x == 2 || x==4)
            {
                 num = Convert.ToInt32(textBox10.Text);
            }
            else            
                num = Convert.ToInt32(textBox17.Text);
                        
            return num;
        }
        private void button1_Click(object sender, EventArgs e) 
        {
            string qstn = textBox1.Text;
            string a = textBox2.Text;
            string b = textBox3.Text;
            string c = textBox4.Text;
            string d = textBox5.Text;
            string answ = textBox7.Text;
           // int newId = Convert.ToInt32(textBox22.Text);
            dbo.addQuestion(qstn, a, b, c, d, answ);
            textBox1.Text= " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox7.Text = " ";
           // textBox22.Text = " ";
            MessageBox.Show("Kayıt Başarıyla Eklendi.");
        }// Insert Button
        private void button2_Click(object sender, EventArgs e) 
        {
            int x = 2;
            int id = getId(x);
            string qstn = textBox14.Text;
            string a = textBox13.Text;
            string b = textBox12.Text;
            string c = textBox11.Text;
            string d = textBox10.Text;
            string answ = textBox8.Text;
            dbo.uptadeQuestion(qstn, a, b, c, d, answ, id);
            textBox14.Text = " ";
            textBox13.Text = " ";
            textBox12.Text = " ";
            textBox11.Text = " ";
            textBox10.Text = " ";
            textBox8.Text = " ";
            MessageBox.Show("Kayıt Başarıyla Güncellendi.");
        } // Update Button
        private void button3_Click(object sender, EventArgs e) 
        {
            int x = 3;
            DataTable dt = new DataTable();
            string sql = "select * from Sorular where ID=" + getId(x);
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-K6L0EDQ;Initial Catalog=BilgiselDB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                textBox20.Text = dt.Rows[0][1].ToString();
                textBox19.Text = dt.Rows[0][2].ToString();
                textBox18.Text = dt.Rows[0][3].ToString();
                textBox17.Text = dt.Rows[0][4].ToString();
                textBox16.Text = dt.Rows[0][5].ToString();
                textBox6.Text = dt.Rows[0][6].ToString();
            }
            connection.Close();
        }// Data fetching button for Delete Page 

        private void button4_Click(object sender, EventArgs e) 
        {
            int x = 4;
            DataTable dt = new DataTable();
            string sql = "select * from Sorular where ID=" + getId(x);
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-K6L0EDQ;Initial Catalog=BilgiselDB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                textBox14.Text = dt.Rows[0][1].ToString();
                textBox13.Text = dt.Rows[0][2].ToString();
                textBox12.Text = dt.Rows[0][3].ToString();
                textBox11.Text = dt.Rows[0][4].ToString();
                textBox10.Text = dt.Rows[0][5].ToString();
                textBox8.Text = dt.Rows[0][6].ToString();
            }
            connection.Close();
        }// Data fetching button for Update Page       
        private void button5_Click(object sender, EventArgs e) // Sil Butonu
        {
            string qstn = textBox20.Text;
            string a = textBox19.Text;
            string b = textBox18.Text;
            string c = textBox17.Text;
            string d = textBox16.Text;
            string answ = textBox6.Text;
            int newId = Convert.ToInt32(textBox17.Text);
            dbo.deleteQuestion(qstn, a, b, c, d, answ, newId);
            textBox20.Text = " ";
            textBox19.Text = " ";
            textBox18.Text = " ";
            textBox17.Text = " ";
            textBox16.Text = " ";
            textBox15.Text = " ";
            textBox6.Text = " ";
            MessageBox.Show("Kayıt Başarıyla Silindi.");
        }// Delete Button
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet results = dbo.displayQuestions();
            dataGridView1.DataSource = results.Tables[0];
            if (results.Tables[0].Rows.Count == 0)
                MessageBox.Show("Kayıt Yok");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            frm1.Show();
        }
    }
}
