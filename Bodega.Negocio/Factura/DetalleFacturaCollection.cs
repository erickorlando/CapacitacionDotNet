using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodega.Negocio
{
	public class DetalleFacturaCollection : ObservableCollection<DetalleFacturaNegocio>
	{
		protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			base.OnCollectionChanged(e);
			foreach (var item in this)
			{
				item.DetalleChangedEvent += (s, g) =>
					{
						CantidadesEvent(this, new CalculaMontosEventArgs(item.Total));
					};
			}
		}

		public new void Add(DetalleFacturaNegocio item)
		{
			CantidadesEvent(this, new CalculaMontosEventArgs(item.Total));
			base.Add(item);
		}
		public event EventHandler<CalculaMontosEventArgs> CantidadesEvent = delegate { };
	}

	public class CalculaMontosEventArgs : EventArgs
	{
		public decimal Total { get; set; }

		public CalculaMontosEventArgs(decimal total)
		{
			Total = total;
		}
	}
}
