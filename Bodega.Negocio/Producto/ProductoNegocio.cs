using Bodega.Entidades;
using Bodega.Repositorio;

namespace Bodega.Negocio
{
    public class ProductoNegocio : BaseNegocio<Producto>
    {

        public ProductoNegocio(IRepositorio<Producto> repositorio)
        {
            Repositorio = repositorio;
        }

        public Producto EntidadProducto
        {
            get
            {
                return Repositorio.Entidad;
            }
            set { Repositorio.Entidad = value; }
        }
    }
}
