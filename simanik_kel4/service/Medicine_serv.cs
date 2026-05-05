using System;
using System.Data;

namespace simanik_kel4.service
{
    using konfigurasi;
    using model;

    internal class Medicine_serv : Medicine
    {
        Koneksi server;
        string Query;

        public Medicine_serv()
        {
            server = new Koneksi();
            Query = "";
        }

        public bool isExist(string kode)
        {
            bool cek = false;
            Query = "select * from obat where id_obat='" + kode + "'";
            if (server.eksekusiQuery(Query).Rows.Count > 0)
            {
                cek = true;
            }

            return cek;
        }

        public int save()
        {
            int nilai = -1;
            Query = "insert into obat(nama_obat, jenis_obat, stok, satuan, aturan_pakai_default, aktif) values('" + nama_obat + "', '" + jenis_obat + "', '" + stok + "', '" + satuan + "', '" + aturan_pakai_default + "', " + (aktif ? "1" : "0") + ")";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public DataTable viewAll()
        {
            Query = "select * from obat";
            return server.eksekusiQuery(Query);
        }

        public DataTable viewStokRendah()
        {
            Query = "select * from obat where stok <= 10 and aktif=1";
            return server.eksekusiQuery(Query);
        }

        public int update(string kode)
        {
            int nilai = -1;
            Query = "update obat set nama_obat='" + nama_obat + "', jenis_obat='" + jenis_obat + "', stok='" + stok + "', satuan='" + satuan + "', aturan_pakai_default='" + aturan_pakai_default + "', aktif=" + (aktif ? "1" : "0") + " where id_obat='" + kode + "'";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public int reduceStock(int kodeObat, int qty)
        {
            int nilai = -1;
            Query = "update obat set stok=stok-" + qty + " where id_obat='" + kodeObat + "' and stok>=" + qty;

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
            Query = "delete from obat where id_obat='" + kode + "'";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public DataTable searchByNama(string nama)
        {
            Query = "select * from obat where nama_obat like '" + nama + "%' or jenis_obat like '" + nama + "%'";
            return server.eksekusiQuery(Query);
        }

        public string createCode()
        {
            string kode = "";
            int jumlah = 0;
            DataTable data = new DataTable();

            Query = "SELECT IFNULL(MAX(id_obat),0)+1 AS jumlah FROM obat";
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
