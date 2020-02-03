using System.Threading.Tasks;
using vega.Models;

namespace vega.Persistence
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly VegaDbContext context;

        public FeatureRepository(VegaDbContext context)
        {
            this.context = context;
        }
        public async Task<Model> GetModelAsync(int id)
        {
            return await context.Models.FindAsync(id);
        }
    }
}
