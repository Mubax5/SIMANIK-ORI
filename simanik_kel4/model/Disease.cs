namespace simanik_kel4.model
{
    internal class Disease
    {
        private int _id_penyakit;
        private string _kode_penyakit;
        private string _nama_penyakit;
        private string _deskripsi;
        private bool _aktif;

        public Disease()
        {
            _id_penyakit = 0;
            _kode_penyakit = "";
            _nama_penyakit = "";
            _deskripsi = "";
            _aktif = true;
        }

        public int id_penyakit
        {
            get { return _id_penyakit; }
            set { _id_penyakit = value; }
        }

        public string kode_penyakit
        {
            get { return _kode_penyakit; }
            set { _kode_penyakit = value; }
        }

        public string nama_penyakit
        {
            get { return _nama_penyakit; }
            set { _nama_penyakit = value; }
        }

        public string deskripsi
        {
            get { return _deskripsi; }
            set { _deskripsi = value; }
        }

        public bool aktif
        {
            get { return _aktif; }
            set { _aktif = value; }
        }

        public void activate()
        {
            aktif = true;
        }

        public void deactivate()
        {
            aktif = false;
        }

        public string getDisplayName()
        {
            return kode_penyakit + " - " + nama_penyakit;
        }
    }
}
