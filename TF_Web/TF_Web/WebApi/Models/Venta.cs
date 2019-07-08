using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Venta
    {
        public Venta()
        {
            ListaVenta = new HashSet<ListaVenta>();
        }

        public int Id { get; set; }
        public DateTime? DiaVenta { get; set; }
        public double? Subtotal { get; set; }
        public double? Iva { get; set; }
        public double? Total { get; set; }

        public virtual ICollection<ListaVenta> ListaVenta { get; set; }
    }
}
