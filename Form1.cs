﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Bilgisel
{
    public partial class Form1 : Form
    {
        Form2 frm2 = new Form2();
        Form3 frm3 = new Form3();
        public Form1()
        {
            InitializeComponent();
        }
        //public int getUniqueId(int[] arr)
        //{
        //    int x = arr[j];
        //    return x;
        //}

        private void button1_Click(object sender, EventArgs e)
        {            
            this.Hide();
            frm2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm3.Show();
        }
    }
}

