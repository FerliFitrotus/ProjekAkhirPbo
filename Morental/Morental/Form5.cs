using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morental
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private string insert_db;
        private string update_db;
        private string delete_db;
        private void landingpage_admin()
        {
            label2.Hide();
            label3.Hide();
            label4.Hide();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
        }
        private void aksi_tambah()
        {
            label3.Show();
            label4.Show();
            label2.Hide();
            textBox1.Hide();
            textBox2.Show();
            textBox3.Show();
            button1.Show();
            button2.Hide();
            button3.Hide();
        }

        private void aksi_edit()
        {
            label2.Show();
            label3.Show();
            label4.Show();
            textBox1.Show();
            textBox2.Show();
            textBox3.Show();
            button1.Hide();
            button2.Show();
            button3.Hide();
        }

        private void aksi_hapus()
        {
            label2.Show();
            label3.Hide();
            label4.Hide();
            textBox1.Show();
            textBox2.Hide();
            textBox3.Hide();
            button1.Hide();
            button2.Hide();
            button3.Show();
        }

        private void reload()
        {
            dataGridView1.Rows.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            loadata();
        }
        private void loadata()
        {
            project project = new project();

            string[][] mobil = project.getdata("select * from mobil");

            foreach (string[] i in mobil)
            {
                int indeks = dataGridView1.Rows.Add();
                DataGridViewRow dataGridViewRow0 = dataGridView1.Rows[indeks];

                dataGridViewRow0.Cells["Column1"].Value = i[0];
                dataGridViewRow0.Cells["Column2"].Value = i[1];
                dataGridViewRow0.Cells["Column3"].Value = i[2];
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            loadata();
            landingpage_admin();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Tambah")
            {
                aksi_tambah();
            }
            else if (comboBox1.Text == "Edit")
            {
                aksi_edit();
            }
            else if (comboBox1.Text == "Hapus")
            {
                aksi_hapus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                insert_db = $"insert into mobil (nama_mobil, harga_sewa) values('{textBox2.Text}','{Convert.ToInt32(textBox3.Text)}')";

                project project = new project();
                project.getdata(insert_db);

                MessageBox.Show("Data mobil berhasil ditambahkan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reload();
            }
            else
            {
                MessageBox.Show("Isi dengan benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox2.Text != "" && textBox3.Text != "")
            {
                update_db = $"update mobil set nama_mobil='{textBox2.Text}', harga_sewa={textBox3.Text} where id={textBox1.Text}";

                project project = new project();
                project.getdata(update_db);

                MessageBox.Show("Data berhasil diubah", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reload();
            }
            else
            {
                MessageBox.Show("Isi dengan benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                delete_db = $"delete from mobil where id={Convert.ToInt32(textBox1.Text)}";

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

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            this.Hide();
            form6.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            this.Hide();
            form4.Show();
        }
    }
}
