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
    public class FacturaRepository : 
        IRepositorioDetalles<FacturaCabecera, FacturaDetalle>,
        IRepositorioLectura<FacturasComplex>
    {

        public FacturaRepository()
        {
            Detalles = new List<FacturaDetalle>();
        }

        public FacturaCabecera Entidad { get; set; }

        public List<FacturaDetalle> Detalles { get; set; }

        public bool IsNew { get; set; }

        public bool Guardar()
        {
            try
            {
                using (var cn = new iDB2Connection(Conexion.CadenaConexion()))
                {
                    cn.Open();
                    using (var trans = cn.BeginTransaction())
                    {
                        using (var cmd = cn.CreateCommand())
                        {
                            cmd.CommandText = "USP_INSERTARFACTURA";
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Transaction = trans;

                            cmd.Parameters.AddWithValue("@IDFACTURACABECERA", Entidad.IdFacturaCabecera);
                            cmd.Parameters.AddWithValue("@IDCLIENTE", Entidad.IdCliente);
                            cmd.Parameters.AddWithValue("@NUMERO", Entidad.Numero);
                            cmd.Parameters.AddWithValue("@SERIE", Entidad.Serie);
                            cmd.Parameters.AddWithValue("@FECHA", 
                                new iDB2Date(Entidad.Fecha));

                            cmd.Parameters.AddWithValue("@SUBTOTAL", Entidad.SubTotal);
                            cmd.Parameters.AddWithValue("@IMPUESTOS", Entidad.IGV);
                            cmd.Parameters.AddWithValue("@TOTAL", Entidad.Total);



                            try
                            {
                                cmd.ExecuteNonQuery();

                                // Aqui hacemos el recorrido de los detalles
                                GuardaDetalles(
                                    new Tuple<iDB2Connection,
                                        iDB2Transaction>(cn, trans));

                                cmd.Transaction.Commit();
                                return true;
                            }
                            catch (iDB2Exception)
                            {
                                cmd.Transaction.Rollback();
                                throw;
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

        public void GetByID(string ID)
        {
            throw new NotImplementedException();
        }

        public List<FacturaCabecera> GetAllRegistros()
        {
            var lista = new List<FacturaCabecera>();
            using (var cn = new iDB2Connection(Conexion.CadenaConexion()))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "USP_LISTARFACTURAS";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cn.Open();

                    return lista;
                }
            }
        }

        public void Dispose()
        {
            Entidad = null;
        }

        private void GuardaDetalles(Tuple<iDB2Connection, iDB2Transaction> parametro)
        {
            foreach (var item in Detalles)
            {
                using (var cmd = parametro.Item1.CreateCommand())
                {
                    cmd.CommandText = "USP_INSERTARDETALLEFACTURA";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Transaction = parametro.Item2;

                    cmd.Parameters.AddWithValue("@IDFACTURADETALLE", Guid.NewGuid().ToString());
                    cmd.Parameters.AddWithValue("@IDFACTURACABECERA", Entidad.IdFacturaCabecera);
                    cmd.Parameters.AddWithValue("@IDPRODUCTO", item.IdProducto);
                    cmd.Parameters.AddWithValue("@CANTIDAD", item.Cantidad);
                    cmd.Parameters.AddWithValue("@PRECIOUNITARIO", item.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@TOTAL", item.Total);

                    cmd.ExecuteNonQuery();
                } 
            }
        }

        public List<FacturasComplex> ListarRegistros()
        {
            var lista = new List<FacturasComplex>();
            using (var cn = new iDB2Connection(Conexion.CadenaConexion()))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "USP_LISTARFACTURAS";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    

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
                                    FECHA = dr.GetiDB2Date(4).Value,
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


        public List<FacturaCabecera> GetRegistros_Filtros(int opc, string valor)
        {
            throw new NotImplementedException();
        }
    }
}
