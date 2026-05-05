using System;
using System.Data;

namespace simanik_kel4.service
{
    using konfigurasi;

    internal class Dashboard_serv
    {
        Koneksi server;
        string Query;

        public Dashboard_serv()
        {
            server = new Koneksi();
            Query = "";
        }

        public int getTotalPasien()
        {
            Query = "select count(*) from pasien";
            return ambilAngka(Query);
        }

        public int getTotalDokterAktif()
        {
            Query = "select count(*) from dokter where aktif=1";
            return ambilAngka(Query);
        }

        public int getReservasiHariIni()
        {
            Query = "select count(*) from reservasi r join jadwal_dokter jd on r.id_jadwal=jd.id_jadwal where jd.tanggal=curdate()";
            return ambilAngka(Query);
        }

        public int getReservasiMenunggu()
        {
            Query = "select count(*) from reservasi where status_reservasi='Menunggu Verifikasi'";
            return ambilAngka(Query);
        }

        public int getCheckInHariIni()
        {
            Query = "select count(*) from kunjungan where date(waktu_checkin)=curdate()";
            return ambilAngka(Query);
        }

        public int getPemeriksaanSelesaiHariIni()
        {
            Query = "select count(*) from pemeriksaan where date(tanggal_periksa)=curdate()";
            return ambilAngka(Query);
        }

        public DataTable getReservasiTerbaru()
        {
            Query = "select r.id_reservasi, p.nama_lengkap, r.status_reservasi, r.dibuat_pada from reservasi r left join pasien p on r.id_pasien=p.id_pasien order by r.dibuat_pada desc limit 10";
            return server.eksekusiQuery(Query);
        }

        public DataTable getAntrianHariIni()
        {
            Query = "select k.nomor_antrian, p.nama_lengkap, k.status_kunjungan from kunjungan k left join reservasi r on k.id_reservasi=r.id_reservasi left join pasien p on r.id_pasien=p.id_pasien where date(k.waktu_checkin)=curdate()";
            return server.eksekusiQuery(Query);
        }

        public DataTable getObatStokRendah()
        {
            Query = "select nama_obat, stok, satuan from obat where stok <= 10 and aktif=1";
            return server.eksekusiQuery(Query);
        }

        private int ambilAngka(string query)
        {
            int angka = 0;
            DataTable data = server.eksekusiQuery(query);

            if (data.Rows.Count > 0)
            {
                angka = Convert.ToInt32(data.Rows[0][0]);
            }

            return angka;
        }
    }
}
