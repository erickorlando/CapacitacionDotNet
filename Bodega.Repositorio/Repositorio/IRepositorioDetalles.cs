using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodega.Repositorio
{
    public interface IRepositorioDetalles <TEntity, TDetalles>
        : IRepositorio<TEntity>
        where TEntity : class
        where TDetalles : class
    {
        
        List<TDetalles> Detalles { get; set; }

    }
}
