using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TipoVehiculo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }
        
        //public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
