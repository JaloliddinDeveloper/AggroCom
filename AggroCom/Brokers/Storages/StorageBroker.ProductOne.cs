﻿using AggroCom.Models.Foundations.ProductOnes;
using Microsoft.EntityFrameworkCore;

namespace AggroCom.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<ProductOne> ProductOnes { get; set; }

        public async ValueTask<ProductOne> InsertProductOneAsync(ProductOne productOne) =>
            await InsertAsync(productOne);

        public async ValueTask<IQueryable<ProductOne>> SelectAllProductOnesAsync() =>
            await SelectAllAsync<ProductOne>();

        public async ValueTask<ProductOne> SelectProductOneByIdAsync(int productOneId) =>
            await SelectAsync<ProductOne>(productOneId);

        public async ValueTask<ProductOne> UpdateProductOneAsync(ProductOne productOne) =>
            await UpdateAsync(productOne);

        public async ValueTask<ProductOne> DeleteProductOneAsync(ProductOne productOne) =>
            await DeleteAsync(productOne);
    }
}