using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bodega.Entidades;
using Bodega.Negocio;
using Bodega.Plantillas;
using Microsoft.Practices.Unity;

namespace Bodega.Windows
{
    public partial class ClientesForm : PlantillaMantenimiento
    {
        private IUnityContainer container;
        private ClienteNegocio target;

        public ClientesForm()
        {
            InitializeComponent();
        }

        public ClientesForm(IUnityContainer _container, Clientes entidad)
        {
            InitializeComponent();

            container = _container;
            Entidad = entidad;

            this.Load += (s, e) =>
                {
                    target = container.Resolve<ClienteNegocio>();
                    if (IsNew)
                    {
                        target.Crear();
                        Entidad = target.Repositorio.Entidad;
                    }
                    else
                    {
                        target.GetByID(Entidad.IdCliente);
                        Entidad = target.Repositorio.Entidad;
                    }

                    clientesBindingSource.DataSource = Entidad;
                    clientesBindingSource.ResetBindings(false);

                };
        }

        public bool IsNew { get; set; }
        public Clientes Entidad { get; set; }

        protected override void Cancelar()
        {
            clientesBindingSource.CancelEdit();
            base.Cancelar();
        }

        protected override void Guardar()
        {
            clientesBindingSource.EndEdit();
            target.Repositorio.Entidad = Entidad;

            if (target.Guardar())
                base.Guardar();
            else
                base.Cancelar();
        }
    }
}
