using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Morental
{
    public partial class Form6 : Form
    {
        private string delete_db;
        public Form6()
        {
            InitializeComponent();
        }
        private void reload()
        {
            dataGridView1.Rows.Clear();
            textBox1.Clear();
            load_db_sewa();
        }
        private string[][] sewa;
        private void load_db_sewa()
        {
            project project = new project();

            sewa = project.getdatasewa("select * from sewa");

            foreach (string[] i in sewa)
            {
                int indeks = dataGridView1.Rows.Add();
                DataGridViewRow dataGridViewRow0 = dataGridView1.Rows[indeks];

                dataGridViewRow0.Cells["Column1"].Value = i[0];
                dataGridViewRow0.Cells["Column2"].Value = i[1];
                dataGridViewRow0.Cells["Column3"].Value = i[2];
                dataGridViewRow0.Cells["Column4"].Value = i[3];
                dataGridViewRow0.Cells["Column5"].Value = i[4];
                dataGridViewRow0.Cells["Column6"].Value = i[5];
            }
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            load_db_sewa();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            this.Hide();
            form5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                delete_db = $"delete from sewa where id={Convert.ToInt32(textBox1.Text)}";

                project project = new project();
                project.getdata(delete_db);

                MessageBox.Show("Data berhasil dihapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reload();
            }
            else
            {
                MessageBox.Show("Masukkan nomor urut mobil dengan benar!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
    }
}
