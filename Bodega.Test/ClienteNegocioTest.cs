using Bodega.Negocio;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bodega.Test
{
    [TestClass]
    public class ClienteNegocioTest
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
        public void ListarClientesTest()
        {
            // La prueba de integración comprobará que
            // se ejecuta la sentencia SQL.
            using (var target = container.Resolve<ClienteNegocio>() )
            {
                var result = target.ListarClientes();

                Assert.AreEqual(result.Count > 0, true);
            }
        }

        [TestMethod]
        public void InsertarClienteTest()
        {
            using (var target = container.Resolve<ClienteNegocio>())
            {
                target.Crear();

                var cliente = target.Repositorio.Entidad;
                IDGenerado = cliente.IdCliente;

                cliente.Nombres = "Rodolfo";
                cliente.Apellidos = "Vargas";
                cliente.Correo = "rodo@gromero.com.pe";
                cliente.Edad = 26;

                var result = target.Guardar();

                Assert.AreEqual(result, true);
            }
        }

        [TestMethod]
        public void ActualizarClienteTest()
        {
            using (var target = container.Resolve<ClienteNegocio>())
            {
                target.GetByID(IDGenerado);

                var cliente = target.Repositorio.Entidad;

                cliente.Nombres = "Rodolfo";
                cliente.Apellidos = "Ortiz";
                cliente.Correo = "rodo.ortiz@gmail.com";

                bool result = target.Guardar();

                Assert.AreEqual(result, true);
            }
        }

        [TestMethod]
        public void EliminarClienteTest()
        {
            using (var target = container.Resolve<ClienteNegocio>())
            {
                target.GetByID(IDGenerado);

                var result = target.Eliminar();

                Assert.AreEqual(result, true);
            }
        }

        [TestMethod]
        public void Listar_Filtros()
        {
            using (var target=container.Resolve<ClienteNegocio>())
            {
                var result = target.Listar_Busqueda(0, "Pizarro");
                Assert.AreEqual(result.Count > 0, true);
            }
        
        }
    }
}
