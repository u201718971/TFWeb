using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class TipoProducto
    {
        public TipoProducto()
        {
            Producto = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? TipoDePruebaId { get; set; }

        public virtual TipoDePrueba TipoDePrueba { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
