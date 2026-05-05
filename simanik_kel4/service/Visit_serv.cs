using System;
using System.Data;

namespace simanik_kel4.service
{
    using konfigurasi;
    using model;

    internal class Visit_serv : Visit
    {
        Koneksi server;
        string Query;

        public Visit_serv()
        {
            server = new Koneksi();
            Query = "";
        }

        public bool isExist(string kode)
        {
            bool cek = false;
            Query = "select * from kunjungan where id_kunjungan='" + kode + "' or id_reservasi='" + kode + "'";
            if (server.eksekusiQuery(Query).Rows.Count > 0)
            {
                cek = true;
            }

            return cek;
        }

        public int save()
        {
            int nilai = -1;
            Query = "insert into kunjungan(id_reservasi, nomor_antrian, status_kunjungan) values('" + id_reservasi + "', '" + nomor_antrian + "', '" + status_kunjungan + "')";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public DataTable viewAll()
        {
            Query = "select k.*, p.nama_lengkap, r.keluhan from kunjungan k left join reservasi r on k.id_reservasi=r.id_reservasi left join pasien p on r.id_pasien=p.id_pasien";
            return server.eksekusiQuery(Query);
        }

        public DataTable viewAntrianHariIni()
        {
            Query = "select k.*, p.nama_lengkap, r.keluhan from kunjungan k left join reservasi r on k.id_reservasi=r.id_reservasi left join pasien p on r.id_pasien=p.id_pasien where date(k.waktu_checkin)=curdate()";
            return server.eksekusiQuery(Query);
        }

        public int update(string kode)
        {
            int nilai = -1;
            Query = "update kunjungan set id_reservasi='" + id_reservasi + "', nomor_antrian='" + nomor_antrian + "', status_kunjungan='" + status_kunjungan + "' where id_kunjungan='" + kode + "'";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public int updateStatus(string kode, string status)
        {
            int nilai = -1;
            Query = "update kunjungan set status_kunjungan='" + status + "' where id_kunjungan='" + kode + "'";

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
            Query = "delete from kunjungan where id_kunjungan='" + kode + "'";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public DataTable searchByNama(string nama)
        {
            Query = "select k.*, p.nama_lengkap, r.keluhan from kunjungan k left join reservasi r on k.id_reservasi=r.id_reservasi left join pasien p on r.id_pasien=p.id_pasien where p.nama_lengkap like '" + nama + "%' or k.status_kunjungan like '" + nama + "%'";
            return server.eksekusiQuery(Query);
        }

        public int createQueueNumber()
        {
            int jumlah = 1;
            DataTable data = new DataTable();

            Query = "SELECT IFNULL(MAX(nomor_antrian),0)+1 AS jumlah FROM kunjungan where date(waktu_checkin)=curdate()";
            data = server.eksekusiQuery(Query);
            if (data.Rows.Count > 0)
            {
                jumlah = Convert.ToInt32(data.Rows[0][0]);
            }

            return jumlah;
        }

        public string createCode()
        {
            string kode = "";
            int jumlah = 0;
            DataTable data = new DataTable();

            Query = "SELECT IFNULL(MAX(id_kunjungan),0)+1 AS jumlah FROM kunjungan";
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
