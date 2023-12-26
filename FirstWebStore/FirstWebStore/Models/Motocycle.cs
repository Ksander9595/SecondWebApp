namespace FirstWebStore.Models
{
    public class Motocycle : ProductBase
    {
        public string? ModelMoto { get; set; }
        public int Year { get; set; }
        public int Hp { get; set; }
        public int EngineCapacity { get; set; }
        public MotocycleType MotoType { get; set; }
        public int CarMileage { get; set; }
        public bool NewMotocycle { get; set; }
        public bool Document { get; set; }
        public bool OK { get; set; }
        

    }
}
