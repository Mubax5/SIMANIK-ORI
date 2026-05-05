using System;
using System.Data;

namespace simanik_kel4.service
{
    using konfigurasi;
    using model;

    internal class Patient_serv : PatientProfile
    {
        Koneksi server;
        string Query;

        public Patient_serv()
        {
            server = new Koneksi();
            Query = "";
        }

        public bool isExist(string kode)
        {
            bool cek = false;
            Query = "select * from pasien where id_pasien='" + kode + "' or no_rekam_medis='" + kode + "'";
            if (server.eksekusiQuery(Query).Rows.Count > 0)
            {
                cek = true;
            }

            return cek;
        }

        public int save()
        {
            int nilai = -1;
            Query = "insert into pasien(id_user, no_rekam_medis, nama_lengkap, tanggal_lahir, jenis_kelamin, alamat, no_hp) values('" + id_user + "', '" + no_rekam_medis + "', '" + nama_lengkap + "', '" + tanggal_lahir.ToString("yyyy-MM-dd") + "', '" + jenis_kelamin + "', '" + alamat + "', '" + no_hp + "')";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public DataTable viewAll()
        {
            Query = "select * from pasien";
            return server.eksekusiQuery(Query);
        }

        public int update(string kode)
        {
            int nilai = -1;
            Query = "update pasien set id_user='" + id_user + "', no_rekam_medis='" + no_rekam_medis + "', nama_lengkap='" + nama_lengkap + "', tanggal_lahir='" + tanggal_lahir.ToString("yyyy-MM-dd") + "', jenis_kelamin='" + jenis_kelamin + "', alamat='" + alamat + "', no_hp='" + no_hp + "' where id_pasien='" + kode + "'";

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
            Query = "delete from pasien where id_pasien='" + kode + "'";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public DataTable searchByNama(string nama)
        {
            Query = "select * from pasien where nama_lengkap like '" + nama + "%' or no_rekam_medis like '" + nama + "%'";
            return server.eksekusiQuery(Query);
        }

        public string createCode()
        {
            string kode = "";
            int jumlah = 0;
            DataTable data = new DataTable();

            Query = "SELECT IFNULL(MAX(id_pasien),0)+1 AS jumlah FROM pasien";
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

        public string createNoRekamMedis()
        {
            int jumlah = 0;
            DataTable data = new DataTable();

            Query = "SELECT IFNULL(MAX(id_pasien),0)+1 AS jumlah FROM pasien";
            data = server.eksekusiQuery(Query);
            if (data.Rows.Count > 0)
            {
                jumlah = Convert.ToInt32(data.Rows[0][0]);
            }

            return "RM" + jumlah.ToString("000000");
        }
    }
}
