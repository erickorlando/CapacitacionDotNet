//------------------------------------------------------------------------------
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
    
    public partial class FacturasComplex
    {
        public string IDFACTURACABECERA { get; set; }
        public string CLIENTE { get; set; }
        public int NUMERO { get; set; }
        public int SERIE { get; set; }
        public System.DateTime FECHA { get; set; }
        public decimal SUBTOTAL { get; set; }
        public decimal IMPUESTOS { get; set; }
        public decimal TOTAL { get; set; }
    }
}