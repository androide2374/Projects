using System;
using System.Collections.Generic;

namespace Api.models
{
    public partial class TipoVehiculo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }
    }
}
