using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Bodega.WebForms
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
			ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.WebForms;
			ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
			{
				Path = "/Scripts/jquery-2.1.0.js"
			});
		}

		protected void Session_Start(object sender, EventArgs e)
		{
			IUnityContainer unity = new UnityContainer();
			unity.LoadConfiguration();
			Session["Container"] = unity;
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{
			Session["Container"] = null;
		}

		protected void Application_End(object sender, EventArgs e)
		{

		}
	}
}