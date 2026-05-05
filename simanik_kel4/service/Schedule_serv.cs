using System;
using System.Data;

namespace simanik_kel4.service
{
    using konfigurasi;
    using model;

    internal class Schedule_serv : DoctorSchedule
    {
        Koneksi server;
        string Query;

        public Schedule_serv()
        {
            server = new Koneksi();
            Query = "";
        }

        public bool isExist(string kode)
        {
            bool cek = false;
            Query = "select * from jadwal_dokter where id_jadwal='" + kode + "'";
            if (server.eksekusiQuery(Query).Rows.Count > 0)
            {
                cek = true;
            }

            return cek;
        }

        public int save()
        {
            int nilai = -1;
            Query = "insert into jadwal_dokter(id_dokter, tanggal, jam_mulai, jam_selesai, kuota, aktif) values('" + id_dokter + "', '" + tanggal.ToString("yyyy-MM-dd") + "', '" + jam_mulai.ToString() + "', '" + jam_selesai.ToString() + "', '" + kuota + "', " + (aktif ? "1" : "0") + ")";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public DataTable viewAll()
        {
            Query = "select jd.*, d.nama_lengkap from jadwal_dokter jd left join dokter d on jd.id_dokter=d.id_dokter";
            return server.eksekusiQuery(Query);
        }

        public DataTable viewAktif()
        {
            Query = "select jd.*, d.nama_lengkap from jadwal_dokter jd left join dokter d on jd.id_dokter=d.id_dokter where jd.aktif=1";
            return server.eksekusiQuery(Query);
        }

        public int update(string kode)
        {
            int nilai = -1;
            Query = "update jadwal_dokter set id_dokter='" + id_dokter + "', tanggal='" + tanggal.ToString("yyyy-MM-dd") + "', jam_mulai='" + jam_mulai.ToString() + "', jam_selesai='" + jam_selesai.ToString() + "', kuota='" + kuota + "', aktif=" + (aktif ? "1" : "0") + " where id_jadwal='" + kode + "'";

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
            Query = "delete from jadwal_dokter where id_jadwal='" + kode + "'";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public DataTable searchByNama(string nama)
        {
            Query = "select jd.*, d.nama_lengkap from jadwal_dokter jd left join dokter d on jd.id_dokter=d.id_dokter where d.nama_lengkap like '" + nama + "%'";
            return server.eksekusiQuery(Query);
        }

        public new bool isSlotAvailable(int kodeJadwal)
        {
            Query = "select jd.kuota, count(r.id_reservasi) as jumlah from jadwal_dokter jd left join reservasi r on jd.id_jadwal=r.id_jadwal and r.status_reservasi in ('Menunggu Verifikasi','Dikonfirmasi','Check-in') where jd.id_jadwal='" + kodeJadwal + "' group by jd.kuota";
            DataTable data = server.eksekusiQuery(Query);

            if (data.Rows.Count == 0)
            {
                return false;
            }

            int totalKuota = Convert.ToInt32(data.Rows[0]["kuota"]);
            int totalReservasi = Convert.ToInt32(data.Rows[0]["jumlah"]);

            return totalReservasi < totalKuota;
        }

        public string createCode()
        {
            string kode = "";
            int jumlah = 0;
            DataTable data = new DataTable();

            Query = "SELECT IFNULL(MAX(id_jadwal),0)+1 AS jumlah FROM jadwal_dokter";
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
