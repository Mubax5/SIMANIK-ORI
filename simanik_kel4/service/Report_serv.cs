using System.Data;

namespace simanik_kel4.service
{
    using konfigurasi;

    internal class Report_serv
    {
        Koneksi server;
        string Query;

        public Report_serv()
        {
            server = new Koneksi();
            Query = "";
        }

        public DataTable laporanReservasiPerHari()
        {
            Query = "select date(dibuat_pada) as tanggal, count(*) as total from reservasi group by date(dibuat_pada) order by tanggal desc";
            return server.eksekusiQuery(Query);
        }

        public DataTable laporanReservasiPerDokter()
        {
            Query = "select d.nama_lengkap, count(r.id_reservasi) as total from reservasi r join jadwal_dokter jd on r.id_jadwal=jd.id_jadwal join dokter d on jd.id_dokter=d.id_dokter group by d.nama_lengkap";
            return server.eksekusiQuery(Query);
        }

        public DataTable laporanKunjunganSelesai()
        {
            Query = "select date(waktu_checkin) as tanggal, count(*) as total from kunjungan where status_kunjungan='Selesai' group by date(waktu_checkin) order by tanggal desc";
            return server.eksekusiQuery(Query);
        }

        public DataTable laporanPenyakitTerbanyak()
        {
            Query = "select py.nama_penyakit, count(pm.id_pemeriksaan) as total from pemeriksaan pm join penyakit py on pm.id_penyakit=py.id_penyakit group by py.nama_penyakit order by total desc";
            return server.eksekusiQuery(Query);
        }

        public DataTable laporanObatSeringDiberikan()
        {
            Query = "select o.nama_obat, sum(dr.jumlah) as total from detail_resep dr join obat o on dr.id_obat=o.id_obat group by o.nama_obat order by total desc";
            return server.eksekusiQuery(Query);
        }

        public DataTable laporanStokRendah()
        {
            Query = "select nama_obat, stok, satuan from obat where stok <= 10 and aktif=1";
            return server.eksekusiQuery(Query);
        }
    }
}
