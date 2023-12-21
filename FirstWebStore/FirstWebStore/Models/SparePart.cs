namespace FirstWebStore.Models
{
    public class SparePart : ProductBase
    {
        public SparePartType PartsType { get; set; }
        public virtual Product Product { get; set; }
    }
}
