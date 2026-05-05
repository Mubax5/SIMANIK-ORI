using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace simanik_kel4.konfigurasi
{
    internal class Koneksi:Konfigurasi
    {
        MySqlConnection _con;
        MySqlCommand _com;
        MySqlDataAdapter _adapter;  
        static string[] data = Settings.ambilSettings("konfig.txt");
        string _link = "server=" + data[0] + ";port=" + data[1] + ";database=" + data[2] + ";uid=" + data[3] + ";pwd=" + data[4];


        //constructor
        public Koneksi()
        {
            _con = new MySqlConnection(_link);
            _com = new MySqlCommand();
            _adapter = new MySqlDataAdapter();
        }

        private void bukaKoneksi()
        {
            try
            {
                if (_con.State == ConnectionState.Closed)
                {
                    _con.Open();
                }
            }
            catch (Exception) { }
        }

        private void tutupKoneksi()
        {
            if (_con.State != ConnectionState.Closed)
            {
                _con.Close();
            }
        }

        public override int eksekusiNonQuery(string query)
        {
            int retVal = -1;
            try
            {
                bukaKoneksi();
                _com.Connection = _con;
                _com.CommandText = query;
                retVal = _com.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally { tutupKoneksi(); }

            return retVal;
        }

        public override DataTable eksekusiQuery(string query)
        {
            DataTable retVal = new DataTable();
            try
            {
                bukaKoneksi();
                _com.Connection = _con;
                _com.CommandText = query;
                _adapter.SelectCommand = _com;
                _adapter.Fill(retVal);
            }
            catch (Exception) { }
            finally { tutupKoneksi(); }

            return retVal;
        }
    }
}
