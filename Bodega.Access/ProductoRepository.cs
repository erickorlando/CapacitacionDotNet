using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using Bodega.Entidades;
using Bodega.Repositorio;

namespace Bodega.Access
{
	public class ProductoRepository : IRepositorio<Producto>
	{

		public Producto Entidad { get; set; }

		public bool IsNew { get; set; }

		public bool Guardar()
		{
			try
			{
				using (var cn = new OleDbConnection(Conexion.CadenaConexion()))
				{
					using (var cmd = cn.CreateCommand())
					{
						cmd.CommandText = IsNew ?
							Properties.Resources.usp_InsertarProductos
							: Properties.Resources.usp_ActualizarProductos;
						cmd.Parameters.AddWithValue("@IdProducto", Entidad.IdProducto);
						cmd.Parameters.AddWithValue("@Codigo", Entidad.Codigo);
						cmd.Parameters.AddWithValue("@Descripcion", Entidad.Descripcion);
						cmd.Parameters.AddWithValue("@PrecioUnitario", Entidad.PrecioUnitario);
						cn.Open();
						var result = cmd.ExecuteNonQuery();
						return result > 0;
					}
				}
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool Eliminar()
		{
			using (var cn = new OleDbConnection(Conexion.CadenaConexion()))
			{
				using (var cmd = cn.CreateCommand())
				{
					cmd.CommandText = Properties.Resources.usp_EliminarProductos;
					cmd.Parameters.AddWithValue("@IdProducto", Entidad.IdProducto);
					cn.Open();
					var result = cmd.ExecuteNonQuery();
					return result > 0;
				}
			}
		}

		public void Crear()
		{
			Entidad = new Producto();
			Entidad.IdProducto = Guid.NewGuid().ToString();
			IsNew = true;
		}

		public void GetById(string ID)
		{
			using (var cn = new OleDbConnection(Conexion.CadenaConexion()))
			{
				using (var cmd = cn.CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM Producto WHERE IdProducto = @IdProducto";
					cmd.Parameters.AddWithValue("@IdProducto", ID);
					cn.Open();
					using (var dr = cmd.ExecuteReader())
					{
						if (dr.Read())
						{
							Entidad = new Producto
							{
								IdProducto = dr.GetString(0),
								Codigo = dr.GetInt32(1),
								Descripcion = dr.GetString(2),
								PrecioUnitario = dr.GetDecimal(3)
							};
							IsNew = false;
						}
					}
				}
			}
		}

		public IEnumerable<Producto> ListarAllRegistros()
		{
			var lista = new List<Producto>();
			using (var cn = new OleDbConnection(Conexion.CadenaConexion()))
			{
				using (var cmd = cn.CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM Producto";
					cn.Open();
					using (var dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							lista.Add(new Producto
							{
								IdProducto = dr.GetString(0),
								Codigo = dr.GetInt32(1),
								Descripcion = dr.GetString(2),
								PrecioUnitario = dr.GetDecimal(3)
							});
						}
					}
				}
			}
			return lista;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{ }
		}

		public IEnumerable<Producto> ListarAllRegistros(int opc, string valor)
		{
			throw new NotImplementedException();
		}
	}
}
