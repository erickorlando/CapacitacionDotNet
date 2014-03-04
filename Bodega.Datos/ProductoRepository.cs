using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodega.Datos.Model;
using Bodega.Repositorio;
using Bodega.Entidades;

namespace Bodega.Datos.Model
{
    public class ProductoRepository : IRepositorio<Producto>
    {
        private BodegaEntities Contexto;

        public ProductoRepository()
        {
            Contexto = new BodegaEntities();
        }
        public Producto Entidad { get; set; }
        public bool IsNew { get; set; }

        public bool Guardar()
        {
            try
            {
                if (IsNew)
                {
                    Entidad.IdProducto = Guid.NewGuid().ToString();
                    Entidad.Codigo = Contexto.Producto
                        .Count() + 1;
                    Contexto.Producto.Add(Entidad);
                }
                Contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Eliminar()
        {
            try
            {
                if (IsNew)
                    throw new InvalidOperationException("Un registro nuevo no se puede eliminar");

                var query = Contexto.Producto
                    .SingleOrDefault
                    (c => c.IdProducto == Entidad.IdProducto);
                if (query != null)
                    Contexto.Producto.Remove(query);
                Contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<Producto> GetAllRegistros()
        {
            Contexto = new BodegaEntities();
            return Contexto.ListarProductos().ToList();
        }

        public void Crear()
        {
            Entidad = new Producto();
            IsNew = true;
        }

        public void GetByID(string ID)
        {
            Entidad = Contexto.Producto
                .Where(p => p.IdProducto == ID)
                .SingleOrDefault();
            IsNew = false;
        }

        
        public void GetByCodigo(int Codigo)
        {
            Entidad = Contexto.Producto
                .Where(p => p.Codigo == Codigo)
                .SingleOrDefault();
            IsNew = false;
        }
        
        public void Dispose()
        {
            Contexto = null;
        }




        public List<Producto> GetRegistros_Filtros(int opc, string valor)
        {
            throw new NotImplementedException();
        }
    }
}
