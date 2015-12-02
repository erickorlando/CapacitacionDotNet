using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodega.Repositorio;

namespace Bodega.Negocio
{
	public abstract class BaseNegocio<TEntity> : BaseEntidad, IDisposable
		where TEntity : class
	{
		protected IRepositorio<TEntity> Repositorio;

		public virtual IEnumerable<TEntity> Listar()
		{
			return Repositorio.ListarAllRegistros();
		}

		public virtual void Crear()
		{
			Repositorio.Crear();
		}

		public virtual void GetByID(string ID)
		{
			Repositorio.GetById(ID);
		}

		public virtual bool Guardar()
		{
			return Repositorio.Guardar();
		}

		public virtual bool Eliminar()
		{
			return Repositorio.Eliminar();
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
		
	}
}
