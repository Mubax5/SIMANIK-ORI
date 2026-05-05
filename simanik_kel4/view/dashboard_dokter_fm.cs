using System.Drawing;
using System.Windows.Forms;

namespace simanik_kel4.view
{
    using service;

    public class dashboard_dokter_fm : Form
    {
        Visit_serv Visit = new Visit_serv();
        string username;

        Color primary = Color.FromArgb(0, 38, 87);
        Color secondary = Color.FromArgb(0, 62, 170);
        Color background = Color.FromArgb(244, 251, 254);
        Color card = Color.FromArgb(234, 247, 252);
        Color textColor = Color.FromArgb(7, 42, 56);

        public dashboard_dokter_fm(string namaUser)
        {
            username = namaUser;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Dashboard Dokter";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(1000, 620);
            this.BackColor = background;

            Panel header = new Panel();
            header.BackColor = primary;
            header.Dock = DockStyle.Top;
            header.Height = 78;

            Label title_lbl = new Label();
            title_lbl.Text = "Dashboard Dokter - " + username;
            title_lbl.ForeColor = Color.White;
            title_lbl.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            title_lbl.Location = new Point(30, 20);
            title_lbl.AutoSize = true;
            header.Controls.Add(title_lbl);

            Panel infoPanel = new Panel();
            infoPanel.BackColor = card;
            infoPanel.Location = new Point(30, 105);
            infoPanel.Size = new Size(930, 80);

            Label info_lbl = new Label();
            info_lbl.Text = "Antrian pasien hari ini";
            info_lbl.ForeColor = secondary;
            info_lbl.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            info_lbl.Location = new Point(20, 22);
            info_lbl.AutoSize = true;
            infoPanel.Controls.Add(info_lbl);

            DataGridView data_dgv = new DataGridView();
            data_dgv.Location = new Point(30, 215);
            data_dgv.Size = new Size(930, 330);
            data_dgv.BackgroundColor = Color.White;
            data_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            data_dgv.DataSource = Visit.viewAntrianHariIni();

            Button periksa_btn = new Button();
            periksa_btn.Text = "Buka Pemeriksaan";
            periksa_btn.BackColor = secondary;
            periksa_btn.ForeColor = Color.White;
            periksa_btn.FlatStyle = FlatStyle.Flat;
            periksa_btn.Location = new Point(800, 560);
            periksa_btn.Size = new Size(160, 38);
            periksa_btn.Click += delegate { new pemeriksaan_fm().ShowDialog(); };

            this.Controls.Add(header);
            this.Controls.Add(infoPanel);
            this.Controls.Add(data_dgv);
            this.Controls.Add(periksa_btn);
        }
    }
}
