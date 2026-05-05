using System.Data;

namespace simanik_kel4.service
{
    using konfigurasi;

    internal class Auth_serv
    {
        Koneksi server;
        string Query;

        public Auth_serv()
        {
            server = new Koneksi();
            Query = "";
        }

        public bool isLogin(string username, string password)
        {
            bool cek = false;
            Query = "select * from user where username='" + username + "' and password='" + password + "' and aktif=1";
            if (server.eksekusiQuery(Query).Rows.Count > 0)
            {
                cek = true;
            }

            return cek;
        }

        public DataTable login(string username, string password)
        {
            Query = "select * from user where username='" + username + "' and password='" + password + "' and aktif=1";
            return server.eksekusiQuery(Query);
        }

        public string ambilRole(string username)
        {
            string role = "";
            Query = "select role from user where username='" + username + "'";
            DataTable data = server.eksekusiQuery(Query);

            if (data.Rows.Count > 0)
            {
                role = data.Rows[0][0].ToString();
            }

            return role;
        }
    }
}
