using AggroCom.Models.Foundations.ProductOnes;
using System.Collections.Generic;

namespace AggroCom.Models.Orchestrations
{
    public class ProductOneTableOne
    {
        public ProductOne ProductOne { get; set; }
        public List<TableOne> TableOnes { get; set; }
    }
}
