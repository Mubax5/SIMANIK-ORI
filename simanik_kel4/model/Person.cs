namespace simanik_kel4.model
{
    internal class Person
    {
        private string _nama_lengkap;
        private string _no_hp;
        private string _alamat;

        public Person()
        {
            _nama_lengkap = "";
            _no_hp = "";
            _alamat = "";
        }

        public string nama_lengkap
        {
            get { return _nama_lengkap; }
            set { _nama_lengkap = value; }
        }

        public string no_hp
        {
            get { return _no_hp; }
            set { _no_hp = value; }
        }

        public string alamat
        {
            get { return _alamat; }
            set { _alamat = value; }
        }

        public virtual string getDisplayInfo()
        {
            return nama_lengkap + " - " + no_hp;
        }
    }
}
