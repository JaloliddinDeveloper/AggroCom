using System.Text.Json.Serialization;

namespace AggroCom.Models.Foundations.ProductOnes
{
    public class TableOne
    {
        public int Id { get; set; }
        public string EkinTuriUz { get; set; }
        public string EkinTuriRu { get; set; }
        public string BegonaQarshiUz { get; set; }
        public string BegonaQarshiRu { get; set; }
        public string SarfMeyoriUz { get; set; }
        public string SarfMeyoriRu { get; set; }
        public string CheklovlarUz { get; set; }
        public string CheklovlarRu { get; set; }
        public int MavsumNechta { get; set; }
        public int ProductOneId { get; set; }
    }
}
