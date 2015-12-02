using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Bodega.Access
{
    static class Conexion
    {

        public static string CadenaConexion()
        {
            return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='Bodega.accdb'";
        }

    }
}
