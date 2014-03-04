﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Globalization;
using System.Threading;
using System.Configuration;

namespace Bodega.Windows
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Cambiamos la globalización.
            Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["Cultura"]);

            using (IUnityContainer container = new UnityContainer())
            {
                container.LoadConfiguration();
                Application.Run(new MainForm(container));
            }
        }
    }
}
