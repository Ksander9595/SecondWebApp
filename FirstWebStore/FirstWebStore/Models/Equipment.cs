namespace FirstWebStore.Models
{
    public class Equipment : ProductBase
    {
        public bool NewEquipment { get; set; }
        public EquipmentType EquipType { get; set; }

        public virtual Product Product { get; set; }
    }
}
