using System;
using System.Drawing;
using System.Windows.Forms;

namespace simanik_kel4.view
{
    using service;

    public class laporan_fm : Form
    {
        Report_serv Report = new Report_serv();
        DataGridView data_dgv;
        ComboBox laporan_cmb;

        Color primary = Color.FromArgb(0, 38, 87);
        Color secondary = Color.FromArgb(0, 62, 170);
        Color background = Color.FromArgb(244, 251, 254);

        public laporan_fm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Laporan";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(920, 560);
            this.BackColor = background;

            Label judul_lbl = new Label();
            judul_lbl.Text = "Laporan Klinik";
            judul_lbl.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            judul_lbl.ForeColor = primary;
            judul_lbl.Location = new Point(30, 25);
            judul_lbl.AutoSize = true;

            laporan_cmb = new ComboBox();
            laporan_cmb.Font = new Font("Segoe UI", 10F);
            laporan_cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            laporan_cmb.Location = new Point(30, 85);
            laporan_cmb.Size = new Size(650, 30);
            laporan_cmb.Items.AddRange(new object[] { "Reservasi per hari", "Reservasi per dokter", "Kunjungan selesai", "Penyakit terbanyak", "Obat sering diberikan", "Stok rendah" });
            laporan_cmb.SelectedIndex = 0;
            laporan_cmb.SelectedIndexChanged += laporan_cmb_SelectedIndexChanged;

            Button muat_btn = new Button();
            muat_btn.Text = "Muat";
            muat_btn.BackColor = secondary;
            muat_btn.ForeColor = Color.White;
            muat_btn.FlatStyle = FlatStyle.Flat;
            muat_btn.Location = new Point(700, 82);
            muat_btn.Size = new Size(75, 34);
            muat_btn.Click += muat_btn_Click;

            Button keluar_btn = new Button();
            keluar_btn.Text = "Keluar";
            keluar_btn.Location = new Point(785, 82);
            keluar_btn.Size = new Size(75, 34);
            keluar_btn.Click += keluar_btn_Click;

            data_dgv = new DataGridView();
            data_dgv.Location = new Point(30, 135);
            data_dgv.Size = new Size(850, 380);
            data_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            data_dgv.BackgroundColor = Color.White;

            this.Controls.Add(judul_lbl);
            this.Controls.Add(laporan_cmb);
            this.Controls.Add(muat_btn);
            this.Controls.Add(keluar_btn);
            this.Controls.Add(data_dgv);
            this.Load += laporan_fm_Load;
        }

        private void laporan_fm_Load(object sender, EventArgs e)
        {
            tampilGrid();
        }

        void tampilGrid()
        {
            if (laporan_cmb.Text == "Reservasi per hari") data_dgv.DataSource = Report.laporanReservasiPerHari();
            else if (laporan_cmb.Text == "Reservasi per dokter") data_dgv.DataSource = Report.laporanReservasiPerDokter();
            else if (laporan_cmb.Text == "Kunjungan selesai") data_dgv.DataSource = Report.laporanKunjunganSelesai();
            else if (laporan_cmb.Text == "Penyakit terbanyak") data_dgv.DataSource = Report.laporanPenyakitTerbanyak();
            else if (laporan_cmb.Text == "Obat sering diberikan") data_dgv.DataSource = Report.laporanObatSeringDiberikan();
            else data_dgv.DataSource = Report.laporanStokRendah();
        }

        private void laporan_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            tampilGrid();
        }

        private void muat_btn_Click(object sender, EventArgs e)
        {
            tampilGrid();
        }

        private void keluar_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
