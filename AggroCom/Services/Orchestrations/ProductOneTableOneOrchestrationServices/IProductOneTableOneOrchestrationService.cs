using AggroCom.Models.Orchestrations;
using System.Linq;
using System.Threading.Tasks;

namespace AggroCom.Services.Orchestrations.ProductOneTableOneOrchestrationServices
{
    public interface IProductOneTableOneOrchestrationService
    {
        ValueTask<IQueryable<ProductOneTableOne>> RetrieveProductOnesHerbicidesWithTableOnesAsync();
        ValueTask<IQueryable<ProductOneTableOne>> RetrieveProductOnesFungicidesWithTableOnesAsync();
    }
}
