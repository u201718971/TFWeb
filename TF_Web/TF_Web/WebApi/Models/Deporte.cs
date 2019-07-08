using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Deporte
    {
        public Deporte()
        {
            TipoDePrueba = new HashSet<TipoDePrueba>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<TipoDePrueba> TipoDePrueba { get; set; }
    }
}
