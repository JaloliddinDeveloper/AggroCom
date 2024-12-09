using AggroCom.Models.Foundations.ProductOnes;

namespace AggroCom.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<ProductOne> InsertProductOneAsync(ProductOne productOne);
        ValueTask<IQueryable<ProductOne>> SelectAllProductOnesAsync();
        ValueTask<ProductOne> SelectProductOneByIdAsync(int productOneId);
        ValueTask<ProductOne> UpdateProductOneAsync(ProductOne productOne);
        ValueTask<ProductOne> DeleteProductOneAsync(ProductOne productOne);
    }
}
