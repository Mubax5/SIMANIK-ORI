using System;
using System.Data;

namespace simanik_kel4.service
{
    using konfigurasi;
    using model;

    internal class User_serv : UserAccount
    {
        Koneksi server;
        string Query;

        public User_serv()
        {
            server = new Koneksi();
            Query = "";
        }

        public bool isExist(string usernameUser)
        {
            bool cek = false;
            Query = "select * from user where username='" + usernameUser + "'";
            if (server.eksekusiQuery(Query).Rows.Count > 0)
            {
                cek = true;
            }

            return cek;
        }

        public int save()
        {
            int nilai = -1;
            Query = "insert into user(username, password, role, aktif) values('" + username + "', '" + password + "', '" + role + "', " + (aktif ? "1" : "0") + ")";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public DataTable viewAll()
        {
            Query = "select id_user, username, role, aktif, dibuat_pada from user";
            return server.eksekusiQuery(Query);
        }

        public int update(int id)
        {
            int nilai = -1;
            Query = "update user set username='" + username + "', password='" + password + "', role='" + role + "', aktif=" + (aktif ? "1" : "0") + " where id_user='" + id + "'";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public int delete(int id)
        {
            int nilai = -1;
            Query = "delete from user where id_user='" + id + "'";

            try
            {
                nilai = server.eksekusiNonQuery(Query);
            }
            catch (Exception) { }

            return nilai;
        }

        public DataTable searchByNama(string nama)
        {
            Query = "select id_user, username, role, aktif, dibuat_pada from user where username like '" + nama + "%'";
            return server.eksekusiQuery(Query);
        }

        public string createCode()
        {
            string kode = "";
            int jumlah = 0;
            DataTable data = new DataTable();

            Query = "SELECT IFNULL(MAX(id_user),0)+1 AS jumlah FROM user";
            data = server.eksekusiQuery(Query);
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dt in data.Rows)
                {
                    jumlah = Convert.ToInt32(dt[0]);
                }

                kode = jumlah.ToString();
            }

            return kode;
        }
    }
}
