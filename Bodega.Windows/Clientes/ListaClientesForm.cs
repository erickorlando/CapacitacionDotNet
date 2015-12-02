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
    public partial class ListaClientesForm : PlantillaLista
    {
        private IUnityContainer container;
        private ClienteNegocio target;

        public ListaClientesForm()
        {
            InitializeComponent();

        }

        public ListaClientesForm(IUnityContainer _container)
        {
            container = _container;
            target = container.Resolve<ClienteNegocio>();
            InitializeComponent();
        }

        private void ListaClientesForm_Load(object sender, EventArgs e)
        {
            try
            {
                Listar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void Listar()
        {
            clientesBindingSource.DataSource = target.ListarClientes();
            clientesBindingSource.ResetBindings(false);
        }

        public override void Nuevo()
        {
            using (var frm = new ClientesForm(container, new Entidades.Clientes()))
            {
                frm.IsNew = true;
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    Listar();
            }
        }

        public override void Editar()
        {
            var seleccionado = clientesBindingSource.Current as Clientes;
            using (var frm = new ClientesForm(container, seleccionado))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    Listar();
            }
        }

        public override void Eliminar()
        {
            var seleccionado = clientesBindingSource.Current as Clientes;
            if (seleccionado == null)
                return;

            if (MessageBox
                .Show("Esta seguro que desea eliminar el registro?",
                "Confirme",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;

            target.GetByID(seleccionado.IdCliente);
            if (target.Eliminar())
                Listar();
        }

        public override void Buscar()
        {
            Listar();
        }



        // LO ADICIONADO  Busqueda con Filtros.
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Aplicar_filtros();
        }
        public void Aplicar_filtros()
        {
            int opc = 0;
            if (rdnApellidos.Checked == true)
            {
                rbnNombres.Checked = false;
                rbnTodos.Checked = false;
                opc = 1;
            }
            else if (rbnNombres.Checked == true)
            {
                rdnApellidos.Checked = false;
                rbnTodos.Checked = false;
                opc = 2;
            }
            else if (rbnTodos.Checked == true)
            {
                txtFiltro.Text = "";
                rdnApellidos.Checked = false;
                rbnNombres.Checked = false;
                opc = 0;

            }

            clientesBindingSource.DataSource = target.Listar_Busqueda(opc, txtFiltro.Text);
            clientesBindingSource.ResetBindings(false);
        }
    }
}
