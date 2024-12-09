namespace AggroCom.Models.Foundations.ProductOnes
{
    public class TablePOne
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductOneId { get; set; }   
        public ProductOne ProductOne { get; set; }
    }
}
