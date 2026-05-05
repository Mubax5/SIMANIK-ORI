using System;
using System.Drawing;
using System.Windows.Forms;

namespace simanik_kel4.view
{
    using service;

    public class obat_fm : Form
    {
        Medicine_serv Obat = new Medicine_serv();
        DataGridView data_dgv;
        TextBox cari_txt;

        Color primary = Color.FromArgb(0, 38, 87);
        Color secondary = Color.FromArgb(0, 62, 170);
        Color background = Color.FromArgb(244, 251, 254);

        public obat_fm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Data Obat";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(900, 560);
            this.BackColor = background;

            Label judul_lbl = new Label();
            judul_lbl.Text = "Master Data Obat";
            judul_lbl.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            judul_lbl.ForeColor = primary;
            judul_lbl.Location = new Point(30, 25);
            judul_lbl.AutoSize = true;

            cari_txt = new TextBox();
            cari_txt.Font = new Font("Segoe UI", 10F);
            cari_txt.Location = new Point(30, 85);
            cari_txt.Size = new Size(650, 30);
            cari_txt.TextChanged += cari_txt_TextChanged;

            Button stok_btn = new Button();
            stok_btn.Text = "Stok rendah";
            stok_btn.BackColor = secondary;
            stok_btn.ForeColor = Color.White;
            stok_btn.FlatStyle = FlatStyle.Flat;
            stok_btn.Location = new Point(690, 82);
            stok_btn.Size = new Size(100, 34);
            stok_btn.Click += stok_btn_Click;

            Button keluar_btn = new Button();
            keluar_btn.Text = "Keluar";
            keluar_btn.Location = new Point(800, 82);
            keluar_btn.Size = new Size(75, 34);
            keluar_btn.Click += keluar_btn_Click;

            data_dgv = new DataGridView();
            data_dgv.Location = new Point(30, 135);
            data_dgv.Size = new Size(845, 380);
            data_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            data_dgv.BackgroundColor = Color.White;

            this.Controls.Add(judul_lbl);
            this.Controls.Add(cari_txt);
            this.Controls.Add(stok_btn);
            this.Controls.Add(keluar_btn);
            this.Controls.Add(data_dgv);
            this.Load += obat_fm_Load;
        }

        private void obat_fm_Load(object sender, EventArgs e)
        {
            tampilGrid();
        }

        void tampilGrid()
        {
            if (cari_txt.Text.Length == 0) data_dgv.DataSource = Obat.viewAll();
            else data_dgv.DataSource = Obat.searchByNama(cari_txt.Text);
        }

        private void stok_btn_Click(object sender, EventArgs e)
        {
            data_dgv.DataSource = Obat.viewStokRendah();
        }

        private void cari_txt_TextChanged(object sender, EventArgs e)
        {
            tampilGrid();
        }

        private void keluar_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
