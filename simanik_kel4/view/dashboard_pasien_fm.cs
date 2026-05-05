using System.Drawing;
using System.Windows.Forms;

namespace simanik_kel4.view
{
    using service;

    public class dashboard_pasien_fm : Form
    {
        Reservation_serv Reservasi = new Reservation_serv();
        string username;

        Color primary = Color.FromArgb(0, 38, 87);
        Color secondary = Color.FromArgb(0, 62, 170);
        Color background = Color.FromArgb(244, 251, 254);
        Color card = Color.FromArgb(234, 247, 252);
        Color textColor = Color.FromArgb(7, 42, 56);

        public dashboard_pasien_fm(string namaUser)
        {
            username = namaUser;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Dashboard Pasien";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(980, 610);
            this.BackColor = background;

            Panel header = new Panel();
            header.BackColor = primary;
            header.Dock = DockStyle.Top;
            header.Height = 78;

            Label title_lbl = new Label();
            title_lbl.Text = "Dashboard Pasien - " + username;
            title_lbl.ForeColor = Color.White;
            title_lbl.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            title_lbl.Location = new Point(30, 20);
            title_lbl.AutoSize = true;
            header.Controls.Add(title_lbl);

            Panel profilPanel = new Panel();
            profilPanel.BackColor = card;
            profilPanel.Location = new Point(30, 105);
            profilPanel.Size = new Size(920, 80);

            Label profil_lbl = new Label();
            profil_lbl.Text = "Reservasi dan riwayat pasien";
            profil_lbl.ForeColor = textColor;
            profil_lbl.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            profil_lbl.Location = new Point(20, 22);
            profil_lbl.AutoSize = true;
            profilPanel.Controls.Add(profil_lbl);

            DataGridView data_dgv = new DataGridView();
            data_dgv.Location = new Point(30, 215);
            data_dgv.Size = new Size(920, 300);
            data_dgv.BackgroundColor = Color.White;
            data_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            data_dgv.DataSource = Reservasi.viewAll();

            Button reservasi_btn = new Button();
            reservasi_btn.Text = "Buat Reservasi";
            reservasi_btn.BackColor = secondary;
            reservasi_btn.ForeColor = Color.White;
            reservasi_btn.FlatStyle = FlatStyle.Flat;
            reservasi_btn.Location = new Point(650, 535);
            reservasi_btn.Size = new Size(140, 38);
            reservasi_btn.Click += delegate { new reservasi_fm().ShowDialog(); };

            Button riwayat_btn = new Button();
            riwayat_btn.Text = "Riwayat";
            riwayat_btn.BackColor = Color.White;
            riwayat_btn.ForeColor = primary;
            riwayat_btn.FlatStyle = FlatStyle.Flat;
            riwayat_btn.Location = new Point(810, 535);
            riwayat_btn.Size = new Size(140, 38);
            riwayat_btn.Click += delegate { new riwayat_fm().ShowDialog(); };

            this.Controls.Add(header);
            this.Controls.Add(profilPanel);
            this.Controls.Add(data_dgv);
            this.Controls.Add(reservasi_btn);
            this.Controls.Add(riwayat_btn);
        }
    }
}
