using System;
using System.Drawing;
using System.Windows.Forms;

namespace simanik_kel4.view
{
    using service;

    public class dashboard_admin_fm : Form
    {
        Dashboard_serv Dashboard = new Dashboard_serv();
        FlowLayoutPanel cardPanel;
        DataGridView data_dgv;
        string username;

        Color primary = Color.FromArgb(0, 38, 87);
        Color secondary = Color.FromArgb(0, 62, 170);
        Color background = Color.FromArgb(244, 251, 254);
        Color card = Color.FromArgb(234, 247, 252);
        Color textColor = Color.FromArgb(7, 42, 56);

        public dashboard_admin_fm(string namaUser)
        {
            username = namaUser;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // dashboard_admin_fm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "dashboard_admin_fm";
            this.Load += new System.EventHandler(this.dashboard_admin_fm_Load_1);
            this.ResumeLayout(false);

        }

        private Button buatMenu(string teks, int top)
        {
            Button btn = new Button();
            btn.Text = teks;
            btn.Tag = teks;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ForeColor = Color.White;
            btn.BackColor = primary;
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn.Location = new Point(0, top);
            btn.Size = new Size(220, 40);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(24, 0, 0, 0);
            btn.Click += menu_btn_Click;
            return btn;
        }

        private Panel buatCard(string judul, int nilai)
        {
            Panel panel = new Panel();
            panel.BackColor = card;
            panel.Size = new Size(205, 70);
            panel.Margin = new Padding(0, 0, 16, 16);

            Label angka_lbl = new Label();
            angka_lbl.Text = nilai.ToString();
            angka_lbl.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            angka_lbl.ForeColor = secondary;
            angka_lbl.Location = new Point(15, 8);
            angka_lbl.AutoSize = true;

            Label judul_lbl = new Label();
            judul_lbl.Text = judul;
            judul_lbl.Font = new Font("Segoe UI", 9F);
            judul_lbl.ForeColor = textColor;
            judul_lbl.Location = new Point(16, 44);
            judul_lbl.AutoSize = true;

            panel.Controls.Add(angka_lbl);
            panel.Controls.Add(judul_lbl);
            return panel;
        }

        private void dashboard_admin_fm_Load(object sender, EventArgs e)
        {
            cardPanel.Controls.Clear();
            cardPanel.Controls.Add(buatCard("Total pasien", Dashboard.getTotalPasien()));
            cardPanel.Controls.Add(buatCard("Dokter aktif", Dashboard.getTotalDokterAktif()));
            cardPanel.Controls.Add(buatCard("Reservasi hari ini", Dashboard.getReservasiHariIni()));
            cardPanel.Controls.Add(buatCard("Menunggu verifikasi", Dashboard.getReservasiMenunggu()));
            cardPanel.Controls.Add(buatCard("Check-in hari ini", Dashboard.getCheckInHariIni()));
            cardPanel.Controls.Add(buatCard("Pemeriksaan selesai", Dashboard.getPemeriksaanSelesaiHariIni()));
            data_dgv.DataSource = Dashboard.getReservasiTerbaru();
        }

        private void menu_btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null)
            {
                return;
            }

            string menu = btn.Tag.ToString();
            if (menu == "User") new user_fm().ShowDialog();
            else if (menu == "Dokter") new dokter_fm().ShowDialog();
            else if (menu == "Jadwal") new jadwal_dokter_fm().ShowDialog();
            else if (menu == "Pasien") new pasien_fm().ShowDialog();
            else if (menu == "Reservasi") new reservasi_fm().ShowDialog();
            else if (menu == "Check-in") new checkin_fm().ShowDialog();
            else if (menu == "Antrian") new antrian_fm().ShowDialog();
            else if (menu == "Penyakit") new penyakit_fm().ShowDialog();
            else if (menu == "Obat") new obat_fm().ShowDialog();
            else if (menu == "Rekam Medis") new rekam_medis_fm().ShowDialog();
            else if (menu == "Riwayat") new riwayat_fm().ShowDialog();
            else if (menu == "Laporan") new laporan_fm().ShowDialog();
        }

        private void dashboard_admin_fm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
