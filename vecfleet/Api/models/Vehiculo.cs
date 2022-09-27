using System;
using System.Collections.Generic;

namespace Api.models
{
    public partial class Vehiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; } = null!;
        public int CantidadRuedas { get; set; }
        public string Modelo { get; set; } = null!;
        public string Patente { get; set; } = null!;
        public string Chasis { get; set; } = null!;
        public long KmsRecorrido { get; set; }
        public long KmsProximoMantenimiento { get; set; }
        public int Anio { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdTipoVehiculo { get; set; }
    }
}
