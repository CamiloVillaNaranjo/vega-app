using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega.Models;

namespace vega.Persistence
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicleAsync(int id);
        void Add(Vehicle vehicle);
        void Remove(Vehicle vehicle);
    }
}
