namespace simanik_kel4.model
{
    internal class PrescriptionDetail
    {
        private int _id_detail;
        private int _id_pemeriksaan;
        private int _id_obat;
        private int _jumlah;
        private string _catatan_aturan;

        public PrescriptionDetail()
        {
            _id_detail = 0;
            _id_pemeriksaan = 0;
            _id_obat = 0;
            _jumlah = 0;
            _catatan_aturan = "";
        }

        public int id_detail
        {
            get { return _id_detail; }
            set { _id_detail = value; }
        }

        public int id_pemeriksaan
        {
            get { return _id_pemeriksaan; }
            set { _id_pemeriksaan = value; }
        }

        public int id_obat
        {
            get { return _id_obat; }
            set { _id_obat = value; }
        }

        public int jumlah
        {
            get { return _jumlah; }
            set { _jumlah = value; }
        }

        public string catatan_aturan
        {
            get { return _catatan_aturan; }
            set { _catatan_aturan = value; }
        }

        public bool validateQuantity()
        {
            return jumlah > 0;
        }
    }
}
