using System;

namespace simanik_kel4.model
{
    internal class Reservation
    {
        private int _id_reservasi;
        private int _id_pasien;
        private int _id_jadwal;
        private string _keluhan;
        private string _status_reservasi;
        private string _alasan_penolakan;
        private DateTime _dibuat_pada;

        public Reservation()
        {
            _id_reservasi = 0;
            _id_pasien = 0;
            _id_jadwal = 0;
            _keluhan = "";
            _status_reservasi = "Menunggu Verifikasi";
            _alasan_penolakan = "";
            _dibuat_pada = DateTime.Now;
        }

        public int id_reservasi
        {
            get { return _id_reservasi; }
            set { _id_reservasi = value; }
        }

        public int id_pasien
        {
            get { return _id_pasien; }
            set { _id_pasien = value; }
        }

        public int id_jadwal
        {
            get { return _id_jadwal; }
            set { _id_jadwal = value; }
        }

        public string keluhan
        {
            get { return _keluhan; }
            set { _keluhan = value; }
        }

        public string status_reservasi
        {
            get { return _status_reservasi; }
            set { _status_reservasi = value; }
        }

        public string alasan_penolakan
        {
            get { return _alasan_penolakan; }
            set { _alasan_penolakan = value; }
        }

        public DateTime dibuat_pada
        {
            get { return _dibuat_pada; }
            set { _dibuat_pada = value; }
        }

        public void confirm()
        {
            status_reservasi = "Dikonfirmasi";
            alasan_penolakan = "";
        }

        public void reject(string alasan)
        {
            status_reservasi = "Ditolak";
            alasan_penolakan = alasan;
        }

        public void cancelByPatient()
        {
            status_reservasi = "Dibatalkan Pasien";
        }

        public void checkIn()
        {
            status_reservasi = "Check-in";
        }

        public void finish()
        {
            status_reservasi = "Selesai";
        }
    }
}
