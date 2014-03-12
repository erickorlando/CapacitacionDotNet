using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodega.Repositorio;
using Bodega.Entidades;
using IBM.Data.DB2.iSeries;

namespace Bodega.DatosDB2
{
	public class ProductoRepository : IRepositorio<Producto>
	{

		public ProductoRepository()
		{
			
		}

		public Producto Entidad { get; set; }

		public bool IsNew { get; set; }

		public bool Guardar()
		{
			try
			{
				using (var cn = new iDB2Connection(Conexion.CadenaConexion()))
				{
					using (var cmd = cn.CreateCommand())
					{
						cmd.CommandText = IsNew ? "USP_INSERTARPRODUCTO" : "USP_ACTUALIZARPRODUCTO";
						cmd.CommandType = System.Data.CommandType.StoredProcedure;

						cmd.Parameters.AddWithValue("@IDPRODUCTO", Entidad.IdProducto);
						cmd.Parameters.AddWithValue("@CODIGO", Entidad.Codigo);
						cmd.Parameters.AddWithValue("@DESCRIPCION", Entidad.Descripcion);
						cmd.Parameters.AddWithValue("@PRECIOUNITARIO", Entidad.PrecioUnitario);

						cn.Open();

						cmd.ExecuteNonQuery();

						return true;
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
			try
			{
				if (IsNew)
					throw new InvalidOperationException("Un registro nuevo no se puede eliminar");

				using (var cn = new iDB2Connection(Conexion.CadenaConexion()))
				{
					using (var cmd = cn.CreateCommand())
					{
						cmd.CommandText = "USP_ELIMINARPRODUCTO";
						cmd.CommandType = System.Data.CommandType.StoredProcedure;

						cmd.Parameters.AddWithValue("@IDPRODUCTO", Entidad.IdProducto);

						cn.Open();

						cmd.ExecuteNonQuery();

						return true;
					}
				}
			}
			catch (Exception)
			{
				return false;
			}

		}

		public IEnumerable<Producto> ListarAllRegistros()
		{
			var lista = new List<Producto>();
			try
			{
				using (var cn = new iDB2Connection(Conexion.CadenaConexion()))
				{
					using (var cmd = cn.CreateCommand())
					{
						cmd.CommandText = "USP_LISTARPRODUCTOS";
						cmd.CommandType = System.Data.CommandType.StoredProcedure;

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

						return lista;
					}
				}
			}
			catch (Exception)
			{
				return lista;
			}
		}

		public void Crear()
		{
			Entidad = new Producto();
			Entidad.IdProducto = Guid.NewGuid().ToString();
			IsNew = true;
		}

		public void GetById(string id)
		{
			using (var cn = new iDB2Connection(Conexion.CadenaConexion()))
			{
				using (var cmd = cn.CreateCommand())
				{
					cmd.CommandText = "USP_GETPRODUCTOBYID";
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@IDPRODUCTO", id);
					cn.Open();

					using (var dr = cmd.ExecuteReader())
					{
						if (dr.Read())
						{
							Entidad = new Producto();
							Entidad.IdProducto = dr.GetString(0);
							Entidad.Codigo = dr.GetInt32(1);
							Entidad.Descripcion = dr.GetString(2);
							Entidad.PrecioUnitario = dr.GetDecimal(3);
						}
					}
				}
			}
			IsNew = false;
		}

		
		public void GetByCodigo(int Codigo)
		{
			try
			{
				using (var cn = new iDB2Connection(Conexion.CadenaConexion()))
				{
					using (var cmd = cn.CreateCommand())
					{
						cmd.CommandText = "USP_GETPRODUCTOBYID";
						cmd.CommandType = System.Data.CommandType.StoredProcedure;

						cmd.Parameters.AddWithValue("@IDPRODUCTO", Entidad.IdProducto);

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
							}
						}
					}
				}
			}
			catch (Exception)
			{
			}
			IsNew = false;
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
				Entidad = null;
			}
		}
		public IEnumerable<Producto> ListarAllRegistros(int opc, string valor)
		{
			throw new NotImplementedException();
		}
	}
}
