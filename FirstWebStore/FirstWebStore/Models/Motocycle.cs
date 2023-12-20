namespace FirstWebStore.Models
{
    public class Motocycle : ProductBase
    {
        public int Year { get; set; }
        public int Hp { get; set; }
        public int EngineCapacity { get; set; }
        public MotocycleType MotoType { get; set; }
        public bool CarMileage { get; set; }
        public bool NewMotocycle { get; set; }
        public virtual Product Product { get; set; }

    }
}
