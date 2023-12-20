namespace FirstWebStore.Models
{
    public class SparePart : ProductBase
    {
        public SparePartsType PartsType { get; set; }
        public virtual Product Product { get; set; }
    }
}
