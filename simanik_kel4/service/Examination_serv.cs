using System;
using System.Data;

namespace simanik_kel4.service
{
    using konfigurasi;
    using model;

    internal class Examination_serv : Examination
    {
        Koneksi server;
        string Query;

        public Examination_serv()
        {
            server = new Koneksi();
            Query = "";
        }

        public bool isExist(string kode)
        {
            bool cek = false;
            Query = "select * from pemeriksaan where id_pemeriksaan='" + kode + "'";
            if (server.eksekusiQuery(Query).Rows.Count > 0)
            {
                cek = true;
            }

            return cek;
        }

        public int save()
        {
            int nilai = -1;
            Query = "insert into pemeriksaan(id_kunjungan, id_dokter, id_penyakit, keluhan_saat_ini, catatan_diagnosa, catatan_tindakan) values('" + id_kunjungan + "', '" + id_dokter + "', '" + id_penyakit + "', '" + keluhan_saat_ini + "', '" + catatan_diagnosa + "', '" + catatan_tindakan + "')";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public DataTable viewAll()
        {
            Query = "select pm.*, p.nama_lengkap, py.nama_penyakit from pemeriksaan pm left join kunjungan k on pm.id_kunjungan=k.id_kunjungan left join reservasi r on k.id_reservasi=r.id_reservasi left join pasien p on r.id_pasien=p.id_pasien left join penyakit py on pm.id_penyakit=py.id_penyakit";
            return server.eksekusiQuery(Query);
        }

        public DataTable viewRiwayatPasien(int kodePasien)
        {
            Query = "select pm.*, py.nama_penyakit, d.nama_lengkap as nama_dokter from pemeriksaan pm left join kunjungan k on pm.id_kunjungan=k.id_kunjungan left join reservasi r on k.id_reservasi=r.id_reservasi left join penyakit py on pm.id_penyakit=py.id_penyakit left join dokter d on pm.id_dokter=d.id_dokter where r.id_pasien='" + kodePasien + "'";
            return server.eksekusiQuery(Query);
        }

        public int update(string kode)
        {
            int nilai = -1;
            Query = "update pemeriksaan set id_kunjungan='" + id_kunjungan + "', id_dokter='" + id_dokter + "', id_penyakit='" + id_penyakit + "', keluhan_saat_ini='" + keluhan_saat_ini + "', catatan_diagnosa='" + catatan_diagnosa + "', catatan_tindakan='" + catatan_tindakan + "' where id_pemeriksaan='" + kode + "'";

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
            Query = "delete from pemeriksaan where id_pemeriksaan='" + kode + "'";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public DataTable searchByNama(string nama)
        {
            Query = "select pm.*, p.nama_lengkap, py.nama_penyakit from pemeriksaan pm left join kunjungan k on pm.id_kunjungan=k.id_kunjungan left join reservasi r on k.id_reservasi=r.id_reservasi left join pasien p on r.id_pasien=p.id_pasien left join penyakit py on pm.id_penyakit=py.id_penyakit where p.nama_lengkap like '" + nama + "%' or py.nama_penyakit like '" + nama + "%'";
            return server.eksekusiQuery(Query);
        }

        public string createCode()
        {
            string kode = "";
            int jumlah = 0;
            DataTable data = new DataTable();

            Query = "SELECT IFNULL(MAX(id_pemeriksaan),0)+1 AS jumlah FROM pemeriksaan";
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
