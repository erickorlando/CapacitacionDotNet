﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bodega.Entidades
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class BodegaEntities : DbContext
    {
        public BodegaEntities()
            : base("name=BodegaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<FacturaCabecera> FacturaCabecera { get; set; }
        public DbSet<FacturaDetalle> FacturaDetalle { get; set; }
        public DbSet<Producto> Producto { get; set; }
    
        public virtual int usp_ActualizarCliente(string idCliente, string nombres, string apellidos, string correo, Nullable<int> edad)
        {
            var idClienteParameter = idCliente != null ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(string));
    
            var nombresParameter = nombres != null ?
                new ObjectParameter("Nombres", nombres) :
                new ObjectParameter("Nombres", typeof(string));
    
            var apellidosParameter = apellidos != null ?
                new ObjectParameter("Apellidos", apellidos) :
                new ObjectParameter("Apellidos", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var edadParameter = edad.HasValue ?
                new ObjectParameter("Edad", edad) :
                new ObjectParameter("Edad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_ActualizarCliente", idClienteParameter, nombresParameter, apellidosParameter, correoParameter, edadParameter);
        }
    
        public virtual int usp_EliminarCliente(string idCliente)
        {
            var idClienteParameter = idCliente != null ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_EliminarCliente", idClienteParameter);
        }
    
        public virtual ObjectResult<Clientes> GetClienteByID(string idCliente)
        {
            var idClienteParameter = idCliente != null ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Clientes>("GetClienteByID", idClienteParameter);
        }
    
        public virtual ObjectResult<Clientes> GetClienteByID(string idCliente, MergeOption mergeOption)
        {
            var idClienteParameter = idCliente != null ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Clientes>("GetClienteByID", mergeOption, idClienteParameter);
        }
    
        public virtual int usp_InsertarCliente(string idCliente, string nombres, string apellidos, string correo, Nullable<int> edad)
        {
            var idClienteParameter = idCliente != null ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(string));
    
            var nombresParameter = nombres != null ?
                new ObjectParameter("Nombres", nombres) :
                new ObjectParameter("Nombres", typeof(string));
    
            var apellidosParameter = apellidos != null ?
                new ObjectParameter("Apellidos", apellidos) :
                new ObjectParameter("Apellidos", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var edadParameter = edad.HasValue ?
                new ObjectParameter("Edad", edad) :
                new ObjectParameter("Edad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_InsertarCliente", idClienteParameter, nombresParameter, apellidosParameter, correoParameter, edadParameter);
        }
    
        public virtual ObjectResult<Clientes> ListarClientes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Clientes>("ListarClientes");
        }
    
        public virtual ObjectResult<Clientes> ListarClientes(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Clientes>("ListarClientes", mergeOption);
        }
    
        public virtual ObjectResult<FacturasComplex> ListarFacturas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FacturasComplex>("ListarFacturas");
        }
    
        public virtual ObjectResult<Producto> ListarProductos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Producto>("ListarProductos");
        }
    
        public virtual ObjectResult<Producto> ListarProductos(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Producto>("ListarProductos", mergeOption);
        }
    }
}