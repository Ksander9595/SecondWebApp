using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace FirstWebStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public ProductTypes Type { get; set; }
        public int? EquipmentId { get; set; }//внешний ключ
        public int? MotocycleId { get; set; }
        public int? SparePartId { get; set; }

        public virtual Equipment? Equipment { get; set; }//навигационное свойство
        public virtual Motocycle? Motocycle { get; set; }
        public virtual SparePart? SparePart { get; set; }
    }

    public enum ProductTypes
    {
        Equipment,
        Motocycle,
        SparePart,
    }

    public class ProductBase
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }
    }
}
