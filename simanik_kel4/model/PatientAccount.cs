namespace simanik_kel4.model
{
    internal class PatientAccount : UserAccount
    {
        public PatientAccount()
        {
            role = "Pasien";
        }

        public string[] getDashboardMenu()
        {
            return new string[] { "Dashboard", "Reservasi", "Riwayat", "Profil" };
        }
    }
}
