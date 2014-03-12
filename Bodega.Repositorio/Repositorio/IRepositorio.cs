using System;
using System.Collections.Generic;

namespace Bodega.Repositorio
{
	public interface IRepositorio<TEntity> : IDisposable
		where TEntity : class
	{

		TEntity Entidad { get; set; }

		bool IsNew { get; set; }

		bool Guardar();

		bool Eliminar();

		void Crear();

		void GetById(string id);

		IEnumerable<TEntity> ListarAllRegistros();

		IEnumerable<TEntity> ListarAllRegistros(int opc, String valor);


	}
}
