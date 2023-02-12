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
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Bilgisel
{
    public partial class Form2 : Form
    {        
        private List<string> Options;
        public int[] arr;
        public Form2()
        {
            InitializeComponent();
            arr = new int[countOfRecords()];
            createArray();
            Options = printQuestion();           
        }
        private int i = 0;
        private bool button1WasClicked = false;
        private bool button2WasClicked = false;
        private bool button3WasClicked = false;
        private bool button4WasClicked = false;
        private bool timer = false;

        private bool waitASecond()
        {
            timer1.Start();
            string time = timer1.ToString();
            if (time == "1")
                return true;
            else
                return false;
        }
        private void SetButtonAWasClicked(bool set)
        {
            button1WasClicked = set;
        }
        private void SetButtonBWasClicked(bool set)
        {
            button2WasClicked = set;
        }
        private void SetButtonCWasClicked(bool set)
        {
            button3WasClicked = set;
        }
        private void SetButtonDWasClicked(bool set)
        {
            button4WasClicked = set;
        }
        private void createArray()
        {
           for(int i=0; i < countOfRecords(); i++)
            {
                arr[i] = i;
            }
            shuffle(arr);
        }
        private void shuffle(int[] arr)
        {
            // Creating a object
            // for Random class
            Random r = new Random();
            int n = arr.Length;

            // Start from the last element and
            // swap one by one. We don't need to
            // run for the first element
            // that's why i > 0
            for (int i = n - 1; i >= 0; i--)
            {

                // Pick a random index
                // from 0 to i
                int j = r.Next(0, i + 1);

                // Swap arr[i] with the
                // element at random index
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        private DataTable fetchingData()
        {
            DataTable dt = new DataTable();
            string sql = "select * from Sorular where ID=" + arr[i];
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-K6L0EDQ;Initial Catalog=BilgiselDB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            connection.Close();
            return dt;
        }
        private DataTable getDataTable()
        {
            DataTable dt = new DataTable();
            string sql = "select * from Sorular";
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-K6L0EDQ;Initial Catalog=BilgiselDB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            connection.Close();
            return dt;
        }
        private List<string> printQuestion()
        {
            List<string> options = new List<string>();
            var dt = fetchingData();
            if (dt.Rows.Count > 0)
            {
                label5.Text = dt.Rows[0][1].ToString();
                buttonA.Text = dt.Rows[0][2].ToString();
                buttonB.Text = dt.Rows[0][3].ToString();
                buttonC.Text = dt.Rows[0][4].ToString();
                buttonD.Text = dt.Rows[0][5].ToString();
                /////////////////////////////////////////
                options.Add(buttonA.Text);
                options.Add(buttonB.Text);
                options.Add(buttonC.Text);
                options.Add(buttonD.Text);
                options.Add(dt.Rows[0][6].ToString());
            }
            return options;
        }
        private int countOfRecords()
        {
            var dt = getDataTable();
            int count = dt.Rows.Count;
            return count;
        }
        private void isCorrectAnswer(List<string> options)
        {
            //string soru = label5.Text;
            //string a = buttonA.Text;
            //string b = buttonB.Text;
            //string c = buttonC.Text;
            //string d = buttonD.Text;
            //string sql = "select Cevap where Id=" + 1;
            //string cevap = sql;
            //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-K6L0EDQ;Initial Catalog=BilgiselDB;Integrated Security=True");
            //SqlCommand cmd = new SqlCommand(sql, connection);
            //connection.Open();
            //// cmd.ExecuteNonQuery();
            //connection.Close();

                if (options[4] == options[0] && button1WasClicked)
                {
                    buttonA.BackColor = Color.Green;
                    buttonB.Enabled = false;
                    buttonC.Enabled = false;
                    buttonD.Enabled = false;
                    i++;
                    printQuestion();
                    buttonA.BackColor = Color.Silver;
                    buttonB.Enabled = true;
                    buttonC.Enabled = true;
                    buttonD.Enabled = true;
                }
                else if (options[4] == options[1] && button2WasClicked)
                {
                    buttonB.BackColor = Color.Green;
                    buttonD.Enabled = false;
                    buttonC.Enabled = false;
                    buttonA.Enabled = false;
                    i++;
                    printQuestion();
                    buttonB.BackColor = Color.Silver;
                    buttonA.Enabled = true;
                    buttonC.Enabled = true;
                    buttonD.Enabled = true;
                }
                else if (options[4] == options[2] && button3WasClicked)
                {
                    buttonC.BackColor = Color.Green;
                    buttonB.Enabled = false;
                    buttonD.Enabled = false;
                    buttonA.Enabled = false;
                    i++;
                    printQuestion();
                    buttonC.BackColor = Color.Silver;
                    buttonB.Enabled = true;
                    buttonA.Enabled = true;
                    buttonD.Enabled = true;
                }
                else if (options[4] == options[3] && button4WasClicked)
                {
                    buttonD.BackColor = Color.Green;
                    buttonB.Enabled = false;
                    buttonC.Enabled = false;
                    buttonA.Enabled = false;
                    i++;
                    printQuestion();
                    buttonD.BackColor = Color.Silver;
                    buttonB.Enabled = true;
                    buttonC.Enabled = true;
                    buttonA.Enabled = true;
                }
                else if (options[4] != options[3] && button4WasClicked)
                {
                    buttonD.BackColor = Color.Red;
                    buttonB.Enabled = false;
                    buttonC.Enabled = false;
                    buttonA.Enabled = false;
                }
                else if (options[4] != options[2] && button3WasClicked)
                {
                    buttonC.BackColor = Color.Red;
                    buttonB.Enabled = false;
                    buttonD.Enabled = false;
                    buttonA.Enabled = false;
                }
                else if (options[4] != options[1] && button2WasClicked)
                {
                    buttonB.BackColor = Color.Red;
                    buttonD.Enabled = false;
                    buttonC.Enabled = false;
                    buttonA.Enabled = false;
                }
                else
                {
                    buttonA.BackColor = Color.Red;
                    buttonB.Enabled = false;
                    buttonC.Enabled = false;
                    buttonD.Enabled = false;
                }

            //else if(cevap != a && buttonAWasClicked)
            //{
            //    buttonA.BackColor = Color.Red;
            //    buttonB.Enabled = false;
            //    buttonC.Enabled = false;
            //    buttonD.Enabled = false;
            //}
            //else if (cevap != b && buttonBWasClicked)
            //{
            //    buttonB.BackColor = Color.Red;
            //    buttonA.Enabled = false;
            //    buttonC.Enabled = false;
            //    buttonD.Enabled = false;
            //}
            //else if (cevap != c && buttonCWasClicked)
            //{
            //    buttonC.BackColor = Color.Red;
            //    buttonB.Enabled = false;
            //    buttonA.Enabled = false;
            //    buttonD.Enabled = false;
            //}
            //else
            //{
            //    buttonD.BackColor = Color.Red;
            //    buttonB.Enabled = false;
            //    buttonA.Enabled = false;
            //    buttonC.Enabled = false;
            //}
        }
        private void button1_Click(object sender, EventArgs e)
            {
                SetButtonAWasClicked(true);
                 isCorrectAnswer(Options);
            }
        private void button2_Click(object sender, EventArgs e)
            {
                SetButtonBWasClicked(true);
                 isCorrectAnswer(Options);
            }
        private void button3_Click(object sender, EventArgs e)
            {
                SetButtonCWasClicked(true);
            isCorrectAnswer(Options);
            }
        private void button4_Click(object sender, EventArgs e)
            {
                SetButtonDWasClicked(true);
                isCorrectAnswer(Options);
            }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer = true;
        }
    }
}

