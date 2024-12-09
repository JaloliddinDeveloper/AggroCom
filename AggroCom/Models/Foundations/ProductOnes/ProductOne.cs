namespace AggroCom.Models.Foundations.ProductOnes
{
    public class ProductOne
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TablePOne> TablePOnes { get; set; }  
    }
}
