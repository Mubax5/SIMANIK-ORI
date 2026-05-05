namespace simanik_kel4.model
{
    internal class DoctorAccount : UserAccount
    {
        public DoctorAccount()
        {
            role = "Dokter";
        }

        public string[] getDashboardMenu()
        {
            return new string[] { "Dashboard", "Antrian", "Pemeriksaan", "Riwayat" };
        }
    }
}
