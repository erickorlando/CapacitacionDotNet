using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodega.Repositorio;
using Bodega.Entidades;

namespace Bodega.Negocio
{
    public class ClienteNegocio : IDisposable
    {
        public IRepositorio<Clientes> Repositorio { get; set; }

        public ClienteNegocio(IRepositorio<Clientes> repositorio)
        {
            Repositorio = repositorio;
            
        }

        /// <summary>
        /// Metodo que lista los Clientes
        /// </summary>
        public List<Clientes> ListarClientes()
        {
            return Repositorio.GetAllRegistros();
        }

        public List<Clientes> Listar_Busqueda(int opc ,string busqueda)
        {
            return Repositorio.GetRegistros_Filtros(opc, busqueda);
        }


        public void Crear()
        {
            Repositorio.Crear();
        }

        public void GetByID(string ID)
        {
            Repositorio.GetByID(ID);
        }

        public bool Guardar()
        {
            // Regla de Validación
            if (string.IsNullOrEmpty(Repositorio.Entidad.Nombres))
                throw new InvalidOperationException();

            return Repositorio.Guardar();

        }

        public void Dispose()
        {
            if (Repositorio != null)
                Repositorio.Dispose();
            Repositorio = null;
        }

        public bool Eliminar()
        {
            return Repositorio.Eliminar();
        }
    }
}
