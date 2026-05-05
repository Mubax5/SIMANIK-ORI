using System;
using System.Data;

namespace simanik_kel4.service
{
    using konfigurasi;
    using model;

    internal class Reservation_serv : Reservation
    {
        Koneksi server;
        string Query;

        public Reservation_serv()
        {
            server = new Koneksi();
            Query = "";
        }

        public bool isExist(string kode)
        {
            bool cek = false;
            Query = "select * from reservasi where id_reservasi='" + kode + "'";
            if (server.eksekusiQuery(Query).Rows.Count > 0)
            {
                cek = true;
            }

            return cek;
        }

        public int save()
        {
            int nilai = -1;
            Query = "insert into reservasi(id_pasien, id_jadwal, keluhan, status_reservasi, alasan_penolakan) values('" + id_pasien + "', '" + id_jadwal + "', '" + keluhan + "', '" + status_reservasi + "', '" + alasan_penolakan + "')";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public DataTable viewAll()
        {
            Query = "select r.*, p.nama_lengkap, jd.tanggal, jd.jam_mulai from reservasi r left join pasien p on r.id_pasien=p.id_pasien left join jadwal_dokter jd on r.id_jadwal=jd.id_jadwal";
            return server.eksekusiQuery(Query);
        }

        public DataTable viewByPasien(int kodePasien)
        {
            Query = "select r.*, jd.tanggal, jd.jam_mulai, d.nama_lengkap as nama_dokter from reservasi r left join jadwal_dokter jd on r.id_jadwal=jd.id_jadwal left join dokter d on jd.id_dokter=d.id_dokter where r.id_pasien='" + kodePasien + "'";
            return server.eksekusiQuery(Query);
        }

        public int update(string kode)
        {
            int nilai = -1;
            Query = "update reservasi set id_pasien='" + id_pasien + "', id_jadwal='" + id_jadwal + "', keluhan='" + keluhan + "', status_reservasi='" + status_reservasi + "', alasan_penolakan='" + alasan_penolakan + "' where id_reservasi='" + kode + "'";

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
            Query = "update reservasi set status_reservasi='" + status + "' where id_reservasi='" + kode + "'";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public int reject(string kode, string alasan)
        {
            int nilai = -1;
            Query = "update reservasi set status_reservasi='Ditolak', alasan_penolakan='" + alasan + "' where id_reservasi='" + kode + "'";

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
            Query = "delete from reservasi where id_reservasi='" + kode + "'";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public DataTable searchByNama(string nama)
        {
            Query = "select r.*, p.nama_lengkap, jd.tanggal, jd.jam_mulai from reservasi r left join pasien p on r.id_pasien=p.id_pasien left join jadwal_dokter jd on r.id_jadwal=jd.id_jadwal where p.nama_lengkap like '" + nama + "%' or r.status_reservasi like '" + nama + "%'";
            return server.eksekusiQuery(Query);
        }

        public string createCode()
        {
            string kode = "";
            int jumlah = 0;
            DataTable data = new DataTable();

            Query = "SELECT IFNULL(MAX(id_reservasi),0)+1 AS jumlah FROM reservasi";
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
