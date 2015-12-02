using System;
using System.Linq;
using Bodega.Negocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Bodega.Test
{
    [TestClass]
    public class ProductoNegocioTest
    {
        private IUnityContainer container;
        private string IDGenerado;

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
        public void ListarProductosTest()
        {
            // La prueba de integración comprobará que
            // se ejecuta la sentencia SQL.
            using (var target = container.Resolve<ProductoNegocio>())
            {
                var result = target.Listar().ToList();

                Assert.AreEqual(result.Count() > 0, true);
            }
        }

        [TestMethod]
        public void InsertarProductoTest()
        {
            using (var target = container.Resolve<ProductoNegocio>())
            {
                target.Crear();

                var Producto = target.EntidadProducto;

                IDGenerado = Producto.IdProducto;

                Producto.Descripcion = "Impresora";
                Producto.PrecioUnitario = Convert.ToDecimal(332.29);

                var result = target.Guardar();

                Assert.AreEqual(result, true);
            }
        }

        [TestMethod]
        public void ActualizarProductoTest()
        {
            using (var target = container.Resolve<ProductoNegocio>())
            {
                target.GetByID(IDGenerado);

                var Producto = target.EntidadProducto;

                Producto.Descripcion = "Lectora de CD";
                Producto.PrecioUnitario = 18;

                bool result = target.Guardar();

                Assert.AreEqual(result, true);
            }
        }

        [TestMethod]
        public void EliminarProductoTest()
        {
            using (var target = container.Resolve<ProductoNegocio>())
            {
                target.GetByID(IDGenerado);

                var result = target.Eliminar();

                Assert.AreEqual(result, true);
            }
        }
    }
}
