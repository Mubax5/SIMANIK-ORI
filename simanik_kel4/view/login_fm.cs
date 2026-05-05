using System;
using System.Drawing;
using System.Windows.Forms;

namespace simanik_kel4.view
{
    using service;

    public class login_fm : Form
    {
        Auth_serv Auth = new Auth_serv();
        TextBox username_txt;
        TextBox password_txt;
        Button login_btn;
        Button register_btn;

        Color primary = Color.FromArgb(0, 38, 87);
        Color secondary = Color.FromArgb(0, 62, 170);
        Color background = Color.FromArgb(244, 251, 254);
        Color card = Color.FromArgb(234, 247, 252);
        Color textColor = Color.FromArgb(7, 42, 56);

        public login_fm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "SIMANIK - Login";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(760, 430);
            this.BackColor = background;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            Panel header = new Panel();
            header.BackColor = primary;
            header.Dock = DockStyle.Top;
            header.Height = 86;

            Label title_lbl = new Label();
            title_lbl.Text = "SIMANIK";
            title_lbl.ForeColor = Color.White;
            title_lbl.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            title_lbl.Location = new Point(38, 18);
            title_lbl.AutoSize = true;

            Label subtitle_lbl = new Label();
            subtitle_lbl.Text = "Sistem Informasi dan Manajemen Klinik";
            subtitle_lbl.ForeColor = Color.White;
            subtitle_lbl.Font = new Font("Segoe UI", 10F);
            subtitle_lbl.Location = new Point(42, 55);
            subtitle_lbl.AutoSize = true;

            header.Controls.Add(title_lbl);
            header.Controls.Add(subtitle_lbl);

            Panel loginPanel = new Panel();
            loginPanel.BackColor = card;
            loginPanel.Location = new Point(70, 125);
            loginPanel.Size = new Size(620, 230);

            Label username_lbl = new Label();
            username_lbl.Text = "Username";
            username_lbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            username_lbl.ForeColor = textColor;
            username_lbl.Location = new Point(40, 34);
            username_lbl.Size = new Size(150, 28);

            username_txt = new TextBox();
            username_txt.Font = new Font("Segoe UI", 10F);
            username_txt.Location = new Point(210, 30);
            username_txt.Size = new Size(360, 30);

            Label password_lbl = new Label();
            password_lbl.Text = "Password";
            password_lbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            password_lbl.ForeColor = textColor;
            password_lbl.Location = new Point(40, 84);
            password_lbl.Size = new Size(150, 28);

            password_txt = new TextBox();
            password_txt.Font = new Font("Segoe UI", 10F);
            password_txt.Location = new Point(210, 80);
            password_txt.Size = new Size(360, 30);
            password_txt.UseSystemPasswordChar = true;
            password_txt.KeyDown += password_txt_KeyDown;

            login_btn = new Button();
            login_btn.Text = "Login";
            login_btn.BackColor = secondary;
            login_btn.ForeColor = Color.White;
            login_btn.FlatStyle = FlatStyle.Flat;
            login_btn.Location = new Point(320, 145);
            login_btn.Size = new Size(120, 44);
            login_btn.Click += login_btn_Click;

            register_btn = new Button();
            register_btn.Text = "Register";
            register_btn.BackColor = Color.White;
            register_btn.ForeColor = primary;
            register_btn.FlatStyle = FlatStyle.Flat;
            register_btn.Location = new Point(450, 145);
            register_btn.Size = new Size(120, 44);
            register_btn.Click += register_btn_Click;

            loginPanel.Controls.Add(username_lbl);
            loginPanel.Controls.Add(username_txt);
            loginPanel.Controls.Add(password_lbl);
            loginPanel.Controls.Add(password_txt);
            loginPanel.Controls.Add(login_btn);
            loginPanel.Controls.Add(register_btn);

            this.Controls.Add(loginPanel);
            this.Controls.Add(header);
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (Auth.isLogin(username_txt.Text, password_txt.Text))
            {
                string role = Auth.ambilRole(username_txt.Text);
                this.Hide();

                if (role == "Admin")
                {
                    new dashboard_admin_fm(username_txt.Text).ShowDialog();
                }
                else if (role == "Dokter")
                {
                    new dashboard_dokter_fm(username_txt.Text).ShowDialog();
                }
                else
                {
                    new dashboard_pasien_fm(username_txt.Text).ShowDialog();
                }

                this.Show();
                username_txt.Clear();
                password_txt.Clear();
                username_txt.Focus();
            }
            else
            {
                MessageBox.Show("Username atau password salah.", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            new register_pasien_fm().ShowDialog();
        }

        private void password_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login_btn.PerformClick();
            }
        }
    }
}
