using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Bilgisel
{
    class DBOperations
    {    
        static string connectionLink = @"Data Source=DESKTOP-K6L0EDQ;Initial Catalog=BilgiselDB;Integrated Security=True";
        static SqlConnection connection = new SqlConnection(connectionLink);      
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
        } //this method is written for 'Soru Ekle' button of form3  
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
        } //this method is written for 'Soru Güncelle' button of form3  
        public void deleteQuestion(string soru, string a, string b, string c, string d, string cevap, int id)
        {
            int num = id;
            string sql = "delete from dbo.Sorular where Id=" + num;
            SqlCommand cmd = new SqlCommand(sql, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        } //this method is written for 'Soru Sil' button of form3  
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
        }  //this method is written for 'Soruları Görüntüle' button of form3   
    }
}