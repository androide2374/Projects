using System;
using AutoMapper;
using Entities.Models;

namespace Api.Models
{
    public class VehiculoProfile:Profile
    {
        public VehiculoProfile()
        {
            CreateMap<VehiculoRequest, Vehiculo>();
        }
    }
}

