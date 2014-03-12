using System.Collections.Generic;

namespace Bodega.Repositorio
{
    public interface IRepositorioLectura<TEntityComplex>
        where TEntityComplex : class
    {

        IEnumerable<TEntityComplex> ListarRegistros();

    }
}
