using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MusteriOtomasyonu
{
     class connect
    {
        Adress add = new Adress();
        public SqlConnection conn()
        {
            SqlConnection conn = new SqlConnection(add.Adres);
            conn.Open();
            return conn;
        }

    }
}
