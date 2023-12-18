namespace FirstWebStore.Models
{
    public class Equipment : IProduct
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public bool NewEquipment { get; set; }
    }
}
