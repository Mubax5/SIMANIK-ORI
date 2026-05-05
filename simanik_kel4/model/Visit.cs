using System;

namespace simanik_kel4.model
{
    internal class Visit
    {
        private int _id_kunjungan;
        private int _id_reservasi;
        private int _nomor_antrian;
        private DateTime _waktu_checkin;
        private string _status_kunjungan;

        public Visit()
        {
            _id_kunjungan = 0;
            _id_reservasi = 0;
            _nomor_antrian = 0;
            _waktu_checkin = DateTime.Now;
            _status_kunjungan = "Menunggu";
        }

        public int id_kunjungan
        {
            get { return _id_kunjungan; }
            set { _id_kunjungan = value; }
        }

        public int id_reservasi
        {
            get { return _id_reservasi; }
            set { _id_reservasi = value; }
        }

        public int nomor_antrian
        {
            get { return _nomor_antrian; }
            set { _nomor_antrian = value; }
        }

        public DateTime waktu_checkin
        {
            get { return _waktu_checkin; }
            set { _waktu_checkin = value; }
        }

        public string status_kunjungan
        {
            get { return _status_kunjungan; }
            set { _status_kunjungan = value; }
        }

        public void startExamination()
        {
            status_kunjungan = "Sedang Diperiksa";
        }

        public void finishVisit()
        {
            status_kunjungan = "Selesai";
        }
    }
}
