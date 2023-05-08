using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Sis_ControlPagos
{
    using System.Data.SqlClient;

    class Conexion
    {
        public static SqlConnection conectar()
        {
            SqlConnection cn = new SqlConnection("SERVER=JRIVERAPC\\SQLEXPRESS;DATABASE=proyectoecomuni2023;integrated security=true");
            cn.Open();
            return cn;
        }
    }
}

