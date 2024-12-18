﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------
using AggroCom.Models.Foundations.ProductOnes;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AggroCom.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<TableOne> TableOnes { get; set; }

        public async ValueTask<TableOne> InsertTableOneAsync(TableOne tableOne) =>
            await InsertAsync(tableOne);

        public async ValueTask<IQueryable<TableOne>> SelectAllTableOnesAsync() =>
            await SelectAllAsync<TableOne>();

        public async ValueTask<TableOne> SelectTableOneByIdAsync(int tableOneId) =>
            await SelectAsync<TableOne>(tableOneId);

        public async ValueTask<TableOne> UpdateTableOneAsync(TableOne tableOne) =>
            await UpdateAsync(tableOne);

        public async ValueTask<TableOne> DeleteTableOneAsync(TableOne tableOne) =>
            await DeleteAsync(tableOne);
    }
}
