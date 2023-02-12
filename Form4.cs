using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilgisel
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        Form3 frm3 = new Form3();
        private void button1_Click(object sender, EventArgs e)
        {
            string username = "ksmcnns";
            string password = "bilgisel";
            if(username == textBox1.Text && password == textBox2.Text)
            {
                this.Close();
                frm3.Show();
            }
        }
    }
}
