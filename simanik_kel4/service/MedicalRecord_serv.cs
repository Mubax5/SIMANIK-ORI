using System;
using System.Data;

namespace simanik_kel4.service
{
    using konfigurasi;
    using model;

    internal class MedicalRecord_serv : MedicalRecord
    {
        Koneksi server;
        string Query;

        public MedicalRecord_serv()
        {
            server = new Koneksi();
            Query = "";
        }

        public bool isExist(string kode)
        {
            bool cek = false;
            Query = "select * from rekam_medis where id_rekam='" + kode + "' or id_pasien='" + kode + "'";
            if (server.eksekusiQuery(Query).Rows.Count > 0)
            {
                cek = true;
            }

            return cek;
        }

        public int save()
        {
            int nilai = -1;
            Query = "insert into rekam_medis(id_pasien, terakhir_kunjungan, golongan_darah, catatan_alergi, catatan_penyakit_kronis) values('" + id_pasien + "', '" + terakhir_kunjungan.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + golongan_darah + "', '" + catatan_alergi + "', '" + catatan_penyakit_kronis + "')";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public DataTable viewAll()
        {
            Query = "select rm.*, p.nama_lengkap from rekam_medis rm left join pasien p on rm.id_pasien=p.id_pasien";
            return server.eksekusiQuery(Query);
        }

        public int update(string kode)
        {
            int nilai = -1;
            Query = "update rekam_medis set id_pasien='" + id_pasien + "', terakhir_kunjungan='" + terakhir_kunjungan.ToString("yyyy-MM-dd HH:mm:ss") + "', golongan_darah='" + golongan_darah + "', catatan_alergi='" + catatan_alergi + "', catatan_penyakit_kronis='" + catatan_penyakit_kronis + "' where id_rekam='" + kode + "'";

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
            Query = "delete from rekam_medis where id_rekam='" + kode + "'";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public DataTable searchByNama(string nama)
        {
            Query = "select rm.*, p.nama_lengkap from rekam_medis rm left join pasien p on rm.id_pasien=p.id_pasien where p.nama_lengkap like '" + nama + "%'";
            return server.eksekusiQuery(Query);
        }

        public string createCode()
        {
            string kode = "";
            int jumlah = 0;
            DataTable data = new DataTable();

            Query = "SELECT IFNULL(MAX(id_rekam),0)+1 AS jumlah FROM rekam_medis";
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
