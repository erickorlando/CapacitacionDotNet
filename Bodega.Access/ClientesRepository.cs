using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodega.Entidades;
using Bodega.Repositorio;

namespace Bodega.Access
{
	public class ClientesRepository : IRepositorio<Clientes>
	{
		public Clientes Entidad { get; set; }
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
							Properties.Resources.usp_InsertarClientes
							: Properties.Resources.usp_ActualizarClientes;
						cmd.Parameters.AddWithValue("@IdCliente", Entidad.IdCliente);
						cmd.Parameters.AddWithValue("@Nombres", Entidad.Nombres);
						cmd.Parameters.AddWithValue("@Apellidos", Entidad.Apellidos);
						cmd.Parameters.AddWithValue("@Correo", Entidad.Correo);
						cmd.Parameters.AddWithValue("@Edad", Entidad.Edad);
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
					cmd.CommandText = "DELETE FROM CLIENTES WHERE IdCliente = @IdCliente";
					cmd.Parameters.AddWithValue("@IdCliente", Entidad.IdCliente);
					cn.Open();
					var result = cmd.ExecuteNonQuery();
					return result > 0;
				}
			}
		}

		public void Crear()
		{
			Entidad = new Clientes();
			Entidad.IdCliente = Guid.NewGuid().ToString();
			IsNew = true;
		}

		public void GetByID(string ID)
		{
			using (var cn = new OleDbConnection(Conexion.CadenaConexion()))
			{
				using (var cmd = cn.CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM Clientes WHERE IdCliente = @IdCliente";
					cmd.Parameters.AddWithValue("@IdCliente", ID);
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
							IsNew = false;
						}
					}
				}
			}
		}

		public List<Clientes> GetAllRegistros()
		{
			var lista = new List<Clientes>();
			using (var cn = new OleDbConnection(Conexion.CadenaConexion()))
			{
				using (var cmd = cn.CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM Clientes";
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


		public List<Clientes> GetRegistros_Filtros(int opc, string valor)
		{
			throw new NotImplementedException();
		}
	}
}
