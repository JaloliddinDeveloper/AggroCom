﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------
using AggroCom.Models.Foundations.ProductTwos;
using System.Linq;
using System.Threading.Tasks;

namespace AggroCom.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<TableTwo> InsertTableTwoAsync(TableTwo tableTwo);
        ValueTask<IQueryable<TableTwo>> SelectAllTableTwosAsync();
        ValueTask<TableTwo> SelectTableTwoByIdAsync(int tableTwoId);
        ValueTask<TableTwo> UpdateTableTwoAsync(TableTwo tableTwo);
        ValueTask<TableTwo> DeleteTableTwoAsync(TableTwo tableTwo);
    }
}
