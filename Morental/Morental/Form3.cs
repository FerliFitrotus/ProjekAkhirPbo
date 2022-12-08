using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Morental
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private string[][] mobil;

        private void load_db_mobil(object sender, EventArgs e)
        {
            project project = new project();

            mobil = project.getdata("select * from mobil");

            foreach (string[] i in mobil)
            {
                int indeks = dataGridView1.Rows.Add();
                DataGridViewRow dataGridViewRow0 = dataGridView1.Rows[indeks];

                dataGridViewRow0.Cells["Column1"].Value = i[1];
                dataGridViewRow0.Cells["Column2"].Value = i[2];
                comboBox1.Items.Add(i[1]);
            }
        }

        private void tabel_data_sewa(string klm_mobil, string klm_hari, string mobil, string hari)
        {
            int indeks = dataGridView2.Rows.Add();
            DataGridViewRow dataGridViewRow0 = dataGridView2.Rows[indeks];

            dataGridViewRow0.Cells[klm_mobil].Value = mobil;
            dataGridViewRow0.Cells[klm_hari].Value = hari;
        }

        private int total_harga_sewa;
        private void button1_Click(object sender, EventArgs e)
        {
            string? selected_mobil = Convert.ToString(comboBox1.SelectedItem);
            int total_hari = Convert.ToInt32(textBox1.Text);
            total_harga_sewa = 0;

            if(selected_mobil != "" && total_hari > 0)
            {
                tabel_data_sewa("Column3", "Column4", comboBox1.Text, textBox1.Text);

                foreach (string[] i in mobil)
                {
                    if (i[1] == selected_mobil)
                    {
                        total_harga_sewa += Convert.ToInt32(i[2]) * total_hari;
                    }
                }
                listBox1.Items.Add(Convert.ToInt32(total_harga_sewa));
            }
            else if(total_hari <= 0)
            {
                MessageBox.Show("Sewa minimal 1 Hari!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Anda harus memilih mobil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void set_data_sewa(string nama, string nik, string? mbl_sewa, int t_hari, int t_harga)
        {
            string query = $"insert into sewa (nama_penyewa, nik, nama_mobil_sewa, total_hari, total_harga) values('{nama}', '{nik}', '{mbl_sewa}', '{t_hari}', '{t_harga}')";
            
            project project = new project();
            project.getdata(query);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView2.Rows.Count != 0)
            {
                DialogResult dr = MessageBox.Show($"Total harga yang harus dibayar sebanyak {listBox1.Items[0]}", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string nama = Form2.form2.nama.Text;
                string nik = Form2.form2.nik.Text;

                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    set_data_sewa(nama, nik, Convert.ToString(dataGridView2.Rows[i].Cells[0].Value), Convert.ToInt32(dataGridView2.Rows[i].Cells[1].Value), Convert.ToInt32(listBox1.Items[0]));
                }

                if (dr == DialogResult.OK)
                {
                    Form2 form2 = new Form2();
                    this.Hide();
                    form2.Show();
                }
            }
            else
            {
                MessageBox.Show("Data sewa tidak ditemukan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }
    }
}
