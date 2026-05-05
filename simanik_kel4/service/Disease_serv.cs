using System;
using System.Data;

namespace simanik_kel4.service
{
    using konfigurasi;
    using model;

    internal class Disease_serv : Disease
    {
        Koneksi server;
        string Query;

        public Disease_serv()
        {
            server = new Koneksi();
            Query = "";
        }

        public bool isExist(string kode)
        {
            bool cek = false;
            Query = "select * from penyakit where id_penyakit='" + kode + "' or kode_penyakit='" + kode + "'";
            if (server.eksekusiQuery(Query).Rows.Count > 0)
            {
                cek = true;
            }

            return cek;
        }

        public int save()
        {
            int nilai = -1;
            Query = "insert into penyakit(kode_penyakit, nama_penyakit, deskripsi, aktif) values('" + kode_penyakit + "', '" + nama_penyakit + "', '" + deskripsi + "', " + (aktif ? "1" : "0") + ")";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public DataTable viewAll()
        {
            Query = "select * from penyakit";
            return server.eksekusiQuery(Query);
        }

        public DataTable viewAktif()
        {
            Query = "select * from penyakit where aktif=1";
            return server.eksekusiQuery(Query);
        }

        public int update(string kode)
        {
            int nilai = -1;
            Query = "update penyakit set kode_penyakit='" + kode_penyakit + "', nama_penyakit='" + nama_penyakit + "', deskripsi='" + deskripsi + "', aktif=" + (aktif ? "1" : "0") + " where id_penyakit='" + kode + "'";

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
            Query = "delete from penyakit where id_penyakit='" + kode + "'";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public DataTable searchByNama(string nama)
        {
            Query = "select * from penyakit where nama_penyakit like '" + nama + "%' or kode_penyakit like '" + nama + "%'";
            return server.eksekusiQuery(Query);
        }

        public string createCode()
        {
            string kode = "";
            int jumlah = 0;
            DataTable data = new DataTable();

            Query = "SELECT IFNULL(MAX(id_penyakit),0)+1 AS jumlah FROM penyakit";
            data = server.eksekusiQuery(Query);
            if (data.Rows.Count > 0)
            {
                jumlah = Convert.ToInt32(data.Rows[0][0]);
                kode = jumlah.ToString();
            }

            return kode;
        }
    }
}
