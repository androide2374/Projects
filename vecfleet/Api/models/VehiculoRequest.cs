using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class VehiculoRequest
    {
        [Required]
        public string Marca { get; set; } = null!;
        [Required]
        public int CantidadRuedas { get; set; }
        [Required]
        public string Modelo { get; set; } = null!;
        [Required]
        public string Patente { get; set; } = null!;
        [Required]
        public string Chasis { get; set; } = null!;
        [Required]
        public long KmsRecorrido { get; set; }
        [Required]
        public long KmsProximoMantenimiento { get; set; }
        [Required]
        public int Anio { get; set; }
        [Required]
        public int IdTipoVehiculo { get; set; }
    }
}

