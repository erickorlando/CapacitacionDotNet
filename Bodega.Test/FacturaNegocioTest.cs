using System;
using System.Linq;
using Bodega.Negocio;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bodega.Test
{
    [TestClass]
    public class FacturaNegocioTest
    {
        private IUnityContainer container;

        [TestInitialize]
        public void Inicializar()
        {
            container = new UnityContainer();
            //container.RegisterType<IRepositorio<Clientes>, ClientesRepository>();
            container.LoadConfiguration();
        }

        [TestCleanup]
        public void Terminar()
        {
            container = null;
        }

        [TestMethod]
        public void ListarFacturasTest()
        {
            using (var target = container.Resolve<FacturaNegocio>())
            {
                var result = target.Listar().ToList();

                Assert.AreEqual(result.Count() == 0, true);
            }
        }

        [TestMethod]
        public void InsertarFacturasTest()
        {
            using (var target = container.Resolve<FacturaNegocio>())
            {
                target.Crear();
                target.Cliente = "3ea75341-b919-4638-88d8-4d55a3e46aec";
                target.Fecha = DateTime.Now;
                target.Detalles.Add(new DetalleFacturaNegocio
                    {
                        IdProducto = "54514f66-ffbe-4d80-ba70-efbc0ef3142a",
                        PrecioUnitario = Convert.ToDecimal(244.6),
                        Cantidad = 42
                    });
                target.Detalles.Add(new DetalleFacturaNegocio
                    {
                        IdProducto = "3f69c012-ccd6-463f-b7bf-bac00d34849e",
                        PrecioUnitario = Convert.ToDecimal(1435.3),
                        Cantidad = 65
                    });
                var result = target.Guardar();
                Assert.AreEqual(result, true);
            }
        }
    }
}
