using System;

namespace simanik_kel4.model
{
    internal class PatientProfile : Person
    {
        private int _id_pasien;
        private int _id_user;
        private string _no_rekam_medis;
        private DateTime _tanggal_lahir;
        private string _jenis_kelamin;

        public PatientProfile()
        {
            _id_pasien = 0;
            _id_user = 0;
            _no_rekam_medis = "";
            _tanggal_lahir = DateTime.Now;
            _jenis_kelamin = "";
        }

        public int id_pasien
        {
            get { return _id_pasien; }
            set { _id_pasien = value; }
        }

        public int id_user
        {
            get { return _id_user; }
            set { _id_user = value; }
        }

        public string no_rekam_medis
        {
            get { return _no_rekam_medis; }
            set { _no_rekam_medis = value; }
        }

        public DateTime tanggal_lahir
        {
            get { return _tanggal_lahir; }
            set { _tanggal_lahir = value; }
        }

        public string jenis_kelamin
        {
            get { return _jenis_kelamin; }
            set { _jenis_kelamin = value; }
        }

        public int calculateAge()
        {
            int umur = DateTime.Today.Year - tanggal_lahir.Year;
            if (tanggal_lahir.Date > DateTime.Today.AddYears(-umur))
            {
                umur--;
            }

            return umur;
        }
    }
}
