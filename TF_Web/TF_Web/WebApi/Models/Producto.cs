using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Producto
    {
        public Producto()
        {
            ListaVenta = new HashSet<ListaVenta>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public double? Precio { get; set; }
        public string Foto { get; set; }
        public int? TipoProductoId { get; set; }
        public int? GeneroId { get; set; }
        public double? Talla { get; set; }
        public int? Stock { get; set; }

        public virtual GeneroProducto Genero { get; set; }
        public virtual TipoProducto TipoProducto { get; set; }
        public virtual ICollection<ListaVenta> ListaVenta { get; set; }
    }
}
