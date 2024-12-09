using AggroCom.Models.Foundations.ProductOnes;
using Microsoft.EntityFrameworkCore;

namespace AggroCom.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<TablePOne> TablePOnes { get; set; }

        public async ValueTask<TablePOne> InsertTablePOneAsync(TablePOne tablePOne) =>
            await InsertAsync(tablePOne);

        public async ValueTask<IQueryable<TablePOne>> SelectAllTablePOnesAsync() =>
            await SelectAllAsync<TablePOne>();

        public async ValueTask<TablePOne> SelectTablePOneByIdAsync(int tablePOneId) =>
            await SelectAsync<TablePOne>(tablePOneId);

        public async ValueTask<TablePOne> UpdateTablePOneAsync(TablePOne tablePOne) =>
            await UpdateAsync(tablePOne);

        public async ValueTask<TablePOne> DeleteTablePOneAsync(TablePOne tablePOne) =>
            await DeleteAsync(tablePOne);
    }
}
