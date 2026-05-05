using System;

namespace simanik_kel4.model
{
    internal class DoctorSchedule
    {
        private int _id_jadwal;
        private int _id_dokter;
        private DateTime _tanggal;
        private TimeSpan _jam_mulai;
        private TimeSpan _jam_selesai;
        private int _kuota;
        private bool _aktif;

        public DoctorSchedule()
        {
            _id_jadwal = 0;
            _id_dokter = 0;
            _tanggal = DateTime.Today;
            _jam_mulai = TimeSpan.Zero;
            _jam_selesai = TimeSpan.Zero;
            _kuota = 0;
            _aktif = true;
        }

        public int id_jadwal
        {
            get { return _id_jadwal; }
            set { _id_jadwal = value; }
        }

        public int id_dokter
        {
            get { return _id_dokter; }
            set { _id_dokter = value; }
        }

        public DateTime tanggal
        {
            get { return _tanggal; }
            set { _tanggal = value; }
        }

        public TimeSpan jam_mulai
        {
            get { return _jam_mulai; }
            set { _jam_mulai = value; }
        }

        public TimeSpan jam_selesai
        {
            get { return _jam_selesai; }
            set { _jam_selesai = value; }
        }

        public int kuota
        {
            get { return _kuota; }
            set { _kuota = value; }
        }

        public bool aktif
        {
            get { return _aktif; }
            set { _aktif = value; }
        }

        public bool isSlotAvailable(int jumlahReservasi)
        {
            return aktif && jumlahReservasi < kuota;
        }

        public int getRemainingQuota(int jumlahReservasi)
        {
            int sisa = kuota - jumlahReservasi;
            if (sisa < 0)
            {
                return 0;
            }

            return sisa;
        }
    }
}
