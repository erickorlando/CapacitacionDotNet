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
    public class FacturaRepository : 
        IRepositorioDetalles<FacturaCabecera, FacturaDetalle>,
        IRepositorioLectura<FacturasComplex>
    {
        public IEnumerable<FacturaDetalle> Detalles { get; set; }
        public FacturaCabecera Entidad { get; set; }
        public bool IsNew { get; set; }


        public FacturaRepository()
        {
            Detalles = new List<FacturaDetalle>();
        }

        public bool Guardar()
        {
            try
            {
                using (var con = new OleDbConnection(Conexion.CadenaConexion()))
                {
                    con.Open();
                    using (var tran = con.BeginTransaction())
                    {
                        using (var cmd = con.CreateCommand())
                        {
                            cmd.CommandText = Properties.Resources.usp_InsertarFactura;
                            cmd.Transaction = tran;

                            cmd.Parameters.AddWithValue("@IdFacturaCabecera", Entidad.IdFacturaCabecera);
                            cmd.Parameters.AddWithValue("@IdCliente", Entidad.IdCliente);
                            cmd.Parameters.AddWithValue("@Numero", Entidad.Numero);
                            cmd.Parameters.AddWithValue("@Serie", Entidad.Serie);
                            cmd.Parameters.AddWithValue("@Fecha", Entidad.Fecha);
                            cmd.Parameters.AddWithValue("@SubTotal", Entidad.SubTotal);
                            cmd.Parameters.AddWithValue("@Impuestos", Entidad.IGV);
                            cmd.Parameters.AddWithValue("@Total", Entidad.Total);

                            try
                            {
                                cmd.ExecuteNonQuery();
                                GuardaDetalles(new Tuple<OleDbConnection, OleDbTransaction>(con, tran));
                                cmd.Transaction.Commit();
                                return true;
                            }
                            catch (Exception)
                            {
                                cmd.Transaction.Rollback();
                                return false;
                            }
                        }
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
            throw new NotImplementedException();
        }

        public void Crear()
        {
            Entidad = new FacturaCabecera();
            Entidad.IdFacturaCabecera = Guid.NewGuid().ToString();
            Entidad.Numero = 10003;
            Entidad.Serie = 1;
            Entidad.Fecha = DateTime.Today;
            Detalles = new List<FacturaDetalle>();
            IsNew = true;
        }

        public void GetById(string ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FacturaCabecera> ListarAllRegistros()
        {
            //var lista = new List<FacturaCabecera>();
            //using (var cn = new OleDbConnection (Conexion.CadenaConexion()))
            //{
            //    using (var cmd = cn.CreateCommand())
            //    {
            //        cmd.CommandText = Properties.Resources.usp_ListarFacturas;
            //        cn.Open();
            //        return lista;
            //    }
            //}
            throw new NotImplementedException();
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

        public IEnumerable<FacturasComplex> ListarRegistros()
        {
            var lista = new List<FacturasComplex>();
            using (var cn = new OleDbConnection(Conexion.CadenaConexion()))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = Properties.Resources.usp_ListarFacturas;

                    cn.Open();

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new FacturasComplex
                            {
                                IDFACTURACABECERA = dr.GetString(0),
                                CLIENTE = dr.GetString(1),
                                NUMERO = dr.GetInt32(2),
                                SERIE = dr.GetInt32(3),
                                FECHA = dr.GetDateTime(4),
                                SUBTOTAL = dr.GetDecimal(5),
                                IMPUESTOS = dr.GetDecimal(6),
                                TOTAL = dr.GetDecimal(7)
                            });
                        }
                    }
                }
            }
            return lista;
        }

        private void GuardaDetalles(Tuple<OleDbConnection,OleDbTransaction> parametro)
        {
            foreach (var item in Detalles)
            {
                using (var cmd = parametro.Item1.CreateCommand())
                {
                    cmd.CommandText = Properties.Resources.usp_InsertarDetalleFactura;
                    cmd.Transaction = parametro.Item2;

                    cmd.Parameters.AddWithValue("@IdFacturaDetalle", Guid.NewGuid().ToString());
                    cmd.Parameters.AddWithValue("@IdFacturaCabecera", Entidad.IdFacturaCabecera);
                    cmd.Parameters.AddWithValue("@IdProducto", item.IdProducto);
                    cmd.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", item.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@Total", item.Total);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<FacturaCabecera> ListarAllRegistros(int opc, string valor)
        {
            throw new NotImplementedException();
        }
    }
}
