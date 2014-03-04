using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodega.Repositorio;
using Bodega.Entidades;

namespace Bodega.Datos.Model
{
    public class FacturaRepository : 
        IRepositorioDetalles<FacturaCabecera, FacturaDetalle>,
        IRepositorioLectura<FacturasComplex>
    {
        private BodegaEntities Contexto;

        public FacturaRepository()
        {
            Contexto = new BodegaEntities();
            Detalles = new List<FacturaDetalle>();
        }

        private FacturaCabecera _entidad;
        public FacturaCabecera Entidad
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

        public List<FacturaDetalle> Detalles { get; set; }

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
                    Entidad.IdFacturaCabecera = Guid.NewGuid()
                        .ToString();
                    Entidad.Numero = Contexto.FacturaCabecera.Count() + 1;
                    Entidad.Serie = 1;

                    Contexto.FacturaCabecera.Add(Entidad);
                    // Recorrido por todos los detalles para hacer la validación.
                    foreach (var item in Detalles)
                    {
                        item.IdFacturaDetalle = Guid.NewGuid().ToString();
                        item.IdFacturaCabecera = Entidad.IdFacturaCabecera;
                        Contexto.FacturaDetalle.Add(item);
                    }
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
            throw new NotImplementedException();
        }

        public void Crear()
        {
            Entidad = new FacturaCabecera();
            Detalles = new List<FacturaDetalle>();
            IsNew = true;
        }

        public void GetByID(string ID)
        {
            throw new NotImplementedException();
        }

        public List<FacturaCabecera> GetAllRegistros()
        {
            return Contexto.FacturaCabecera.ToList();
        }

        public void Dispose()
        {
            Entidad = null;
            Contexto = null;
        }

        public List<FacturasComplex> ListarRegistros()
        {
            return Contexto.ListarFacturas().ToList();
        }


        public List<FacturaCabecera> GetRegistros_Filtros(int opc, string valor)
        {
            throw new NotImplementedException();
        }
    }
}
