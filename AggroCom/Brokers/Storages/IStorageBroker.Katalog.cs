﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------
using AggroCom.Models.Foundations.Katalogs;
using System.Linq;
using System.Threading.Tasks;

namespace AggroCom.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Katalog> InsertKatalogAsync(Katalog Katalog);
        ValueTask<IQueryable<Katalog>> SelectAllKatalogsAsync();
        ValueTask<Katalog> SelectKatalogByIdAsync(int KatalogId);
        ValueTask<Katalog> UpdateKatalogAsync(Katalog Katalog);
        ValueTask<Katalog> DeleteKatalogAsync(Katalog Katalog);
    }
}