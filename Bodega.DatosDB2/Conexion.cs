using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Bodega.DatosDB2
{
    static class Conexion
    {

        public static string CadenaConexion()
        {
            return ConfigurationManager
                .ConnectionStrings["BodegaDB2"].ConnectionString;
        }

    }
}
