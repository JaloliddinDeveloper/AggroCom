
using AggroCom.Models.Foundations.ProductOnes;

namespace AggroCom.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<TablePOne> InsertTablePOneAsync(TablePOne tablePOne);
        ValueTask<IQueryable<TablePOne>> SelectAllTablePOnesAsync();
        ValueTask<TablePOne> SelectTablePOneByIdAsync(int tablePOneId);
        ValueTask<TablePOne> UpdateTablePOneAsync(TablePOne tablePOne);
        ValueTask<TablePOne> DeleteTablePOneAsync(TablePOne tablePOne);
    }
}
