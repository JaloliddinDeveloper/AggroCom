using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AggroCom.Models.Foundations.ProductOnes
{
    public class ProductOne
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TasirModda { get; set; }
        public string KimyoviySinfi { get; set; }
        public string PreparatShakli { get; set; }
        public string Qadogi { get; set; }
        public string ProductPicture { get; set; }
        public ProductType ProductType { get; set; }
        [JsonIgnore]
        public List<TableOne> TableOnes { get; set; }  
    }
}
