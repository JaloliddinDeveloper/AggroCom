﻿
using AggroCom.Models.Foundations.ProductOnes;
using System.Linq;
using System.Threading.Tasks;

namespace AggroCom.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<TableOne> InsertTableOneAsync(TableOne TableOne);
        ValueTask<IQueryable<TableOne>> SelectAllTableOnesAsync();
        ValueTask<TableOne> SelectTableOneByIdAsync(int TableOneId);
        ValueTask<TableOne> UpdateTableOneAsync(TableOne TableOne);
        ValueTask<TableOne> DeleteTableOneAsync(TableOne TableOne);
    }
}
