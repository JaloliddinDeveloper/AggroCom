using AggroCom.Models.Orchestrations.ProductOnes;
using System.Threading.Tasks;

namespace AggroCom.Services.Orchestrations.ProductOneTableOneOrchestrationServices
{
    public interface IProductOneTableOneOrchestrationService
    {
        ValueTask<ProductOneTableOne> RetrieveProductOneTableOneByIdAsync(int productId);
    }
}
