using System;
using System.Drawing;
using System.Windows.Forms;

namespace simanik_kel4.view
{
    using service;

    public class register_pasien_fm : Form
    {
        User_serv User = new User_serv();
        Patient_serv Pasien = new Patient_serv();

        TextBox username_txt;
        TextBox password_txt;
        TextBox konfirmasi_txt;
        TextBox nama_txt;
        DateTimePicker tanggal_lahir_dtp;
        ComboBox jenis_kelamin_cmb;
        TextBox no_hp_txt;
        TextBox alamat_txt;

        Color primary = Color.FromArgb(0, 38, 87);
        Color secondary = Color.FromArgb(0, 62, 170);
        Color background = Color.FromArgb(244, 251, 254);
        Color textColor = Color.FromArgb(7, 42, 56);

        public register_pasien_fm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Registrasi Pasien";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(720, 640);
            this.BackColor = background;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            Panel header = new Panel();
            header.BackColor = primary;
            header.Dock = DockStyle.Top;
            header.Height = 78;

            Label title_lbl = new Label();
            title_lbl.Text = "Registrasi Pasien Baru";
            title_lbl.ForeColor = Color.White;
            title_lbl.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            title_lbl.Location = new Point(32, 20);
            title_lbl.AutoSize = true;
            header.Controls.Add(title_lbl);

            TableLayoutPanel layout = new TableLayoutPanel();
            layout.Location = new Point(30, 105);
            layout.Size = new Size(660, 430);
            layout.ColumnCount = 2;
            layout.RowCount = 8;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66F));

            username_txt = buatTextBox(false);
            password_txt = buatTextBox(true);
            konfirmasi_txt = buatTextBox(true);
            nama_txt = buatTextBox(false);
            tanggal_lahir_dtp = new DateTimePicker();
            tanggal_lahir_dtp.Font = new Font("Segoe UI", 10F);
            tanggal_lahir_dtp.Format = DateTimePickerFormat.Short;
            tanggal_lahir_dtp.Dock = DockStyle.Fill;

            jenis_kelamin_cmb = new ComboBox();
            jenis_kelamin_cmb.Font = new Font("Segoe UI", 10F);
            jenis_kelamin_cmb.Dock = DockStyle.Fill;
            jenis_kelamin_cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            jenis_kelamin_cmb.Items.AddRange(new object[] { "Laki-laki", "Perempuan" });
            jenis_kelamin_cmb.SelectedIndex = 0;

            no_hp_txt = buatTextBox(false);
            alamat_txt = buatTextBox(false);
            alamat_txt.Multiline = true;

            tambahBaris(layout, "Username", username_txt, 0);
            tambahBaris(layout, "Password", password_txt, 1);
            tambahBaris(layout, "Konfirmasi", konfirmasi_txt, 2);
            tambahBaris(layout, "Nama lengkap", nama_txt, 3);
            tambahBaris(layout, "Tanggal lahir", tanggal_lahir_dtp, 4);
            tambahBaris(layout, "Jenis kelamin", jenis_kelamin_cmb, 5);
            tambahBaris(layout, "No. HP", no_hp_txt, 6);
            tambahBaris(layout, "Alamat", alamat_txt, 7);

            Button simpan_btn = new Button();
            simpan_btn.Text = "Register";
            simpan_btn.BackColor = secondary;
            simpan_btn.ForeColor = Color.White;
            simpan_btn.FlatStyle = FlatStyle.Flat;
            simpan_btn.Location = new Point(420, 560);
            simpan_btn.Size = new Size(120, 42);
            simpan_btn.Click += simpan_btn_Click;

            Button batal_btn = new Button();
            batal_btn.Text = "Batal";
            batal_btn.BackColor = Color.White;
            batal_btn.ForeColor = primary;
            batal_btn.FlatStyle = FlatStyle.Flat;
            batal_btn.Location = new Point(550, 560);
            batal_btn.Size = new Size(120, 42);
            batal_btn.Click += batal_btn_Click;

            this.Controls.Add(header);
            this.Controls.Add(layout);
            this.Controls.Add(simpan_btn);
            this.Controls.Add(batal_btn);
        }

        private TextBox buatTextBox(bool password)
        {
            TextBox teks = new TextBox();
            teks.Font = new Font("Segoe UI", 10F);
            teks.Dock = DockStyle.Fill;
            teks.UseSystemPasswordChar = password;
            return teks;
        }

        private void tambahBaris(TableLayoutPanel layout, string label, Control control, int row)
        {
            Label lbl = new Label();
            lbl.Text = label;
            lbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl.ForeColor = textColor;
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, row == 7 ? 92F : 48F));
            layout.Controls.Add(lbl, 0, row);
            layout.Controls.Add(control, 1, row);
        }

        private void simpan_btn_Click(object sender, EventArgs e)
        {
            if (password_txt.Text != konfirmasi_txt.Text)
            {
                MessageBox.Show("Konfirmasi password tidak sama.", "REGISTER", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (User.isExist(username_txt.Text))
            {
                MessageBox.Show("Username sudah dipakai.", "REGISTER", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idUser = Convert.ToInt32(User.createCode());
            User.username = username_txt.Text;
            User.password = password_txt.Text;
            User.role = "Pasien";
            User.aktif = true;

            if (User.save() > 0)
            {
                Pasien.id_user = idUser;
                Pasien.no_rekam_medis = Pasien.createNoRekamMedis();
                Pasien.nama_lengkap = nama_txt.Text;
                Pasien.tanggal_lahir = tanggal_lahir_dtp.Value;
                Pasien.jenis_kelamin = jenis_kelamin_cmb.Text;
                Pasien.no_hp = no_hp_txt.Text;
                Pasien.alamat = alamat_txt.Text;
                Pasien.save();

                MessageBox.Show("Registrasi berhasil.", "REGISTER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Registrasi gagal.", "REGISTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void batal_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
