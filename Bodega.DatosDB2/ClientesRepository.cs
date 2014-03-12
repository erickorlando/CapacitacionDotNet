using System;
using System.Collections.Generic;
using System.Linq;
using Bodega.Repositorio;
using Bodega.Entidades;
using IBM.Data.DB2.iSeries;

namespace Bodega.DatosDB2
{
	public class ClientesRepository : IRepositorio<Clientes>
	{

		public ClientesRepository()
		{

		}

		public Clientes Entidad { get; set; }
		public bool IsNew { get; set; }

		public bool Guardar()
		{
			try
			{
				using (var cn = new iDB2Connection(Conexion.CadenaConexion()))
				{
					using (var cmd = cn.CreateCommand())
					{
						cmd.CommandText = IsNew ? "USP_INSERTARCLIENTE" : "USP_ACTUALIZARCLIENTE";
						cmd.CommandType = System.Data.CommandType.StoredProcedure;

						cmd.Parameters.AddWithValue("@IDCLIENTE", Entidad.IdCliente);
						cmd.Parameters.AddWithValue("@NOMBRES", Entidad.Nombres);
						cmd.Parameters.AddWithValue("@APELLIDOS", Entidad.Apellidos);
						cmd.Parameters.AddWithValue("@CORREO", Entidad.Correo);
						cmd.Parameters.AddWithValue("@EDAD", Entidad.Edad);

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
						cmd.CommandText = "USP_ELIMINARCLIENTE";
						cmd.CommandType = System.Data.CommandType.StoredProcedure;

						cmd.Parameters.AddWithValue("@IDCLIENTE", Entidad.IdCliente);
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

		public IEnumerable<Clientes> ListarAllRegistros()
		{
			var lista = new List<Clientes>();
			try
			{
				using (var cn = new iDB2Connection(Conexion.CadenaConexion()))
				{
					using (var cmd = cn.CreateCommand())
					{
						cmd.CommandText = "USP_LISTARCLIENTES";
						cmd.CommandType = System.Data.CommandType.StoredProcedure;

						cn.Open();
						using (var dr = cmd.ExecuteReader())
						{
							while (dr.Read())
							{
								lista.Add(new Clientes
													{
														IdCliente = dr.GetString(0),
														Nombres = dr.GetString(1),
														Apellidos = dr.GetString(2),
														Correo = dr.GetString(3),
														Edad = dr.GetInt32(4)
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
			Entidad = new Clientes();
			Entidad.IdCliente = Guid.NewGuid().ToString();
			IsNew = true;
		}

		public void GetById(string ID)
		{
			using (var cn = new iDB2Connection(Conexion.CadenaConexion()))
			{
				using (var cmd = cn.CreateCommand())
				{
					cmd.CommandText = "USP_LISTARCLIENTES";
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cn.Open();
					using (var dr = cmd.ExecuteReader())
					{
						if (dr.Read())
						{
							Entidad = new Clientes
												{
													IdCliente = dr.GetString(0),
													Nombres = dr.GetString(1),
													Apellidos = dr.GetString(2),
													Correo = dr.GetString(3),
													Edad = dr.GetInt32(4)
												};
						}
					}
				}
			}
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



		// LO ADICIONADO  Busqueda con Filtros.
		public IEnumerable<Clientes> ListarAllRegistros(int opc, string valor)
		{
			var lista = new List<Clientes>();
			string filtro = "";
			if (opc.Equals(1))
			{
				filtro = "WHERE APELLIDOS ='" + valor + "'";
			}
			else if (opc.Equals(2))
			{
				filtro = " WHERE NOMBRES ='" + valor + "'";
			}
			else if (opc.Equals(0))
			{
				filtro = "";
			}
			try
			{
				using (var cn = new iDB2Connection(Conexion.CadenaConexion()))
				{
					cn.Open();
					using (var cmd = cn.CreateCommand())
					{
						cmd.CommandText = "SELECT * FROM Clientes  " + filtro;
						using (var dr = cmd.ExecuteReader())
						{
							while (dr.Read())
							{
								lista.Add(new Clientes
								{
									IdCliente = dr.GetString(0),
									Nombres = dr.GetString(1),
									Apellidos = dr.GetString(2),
									Correo = dr.GetString(3),
									Edad = dr.GetInt32(4)
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


	}
}
