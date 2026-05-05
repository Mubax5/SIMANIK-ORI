using System;
using System.Data;

namespace simanik_kel4.service
{
    using konfigurasi;
    using model;

    internal class Prescription_serv : PrescriptionDetail
    {
        Koneksi server;
        string Query;

        public Prescription_serv()
        {
            server = new Koneksi();
            Query = "";
        }

        public bool isExist(string kode)
        {
            bool cek = false;
            Query = "select * from detail_resep where id_detail='" + kode + "'";
            if (server.eksekusiQuery(Query).Rows.Count > 0)
            {
                cek = true;
            }

            return cek;
        }

        public int save()
        {
            int nilai = -1;
            Query = "insert into detail_resep(id_pemeriksaan, id_obat, jumlah, catatan_aturan) values('" + id_pemeriksaan + "', '" + id_obat + "', '" + jumlah + "', '" + catatan_aturan + "')";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public DataTable viewAll()
        {
            Query = "select dr.*, o.nama_obat from detail_resep dr left join obat o on dr.id_obat=o.id_obat";
            return server.eksekusiQuery(Query);
        }

        public DataTable viewByPemeriksaan(int kodePemeriksaan)
        {
            Query = "select dr.*, o.nama_obat from detail_resep dr left join obat o on dr.id_obat=o.id_obat where dr.id_pemeriksaan='" + kodePemeriksaan + "'";
            return server.eksekusiQuery(Query);
        }

        public int update(string kode)
        {
            int nilai = -1;
            Query = "update detail_resep set id_pemeriksaan='" + id_pemeriksaan + "', id_obat='" + id_obat + "', jumlah='" + jumlah + "', catatan_aturan='" + catatan_aturan + "' where id_detail='" + kode + "'";

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
            Query = "delete from detail_resep where id_detail='" + kode + "'";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public DataTable searchByNama(string nama)
        {
            Query = "select dr.*, o.nama_obat from detail_resep dr left join obat o on dr.id_obat=o.id_obat where o.nama_obat like '" + nama + "%'";
            return server.eksekusiQuery(Query);
        }

        public string createCode()
        {
            string kode = "";
            int jumlah = 0;
            DataTable data = new DataTable();

            Query = "SELECT IFNULL(MAX(id_detail),0)+1 AS jumlah FROM detail_resep";
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
