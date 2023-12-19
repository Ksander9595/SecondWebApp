namespace FirstWebStore.Models
{
    public class Equipment : Product
    {
        public bool NewEquipment { get; set; }
        public EquipmentType equipType { get; set; }
    }
}
