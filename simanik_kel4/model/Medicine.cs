namespace simanik_kel4.model
{
    internal class Medicine
    {
        private int _id_obat;
        private string _nama_obat;
        private string _jenis_obat;
        private int _stok;
        private string _satuan;
        private string _aturan_pakai_default;
        private bool _aktif;

        public Medicine()
        {
            _id_obat = 0;
            _nama_obat = "";
            _jenis_obat = "";
            _stok = 0;
            _satuan = "";
            _aturan_pakai_default = "";
            _aktif = true;
        }

        public int id_obat
        {
            get { return _id_obat; }
            set { _id_obat = value; }
        }

        public string nama_obat
        {
            get { return _nama_obat; }
            set { _nama_obat = value; }
        }

        public string jenis_obat
        {
            get { return _jenis_obat; }
            set { _jenis_obat = value; }
        }

        public int stok
        {
            get { return _stok; }
            set { _stok = value; }
        }

        public string satuan
        {
            get { return _satuan; }
            set { _satuan = value; }
        }

        public string aturan_pakai_default
        {
            get { return _aturan_pakai_default; }
            set { _aturan_pakai_default = value; }
        }

        public bool aktif
        {
            get { return _aktif; }
            set { _aktif = value; }
        }

        public bool reduceStock(int qty)
        {
            if (qty <= 0 || qty > stok)
            {
                return false;
            }

            stok -= qty;
            return true;
        }

        public void addStock(int qty)
        {
            if (qty > 0)
            {
                stok += qty;
            }
        }

        public bool isLowStock()
        {
            return stok <= 10;
        }
    }
}
