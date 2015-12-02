using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodega.Entidades;
using Bodega.Repositorio;

namespace Bodega.Negocio
{
	public class FacturaNegocio : 
		BaseNegocioDetalles<FacturaCabecera, FacturaDetalle>
	{
		public FacturaNegocio(IRepositorioDetalles<FacturaCabecera, FacturaDetalle> repositorio)
		{
			Repositorio = repositorio;
			Detalles = new DetalleFacturaCollection();
			Detalles.CantidadesEvent += CalculaTotales;
			Fecha = DateTime.Today;
		}

		public string Cliente { get; set; }
		public DateTime Fecha { get; set; }
		public decimal SubTotal { get; set; }
		public decimal Impuestos { get; set; }
		public decimal Total { get; set; }
		public DetalleFacturaCollection Detalles { get; set; }

		
		public override bool Guardar()
		{
			Repositorio.Entidad.IdCliente = Cliente;
			Repositorio.Entidad.Fecha = Fecha;
			Repositorio.Entidad.SubTotal = SubTotal;
			Repositorio.Entidad.IGV = Impuestos;
			Repositorio.Entidad.Total = Total;

			var listaDetalles = new List<FacturaDetalle>();
			foreach (var item in Detalles)
			{
				listaDetalles.Add(new FacturaDetalle
					{
						IdProducto = item.IdProducto,
						Cantidad = item.Cantidad,
						PrecioUnitario = item.PrecioUnitario,
						Total = item.Total
					});
			}
			Repositorio.Detalles = listaDetalles;
			return Repositorio.Guardar();
		}

		public void CalculaTotales(object sender, CalculaMontosEventArgs e)
		{
			SubTotal = e.Total;
			Impuestos = SubTotal * Convert.ToDecimal(0.18);
			Total = Impuestos + SubTotal;
		}

		public IEnumerable<FacturasComplex> ListarRegistros()
		{
			var repo = Repositorio as IRepositorioLectura<FacturasComplex>;
			return repo.ListarRegistros();
		}
	}
}
