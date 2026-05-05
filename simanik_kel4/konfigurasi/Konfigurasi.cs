using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace simanik_kel4.konfigurasi
{
    abstract class Konfigurasi
    {
        //untuk menangani instruksi INSERT, UPDATE dan DELETE
        public abstract int eksekusiNonQuery(string query);

        //untuk menangani instruksi
        public abstract DataTable eksekusiQuery(string query);

    }
}
