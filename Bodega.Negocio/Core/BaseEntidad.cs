using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodega.Negocio
{
    public abstract class BaseEntidad : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void RaisePropertyChanged(string nombrePropiedad)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}
