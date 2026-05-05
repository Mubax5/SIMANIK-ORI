using System;
using System.Drawing;
using System.Windows.Forms;

namespace simanik_kel4.view
{
    using service;

    public class reservasi_fm : Form
    {
        Reservation_serv Reservasi = new Reservation_serv();
        DataGridView data_dgv;
        TextBox cari_txt;

        Color primary = Color.FromArgb(0, 38, 87);
        Color secondary = Color.FromArgb(0, 62, 170);
        Color background = Color.FromArgb(244, 251, 254);

        public reservasi_fm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Reservasi";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(940, 580);
            this.BackColor = background;

            Label judul_lbl = new Label();
            judul_lbl.Text = "Reservasi Digital";
            judul_lbl.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            judul_lbl.ForeColor = primary;
            judul_lbl.Location = new Point(30, 25);
            judul_lbl.AutoSize = true;

            cari_txt = new TextBox();
            cari_txt.Font = new Font("Segoe UI", 10F);
            cari_txt.Location = new Point(30, 85);
            cari_txt.Size = new Size(650, 30);
            cari_txt.TextChanged += cari_txt_TextChanged;

            Button konfirmasi_btn = new Button();
            konfirmasi_btn.Text = "Konfirmasi";
            konfirmasi_btn.BackColor = secondary;
            konfirmasi_btn.ForeColor = Color.White;
            konfirmasi_btn.FlatStyle = FlatStyle.Flat;
            konfirmasi_btn.Location = new Point(695, 82);
            konfirmasi_btn.Size = new Size(100, 34);
            konfirmasi_btn.Click += konfirmasi_btn_Click;

            Button keluar_btn = new Button();
            keluar_btn.Text = "Keluar";
            keluar_btn.Location = new Point(805, 82);
            keluar_btn.Size = new Size(75, 34);
            keluar_btn.Click += keluar_btn_Click;

            data_dgv = new DataGridView();
            data_dgv.Location = new Point(30, 135);
            data_dgv.Size = new Size(850, 390);
            data_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            data_dgv.BackgroundColor = Color.White;

            this.Controls.Add(judul_lbl);
            this.Controls.Add(cari_txt);
            this.Controls.Add(konfirmasi_btn);
            this.Controls.Add(keluar_btn);
            this.Controls.Add(data_dgv);
            this.Load += reservasi_fm_Load;
        }

        private void reservasi_fm_Load(object sender, EventArgs e)
        {
            tampilGrid();
        }

        void tampilGrid()
        {
            if (cari_txt.Text.Length == 0) data_dgv.DataSource = Reservasi.viewAll();
            else data_dgv.DataSource = Reservasi.searchByNama(cari_txt.Text);
        }

        private void konfirmasi_btn_Click(object sender, EventArgs e)
        {
            if (data_dgv.CurrentRow != null)
            {
                string kode = data_dgv.CurrentRow.Cells["id_reservasi"].Value.ToString();
                Reservasi.updateStatus(kode, "Dikonfirmasi");
                tampilGrid();
            }
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
