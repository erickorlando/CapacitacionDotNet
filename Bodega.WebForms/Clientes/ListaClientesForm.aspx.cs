using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bodega.Negocio;
using Microsoft.Practices.Unity;

namespace Bodega.WebForms.Clientes
{
    public partial class ListaClientesForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }

            barra.BotonNuevo += () => Response.Redirect("ClientesForm.aspx");
            barra.BotonEditar += () =>
                {
                    //TODO: Implementar el boton Editar
                };
            barra.BotonEliminar += () =>
                {
                    //TODO: Implementar el boton Eliminar
                };
            barra.BotonBuscar += () => LoadData();
        }

        public void LoadData()
        {
            var container = Session["Container"] as IUnityContainer;
            using (var target = container.Resolve<ClienteNegocio>())
            {
                gdvClientes.DataSource = target.ListarClientes();
                gdvClientes.DataBind();
            }
        }
    }
}