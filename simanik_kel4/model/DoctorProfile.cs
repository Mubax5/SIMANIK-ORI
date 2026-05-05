namespace simanik_kel4.model
{
    internal class DoctorProfile : Person
    {
        private int _id_dokter;
        private int _id_user;
        private string _spesialisasi;
        private bool _aktif;

        public DoctorProfile()
        {
            _id_dokter = 0;
            _id_user = 0;
            _spesialisasi = "";
            _aktif = true;
        }

        public int id_dokter
        {
            get { return _id_dokter; }
            set { _id_dokter = value; }
        }

        public int id_user
        {
            get { return _id_user; }
            set { _id_user = value; }
        }

        public string spesialisasi
        {
            get { return _spesialisasi; }
            set { _spesialisasi = value; }
        }

        public bool aktif
        {
            get { return _aktif; }
            set { _aktif = value; }
        }

        public override string getDisplayInfo()
        {
            return nama_lengkap + " - " + spesialisasi;
        }
    }
}
