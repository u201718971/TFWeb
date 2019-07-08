using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class ListaVenta
    {
        public int Id { get; set; }
        public int? VentaId { get; set; }
        public int? ProductoId { get; set; }
        public int? Cantidad { get; set; }
        public double? Total { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Venta Venta { get; set; }
    }
}
