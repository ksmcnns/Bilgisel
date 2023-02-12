using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Drawing;

namespace Bilgisel
{
    class DBOperations
    {
         //static int min = 1;
         //static int max = 4;
         //static int val=1;
         
        static string connectionLink = @"Data Source=DESKTOP-K6L0EDQ;Initial Catalog=BilgiselDB;Integrated Security=True";
        static SqlConnection connection = new SqlConnection(connectionLink);
       // private static int _count = 0;

        //public static int GetCount()
        //{
        //    countOfRecords();
        //    return _count;
        //}
        //public static void countOfRecords()
        //{
            
        //    string sql = "select count(*) from Sorular";
        //    SqlCommand cmd = new SqlCommand(sql, connection);
        //    connection.Open();
        //    Int32 _count = Convert.ToInt32(cmd.ExecuteScalar());
        //    cmd.Dispose();
        //    connection.Close();
        //    //SqlDataReader reader = cmd.ExecuteReader();
        //    //while (reader.Read())
        //    //{
        //    //    _count = reader.GetInt32(0);
        //    //}
        //}
        public void addQuestion(string soru, string a, string b, string c, string d, string cevap)
        {
            string sql = "insert into dbo.Sorular values (@pSoru,@pA,@pB,@pC,@pD,@pCevap)";
            SqlCommand cmd = new SqlCommand(sql, connection);
            // cmd.Parameters.AddWithValue("@pId", id);
            cmd.Parameters.AddWithValue("@pSoru", soru);
            cmd.Parameters.AddWithValue("@pA", a);
            cmd.Parameters.AddWithValue("@pB", b);
            cmd.Parameters.AddWithValue("@pC", c);
            cmd.Parameters.AddWithValue("@pD", d);
            cmd.Parameters.AddWithValue("@pCevap", cevap);
            // cmd.Parameters.AddWithValue("@pDerece", derece);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void uptadeQuestion(string soru, string a, string b, string c, string d, string cevap, int id)
        {
            int num = id;
            string sql = "update dbo.Sorular set Soru=@pSoru, A=@pA, B=@pB, C=@pC, D=@pD, Cevap=@pCevap where Id=" + num;
            SqlCommand cmd = new SqlCommand(sql, connection);
            //cmd.Parameters.AddWithValue("@pId", id);
            cmd.Parameters.AddWithValue("@pSoru", soru);
            cmd.Parameters.AddWithValue("@pA", a);
            cmd.Parameters.AddWithValue("@pB", b);
            cmd.Parameters.AddWithValue("@pC", c);
            cmd.Parameters.AddWithValue("@pD", d);
            cmd.Parameters.AddWithValue("@pCevap", cevap);
            //cmd.Parameters.AddWithValue("@pDerece", derece);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void deleteQuestion(string soru, string a, string b, string c, string d, string cevap, int id)
        {
            int num = id;
            string sql = "delete from dbo.Sorular where Id=" + num;
            SqlCommand cmd = new SqlCommand(sql, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public DataSet displayQuestions()
        {
            string sql = "select * from Sorular";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter adoptor = new SqlDataAdapter();
            adoptor.SelectCommand = cmd;

            DataSet results = new DataSet();
            connection.Open();
            adoptor.Fill(results);
            connection.Close();
            return results;
        }
        //public static int getId()
        //{
        //    int[] arr = new int[14];
        //    Random rnd = new Random();
        //    for (int i = min; i < max; i++)
        //    {
        //        arr[i] = i;
        //    }
        //    //
        //    // The array has been created
        //    //
        //    for(int i = max-1; i > 0; i--)
        //    {
        //        Random rnd2 = new Random();
        //        int randomIndex = rnd2.Next(1, i);
        //        int temp = arr[i];
        //        arr[i] = arr[randomIndex];
        //        arr[randomIndex] = temp;
        //    }
        //    //
        //    // The array has been shuffled
        //    //
        //   return arr[val];          
        //}
       
    }
}
/*
      
    int min = 1;
        int max = 4;
        int ik = 0;
        int joker = 0;
        public int[] arr = new int[14];
    
    public int getId()
        {
            int[] arr = new int[14];
            int x;
            Random rnd = new Random();
            x = rnd.Next(1, 4);
            for (int i = min; i < max; i++)
            {
                arr[i] = i;
            }
            //
            // The array has been created
            //
            int n = max;
            int[] temp;
            Random r = new Random();
            while (n > 1)
            {
                int k = r.Next(n--);
                temp[ik] = arr[n];
                arr[n] = arr[k];
                arr[k] = temp[ik];
            }


    
    public DataTable getData()
        {
            DataTable dt = new DataTable();
            string sql = "select * from Sorular where ID=" + getRows();
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-F0C6A27;Initial Catalog=BilgiYarismasiDB3;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                label5.Text = dt.Rows[0][1].ToString();
                button1.Text = dt.Rows[0][2].ToString();
                button2.Text = dt.Rows[0][3].ToString();
                button3.Text = dt.Rows[0][4].ToString();
                button4.Text = dt.Rows[0][5].ToString();
                cevap = dt.Rows[0][6].ToString();

                //string soru=label5.Text;
                //string a = button1.Text;
                //string b = button2.Text;
                //string c = button3.Text;
                //string d = button4.Text;
                //display(soru, a, b, c, d);

            }
            connection.Close();            
            return dt;
        }
 public void displayQuestion()
        {
            Form3 frm3 = new Form3();
            int num = frm3.getId();
            string sql = "select * from Sorular where Id=@pId";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@pId", num);
            connection.Open();       
            cmd.ExecuteNonQuery();
            connection.Close();
        }
*/