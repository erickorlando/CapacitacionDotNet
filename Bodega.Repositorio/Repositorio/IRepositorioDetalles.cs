using System.Collections.Generic;

namespace Bodega.Repositorio
{
    public interface IRepositorioDetalles <TEntity, TDetalles>
        : IRepositorio<TEntity>
        where TEntity : class
        where TDetalles : class
    {
        
        IEnumerable<TDetalles> Detalles { get; set; }

    }
}
