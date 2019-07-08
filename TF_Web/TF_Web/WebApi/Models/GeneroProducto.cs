using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class GeneroProducto
    {
        public GeneroProducto()
        {
            Producto = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
