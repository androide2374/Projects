using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class TipoVehiculo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }
    }
}
