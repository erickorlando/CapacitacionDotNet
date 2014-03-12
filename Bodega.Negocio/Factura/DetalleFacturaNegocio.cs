using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodega.Entidades;

namespace Bodega.Negocio
{
	public class DetalleFacturaNegocio : BaseNegocio<FacturaDetalle>
	{

		public string DescripcionProducto { get; set; }
		public string IdProducto { get; set; }

		private int _Cantidad;
		public int Cantidad
		{
			get
			{
				return _Cantidad;
			}
			set
			{
				_Cantidad = value;
				ActualizaTotal();
			}
		}
		private decimal _PrecioUnitario;
		public decimal PrecioUnitario
		{
			get
			{ return _PrecioUnitario; }

			set
			{
				_PrecioUnitario = value;
				ActualizaTotal();
			}
		}

		private decimal _total;
		public decimal Total
		{
			get
			{
				return _total;
			}
		}

		public void ActualizaTotal()
		{
			_total = _Cantidad * _PrecioUnitario;
			RaisePropertyChanged("Total");
			DetalleChangedEvent(this, EventArgs.Empty);
		}

		public event EventHandler DetalleChangedEvent = delegate { };
	}
}
