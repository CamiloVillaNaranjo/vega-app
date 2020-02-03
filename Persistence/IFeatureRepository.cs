using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega.Models;

namespace vega.Persistence
{
    public interface IFeatureRepository
    {
        Task<Model> GetModelAsync(int id);
    }
}
