﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------
using AggroCom.Models.Foundations.ProductOnes;
using System.Linq;
using System.Threading.Tasks;

namespace AggroCom.Services.Processings.ProductOnes
{
    public interface IProductOneProcessingService
    {
        ValueTask<IQueryable<ProductOne>> RetrieveAllProductOnesGepbisetsAsync();
        ValueTask<IQueryable<ProductOne>> RetrieveAllProductOnesFungisetsAsync();
    }
}
