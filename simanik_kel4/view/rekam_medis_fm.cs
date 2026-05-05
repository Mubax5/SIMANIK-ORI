using System;
using System.Drawing;
using System.Windows.Forms;

namespace simanik_kel4.view
{
    using service;

    public class rekam_medis_fm : Form
    {
        MedicalRecord_serv Rekam = new MedicalRecord_serv();
        DataGridView data_dgv;
        TextBox cari_txt;

        Color primary = Color.FromArgb(0, 38, 87);
        Color secondary = Color.FromArgb(0, 62, 170);
        Color background = Color.FromArgb(244, 251, 254);

        public rekam_medis_fm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Rekam Medis";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(900, 560);
            this.BackColor = background;

            Label judul_lbl = new Label();
            judul_lbl.Text = "Medical Record";
            judul_lbl.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            judul_lbl.ForeColor = primary;
            judul_lbl.Location = new Point(30, 25);
            judul_lbl.AutoSize = true;

            cari_txt = new TextBox();
            cari_txt.Font = new Font("Segoe UI", 10F);
            cari_txt.Location = new Point(30, 85);
            cari_txt.Size = new Size(650, 30);
            cari_txt.TextChanged += cari_txt_TextChanged;

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
            data_dgv.Size = new Size(830, 380);
            data_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            data_dgv.BackgroundColor = Color.White;

            this.Controls.Add(judul_lbl);
            this.Controls.Add(cari_txt);
            this.Controls.Add(muat_btn);
            this.Controls.Add(keluar_btn);
            this.Controls.Add(data_dgv);
            this.Load += rekam_medis_fm_Load;
        }

        private void rekam_medis_fm_Load(object sender, EventArgs e)
        {
            tampilGrid();
        }

        void tampilGrid()
        {
            if (cari_txt.Text.Length == 0) data_dgv.DataSource = Rekam.viewAll();
            else data_dgv.DataSource = Rekam.searchByNama(cari_txt.Text);
        }

        private void cari_txt_TextChanged(object sender, EventArgs e)
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
