using System;
using System.Collections.Generic;
using System.Linq;
using Bodega.Repositorio;
using Bodega.Entidades;

namespace Bodega.Datos.Model
{
    public class ClientesRepository : IRepositorio<Clientes>
    {
        private BodegaEntities Contexto;

        public ClientesRepository()
        {
            Contexto = new BodegaEntities();
        }

        private Clientes _entidad;
        public Clientes Entidad
        {
            get
            {
                return _entidad;
            }
            set
            {
                _entidad = value;
            }
        }

        private bool _isNew;
        public bool IsNew
        {
            get
            {
                return _isNew;
            }
            set
            {
                _isNew = value;
            }
        }

        public bool Guardar()
        {
            try
            {
                if (IsNew)
                {
                    Entidad.IdCliente = Guid.NewGuid().ToString();
                    Contexto.Clientes.Add(Entidad);
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

                var query = Contexto.Clientes
                    .SingleOrDefault
                    (c => c.IdCliente == Entidad.IdCliente);
                if (query != null)
                    Contexto.Clientes.Remove(query);
                Contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Clientes> GetAllRegistros()
        {
            Contexto = new BodegaEntities();
            return Contexto.ListarClientes().ToList();
        }

        public void Crear()
        {
            Entidad = new Clientes();
            IsNew = true;
        }

        public void GetByID(string ID)
        {
            Entidad = Contexto.Clientes
                .Where(c => c.IdCliente == ID).SingleOrDefault();
            IsNew = false;
        }


        ///Listar con filtros
        public List<Clientes> GetRegistros_Filtros( int opc, string valor)
        {
            Contexto = new BodegaEntities();
            var Busqueda =new  List<Clientes>();

            switch (opc)
            {
                case 1:
                    Busqueda = Contexto.ListarClientes().Where(c => c.Apellidos.ToLower().Contains(valor.ToLower())).ToList();
                    break;

                case 2:
                    Busqueda = Contexto.ListarClientes().Where(c => c.Nombres.ToLower().Contains(valor.ToLower())).ToList();
                    break;

                default:
                    Busqueda = Contexto.ListarClientes().ToList();
                    break;
            }

            return Busqueda;
        }




        public void Dispose()
        {
            Contexto = null;
        }

     
       

    }
}
