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
    public partial class PlantillaMantenimiento : PlantillaBase
    {
        public PlantillaMantenimiento()
        {
            InitializeComponent();
            toolGuardar.Click += (s, e) => Guardar();
            toolCancelar.Click += (s, e) => Cancelar();
        }

        protected virtual void Guardar()
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected virtual void Cancelar()
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
