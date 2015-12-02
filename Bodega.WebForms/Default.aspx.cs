using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bodega.Negocio;
using Microsoft.Practices.Unity;

namespace Bodega.WebForms
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadData();
            }

        }

        private void LoadData()
        {
            var container = Session["Container"] as IUnityContainer;

            var target = container.Resolve<FacturaNegocio>();

            gdvFacturas.DataSource = target.ListarRegistros();
            gdvFacturas.DataBind();
        }
    }
}