using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodega.Repositorio;
using Bodega.Entidades;
using System.Collections.ObjectModel;

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

		public FacturaCabecera Entidad { get; set; }

		public IEnumerable<FacturaDetalle> Detalles { get; set; }

		public bool IsNew { get; set; }

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

		public void GetById(string ID)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<FacturaCabecera> ListarAllRegistros()
		{
			return Contexto.FacturaCabecera.ToList();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (Contexto != null)
					Contexto.Dispose();
			}
		}

		public IEnumerable<FacturasComplex> ListarRegistros()
		{
			return Contexto.ListarFacturas().ToList();
		}


		public IEnumerable<FacturaCabecera> ListarAllRegistros(int opc, string valor)
		{
			throw new NotImplementedException();
		}
	}
}
