using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AggroCom.Models.Foundations.ProductTwos
{
    public class ProductTwo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Des { get; set; }
        public string Description { get; set; }
        public string ProductPicture { get; set; }
        public string ProductIcon { get; set; }
        public ProductTwoType ProductTwoType { get; set; }
        [JsonIgnore]
        public List<TableTwo> TableTwos { get; set; }
    }
}
