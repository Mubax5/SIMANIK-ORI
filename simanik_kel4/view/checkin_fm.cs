using System;
using System.Drawing;
using System.Windows.Forms;

namespace simanik_kel4.view
{
    using service;

    public class checkin_fm : Form
    {
        Reservation_serv Reservasi = new Reservation_serv();
        Visit_serv Visit = new Visit_serv();
        DataGridView data_dgv;

        Color primary = Color.FromArgb(0, 38, 87);
        Color secondary = Color.FromArgb(0, 62, 170);
        Color background = Color.FromArgb(244, 251, 254);

        public checkin_fm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Check-in Pasien";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(920, 560);
            this.BackColor = background;

            Label judul_lbl = new Label();
            judul_lbl.Text = "Check-in Pasien";
            judul_lbl.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            judul_lbl.ForeColor = primary;
            judul_lbl.Location = new Point(30, 25);
            judul_lbl.AutoSize = true;

            Button checkin_btn = new Button();
            checkin_btn.Text = "Check-in";
            checkin_btn.BackColor = secondary;
            checkin_btn.ForeColor = Color.White;
            checkin_btn.FlatStyle = FlatStyle.Flat;
            checkin_btn.Location = new Point(700, 82);
            checkin_btn.Size = new Size(95, 34);
            checkin_btn.Click += checkin_btn_Click;

            Button keluar_btn = new Button();
            keluar_btn.Text = "Keluar";
            keluar_btn.Location = new Point(805, 82);
            keluar_btn.Size = new Size(75, 34);
            keluar_btn.Click += keluar_btn_Click;

            data_dgv = new DataGridView();
            data_dgv.Location = new Point(30, 135);
            data_dgv.Size = new Size(850, 380);
            data_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            data_dgv.BackgroundColor = Color.White;

            this.Controls.Add(judul_lbl);
            this.Controls.Add(checkin_btn);
            this.Controls.Add(keluar_btn);
            this.Controls.Add(data_dgv);
            this.Load += checkin_fm_Load;
        }

        private void checkin_fm_Load(object sender, EventArgs e)
        {
            tampilGrid();
        }

        void tampilGrid()
        {
            data_dgv.DataSource = Reservasi.viewAll();
        }

        private void checkin_btn_Click(object sender, EventArgs e)
        {
            if (data_dgv.CurrentRow != null)
            {
                string kode = data_dgv.CurrentRow.Cells["id_reservasi"].Value.ToString();
                if (!Visit.isExist(kode))
                {
                    Visit.id_reservasi = Convert.ToInt32(kode);
                    Visit.nomor_antrian = Visit.createQueueNumber();
                    Visit.status_kunjungan = "Menunggu";
                    Visit.save();
                }
                Reservasi.updateStatus(kode, "Check-in");
                tampilGrid();
            }
        }

        private void keluar_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
