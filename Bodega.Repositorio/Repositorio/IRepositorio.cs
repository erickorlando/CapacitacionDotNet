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

        void GetByID(string ID);

        List<TEntity> GetAllRegistros();

        List<TEntity> GetRegistros_Filtros(int opc, String valor);


    }
}
