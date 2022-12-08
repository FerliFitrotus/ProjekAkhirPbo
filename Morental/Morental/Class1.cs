using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morental
{
    internal abstract class sql
    {
        protected NpgsqlConnection connect;

        internal sql()
        {
            string dbconnect = "Host=localhost;Database=morental;username=postgres;password=070917";
            connect = new NpgsqlConnection(dbconnect);
        }
    }
    internal class project : sql
    {
        internal string[][] getdata(string query)
        {
            List<string[]> list = new List<string[]>();

            connect.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nama_mobil = reader.GetString(1);
                int harga_sewa = reader.GetInt32(2);

                list.Add(new string[] {Convert.ToString(id), nama_mobil, Convert.ToString(harga_sewa)});
            }
            connect.Close();
            return list.ToArray();
        }
        internal string[][] getdatasewa(string query)
        {
            List<string[]> list = new List<string[]>();

            connect.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nama_penyewa = reader.GetString(1);
                string nik = reader.GetString(2);
                string nama_mobil_sewa = reader.GetString(3);
                int total_hari = reader.GetInt32(4);
                int total_harga = reader.GetInt32(5);

                list.Add(new string[] { Convert.ToString(id), nama_penyewa, nik, nama_mobil_sewa, Convert.ToString(total_hari), Convert.ToString(total_harga)});
            }
            connect.Close();
            return list.ToArray();
        }
    }
}
