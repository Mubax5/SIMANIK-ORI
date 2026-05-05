using System;

namespace simanik_kel4.model
{
    internal class UserAccount
    {
        private int _id_user;
        private string _username;
        private string _password;
        private string _role;
        private bool _aktif;
        private DateTime _dibuat_pada;

        public UserAccount()
        {
            _id_user = 0;
            _username = "";
            _password = "";
            _role = "";
            _aktif = true;
            _dibuat_pada = DateTime.Now;
        }

        public int id_user
        {
            get { return _id_user; }
            set { _id_user = value; }
        }

        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string role
        {
            get { return _role; }
            set { _role = value; }
        }

        public bool aktif
        {
            get { return _aktif; }
            set { _aktif = value; }
        }

        public DateTime dibuat_pada
        {
            get { return _dibuat_pada; }
            set { _dibuat_pada = value; }
        }

        public virtual string getRoleName()
        {
            return role;
        }

        public virtual bool canAccess(string fitur)
        {
            if (role == "Admin")
            {
                return true;
            }

            if (role == "Dokter")
            {
                return fitur == "Dashboard" || fitur == "Antrian" || fitur == "Pemeriksaan" || fitur == "Riwayat" || fitur == "Penyakit" || fitur == "Obat";
            }

            if (role == "Pasien")
            {
                return fitur == "Dashboard" || fitur == "Profil" || fitur == "Reservasi" || fitur == "Riwayat";
            }

            return false;
        }
    }
}
