using System;

namespace simanik_kel4.model
{
    internal class MedicalRecord
    {
        private int _id_rekam;
        private int _id_pasien;
        private DateTime _terakhir_kunjungan;
        private string _golongan_darah;
        private string _catatan_alergi;
        private string _catatan_penyakit_kronis;

        public MedicalRecord()
        {
            _id_rekam = 0;
            _id_pasien = 0;
            _terakhir_kunjungan = DateTime.Now;
            _golongan_darah = "";
            _catatan_alergi = "";
            _catatan_penyakit_kronis = "";
        }

        public int id_rekam
        {
            get { return _id_rekam; }
            set { _id_rekam = value; }
        }

        public int id_pasien
        {
            get { return _id_pasien; }
            set { _id_pasien = value; }
        }

        public DateTime terakhir_kunjungan
        {
            get { return _terakhir_kunjungan; }
            set { _terakhir_kunjungan = value; }
        }

        public string golongan_darah
        {
            get { return _golongan_darah; }
            set { _golongan_darah = value; }
        }

        public string catatan_alergi
        {
            get { return _catatan_alergi; }
            set { _catatan_alergi = value; }
        }

        public string catatan_penyakit_kronis
        {
            get { return _catatan_penyakit_kronis; }
            set { _catatan_penyakit_kronis = value; }
        }

        public void updateLastVisit(DateTime tanggal)
        {
            terakhir_kunjungan = tanggal;
        }

        public string getSummary()
        {
            return "Gol darah: " + golongan_darah + ", Alergi: " + catatan_alergi + ", Kronis: " + catatan_penyakit_kronis;
        }
    }
}
