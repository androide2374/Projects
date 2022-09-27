using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application
{
    public interface IVehiculos
    {
        Task<IEnumerable<Vehiculo>> GetListadoVehiculos(int? size, int? page);
    }
}

