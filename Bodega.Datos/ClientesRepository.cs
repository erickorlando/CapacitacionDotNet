using System;
using System.Collections.Generic;
using System.Linq;
using Bodega.Repositorio;
using Bodega.Entidades;
using System.Collections.ObjectModel;

namespace Bodega.Datos.Model
{
	public class ClientesRepository : IRepositorio<Clientes>
	{
		private BodegaEntities Contexto;

		public ClientesRepository()
		{
			Contexto = new BodegaEntities();
		}

		public Clientes Entidad { get; set; }

		public bool IsNew { get; set; }

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

		public IEnumerable<Clientes> ListarAllRegistros()
		{
			Contexto = new BodegaEntities();
			return new ReadOnlyCollection<Clientes>(
				Contexto.ListarClientes().ToList());
		}

		public void Crear()
		{
			Entidad = new Clientes();
			IsNew = true;
		}

		public void GetById(string id)
		{
			Entidad = Contexto.Clientes
				.Where(c => c.IdCliente == id).SingleOrDefault();
			IsNew = false;
		}


		///Listar con filtros
		public IEnumerable<Clientes> ListarAllRegistros(int opc, string valor)
		{
			Contexto = new BodegaEntities();
			var Busqueda = new List<Clientes>();

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


	}
}
