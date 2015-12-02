using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bodega.Plantillas
{
    public partial class PlantillaLista : PlantillaBase
    {
        public PlantillaLista()
        {
            InitializeComponent();
            toolNuevo.Click += (s, e) => Nuevo();
            toolEditar.Click += (s, e) => Editar();
            toolEliminar.Click += (s, e) => Eliminar();
            toolBuscar.Click += (s, e) => Buscar();
        }

        public virtual void Nuevo()
        {

        }

        public virtual  void Editar()
        {

        }

        public virtual void Eliminar()
        {

        }

        public virtual void Buscar()
        {

        }
    }
}
