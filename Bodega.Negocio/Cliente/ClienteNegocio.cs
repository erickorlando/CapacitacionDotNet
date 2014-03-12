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
		public IEnumerable<Clientes> ListarClientes()
		{
			return Repositorio.ListarAllRegistros();
		}

		public IEnumerable<Clientes> Listar_Busqueda(int opc, string busqueda)
		{
			return Repositorio.ListarAllRegistros(opc, busqueda);
		}


		public void Crear()
		{
			Repositorio.Crear();
		}

		public void GetByID(string ID)
		{
			Repositorio.GetById(ID);
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
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (Repositorio != null)
					Repositorio.Dispose();
			}
		}

		public bool Eliminar()
		{
			return Repositorio.Eliminar();
		}
	}
}
