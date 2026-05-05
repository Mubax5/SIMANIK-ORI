using System;
using System.Data;

namespace simanik_kel4.service
{
    using konfigurasi;
    using model;

    internal class Doctor_serv : DoctorProfile
    {
        Koneksi server;
        string Query;

        public Doctor_serv()
        {
            server = new Koneksi();
            Query = "";
        }

        public bool isExist(string kode)
        {
            bool cek = false;
            Query = "select * from dokter where id_dokter='" + kode + "'";
            if (server.eksekusiQuery(Query).Rows.Count > 0)
            {
                cek = true;
            }

            return cek;
        }

        public int save()
        {
            int nilai = -1;
            Query = "insert into dokter(id_user, nama_lengkap, spesialisasi, no_hp, aktif) values('" + id_user + "', '" + nama_lengkap + "', '" + spesialisasi + "', '" + no_hp + "', " + (aktif ? "1" : "0") + ")";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public DataTable viewAll()
        {
            Query = "select * from dokter";
            return server.eksekusiQuery(Query);
        }

        public int update(string kode)
        {
            int nilai = -1;
            Query = "update dokter set id_user='" + id_user + "', nama_lengkap='" + nama_lengkap + "', spesialisasi='" + spesialisasi + "', no_hp='" + no_hp + "', aktif=" + (aktif ? "1" : "0") + " where id_dokter='" + kode + "'";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public int delete(string kode)
        {
            int nilai = -1;
            Query = "delete from dokter where id_dokter='" + kode + "'";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public DataTable searchByNama(string nama)
        {
            Query = "select * from dokter where nama_lengkap like '" + nama + "%'";
            return server.eksekusiQuery(Query);
        }

        public string createCode()
        {
            string kode = "";
            int jumlah = 0;
            DataTable data = new DataTable();

            Query = "SELECT IFNULL(MAX(id_dokter),0)+1 AS jumlah FROM dokter";
            data = server.eksekusiQuery(Query);
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dt in data.Rows)
                {
                    jumlah = Convert.ToInt32(dt[0]);
                }

                kode = jumlah.ToString();
            }

            return kode;
        }
    }
}
