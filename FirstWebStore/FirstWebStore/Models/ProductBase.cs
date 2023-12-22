namespace FirstWebStore.Models
{
    public class ProductBase
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }

        public ProductTypes Type { get; set; }
    }
}
