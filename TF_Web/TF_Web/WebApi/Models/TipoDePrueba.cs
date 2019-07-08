using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class TipoDePrueba
    {
        public TipoDePrueba()
        {
            TipoProducto = new HashSet<TipoProducto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? DeporteId { get; set; }

        public virtual Deporte Deporte { get; set; }
        public virtual ICollection<TipoProducto> TipoProducto { get; set; }
    }
}
