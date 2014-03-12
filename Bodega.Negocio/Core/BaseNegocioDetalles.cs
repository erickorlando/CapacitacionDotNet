using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodega.Repositorio;

namespace Bodega.Negocio
{
    public class BaseNegocioDetalles<TEntity, TDetalles> : BaseNegocio<TEntity>
        where TEntity : class
        where TDetalles : class
    {
        public new IRepositorioDetalles<TEntity, TDetalles> Repositorio { get; set; }

        public override IEnumerable<TEntity> Listar()
        {
            return Repositorio.ListarAllRegistros();
        }

        public override bool Guardar()
        {
            return Repositorio.Guardar();
        }

        public override void Crear()
        {
            Repositorio.Crear();
        }
      
    }

    
}
