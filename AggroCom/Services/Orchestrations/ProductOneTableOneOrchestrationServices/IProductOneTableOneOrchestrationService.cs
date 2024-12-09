using AggroCom.Models.Foundations.ProductOnes;
using AggroCom.Models.Orchestrations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AggroCom.Services.Orchestrations.ProductOneTableOneOrchestrationServices
{
    public interface IProductOneTableOneOrchestrationService
    {
        ValueTask<IQueryable<ProductOneTableOne>> RetrieveAllProductOnesWithTableOnessAsync();
    }
}
