namespace simanik_kel4.model
{
    internal class AdminAccount : UserAccount
    {
        public AdminAccount()
        {
            role = "Admin";
        }

        public string[] getDashboardMenu()
        {
            return new string[] { "Dashboard", "Akun", "Dokter", "Jadwal", "Pasien", "Reservasi", "Check-in", "Antrian", "Penyakit", "Obat", "Laporan" };
        }
    }
}
