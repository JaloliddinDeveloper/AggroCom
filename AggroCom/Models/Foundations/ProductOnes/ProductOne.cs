using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AggroCom.Models.Foundations.ProductOnes
{
    public class ProductOne
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<TableOne> TableOnes { get; set; }  
    }
}
