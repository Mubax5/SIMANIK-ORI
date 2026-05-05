using System;

namespace simanik_kel4.model
{
    internal class Examination
    {
        private int _id_pemeriksaan;
        private int _id_kunjungan;
        private int _id_dokter;
        private int _id_penyakit;
        private DateTime _tanggal_periksa;
        private string _keluhan_saat_ini;
        private string _catatan_diagnosa;
        private string _catatan_tindakan;

        public Examination()
        {
            _id_pemeriksaan = 0;
            _id_kunjungan = 0;
            _id_dokter = 0;
            _id_penyakit = 0;
            _tanggal_periksa = DateTime.Now;
            _keluhan_saat_ini = "";
            _catatan_diagnosa = "";
            _catatan_tindakan = "";
        }

        public int id_pemeriksaan
        {
            get { return _id_pemeriksaan; }
            set { _id_pemeriksaan = value; }
        }

        public int id_kunjungan
        {
            get { return _id_kunjungan; }
            set { _id_kunjungan = value; }
        }

        public int id_dokter
        {
            get { return _id_dokter; }
            set { _id_dokter = value; }
        }

        public int id_penyakit
        {
            get { return _id_penyakit; }
            set { _id_penyakit = value; }
        }

        public DateTime tanggal_periksa
        {
            get { return _tanggal_periksa; }
            set { _tanggal_periksa = value; }
        }

        public string keluhan_saat_ini
        {
            get { return _keluhan_saat_ini; }
            set { _keluhan_saat_ini = value; }
        }

        public string catatan_diagnosa
        {
            get { return _catatan_diagnosa; }
            set { _catatan_diagnosa = value; }
        }

        public string catatan_tindakan
        {
            get { return _catatan_tindakan; }
            set { _catatan_tindakan = value; }
        }

        public void setDisease(Disease penyakit)
        {
            id_penyakit = penyakit.id_penyakit;
        }

        public bool saveResult()
        {
            return id_kunjungan > 0 && id_dokter > 0 && id_penyakit > 0;
        }
    }
}
