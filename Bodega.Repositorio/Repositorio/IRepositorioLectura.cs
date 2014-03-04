using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodega.Repositorio
{
    public interface IRepositorioLectura<TEntityComplex>
        where TEntityComplex : class
    {

        List<TEntityComplex> ListarRegistros();

    }
}
