﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AggroCom.Models.Foundations.ProductTwos
{
    public class ProductTwo
    {
        public int Id { get; set; }
        public string TitleUz { get; set; }
        public string TitleRu { get; set; }
        public string NameUz { get; set; }
        public string NameRu { get; set; }
        public string DesUz { get; set; }
        public string DesRu { get; set; }
        public string DescriptionUz { get; set; }
        public string DescriptionRu { get; set; }
        public string SarfUz { get; set; }
        public string SarfRu { get; set; }
        public string ProductPicture { get; set; }
        public string ProductIcon { get; set; }
        public string ProductTwoName { get; set; }
        public ProductTwoType ProductTwoType { get; set; }
        [JsonIgnore]
        public List<TableTwo> TableTwos { get; set; }
    }
}
