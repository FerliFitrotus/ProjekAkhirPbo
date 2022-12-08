using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morental
{
    public partial class Form2 : Form
    {
        public static Form2 form2;
        public TextBox nama;
        public TextBox nik;
        public Form2()
        {
            InitializeComponent();
            form2 = this;
            nama = textBox1;
            nik = textBox2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Form3 form3 = new Form3();
                this.Hide();
                form3.Show();
            }
            else
            {
                MessageBox.Show("Masukkan Nama dan NIK dengan benar!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
