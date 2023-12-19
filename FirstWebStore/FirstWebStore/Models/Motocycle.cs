namespace FirstWebStore.Models
{
    public class Motocycle : Product
    {
        public int Year { get; set; }
        public int Hp { get; set; }
        public int EngineCapacity { get; set; }
        public MotocycleType motoType { get; set; }
        public bool CarMileage { get; set; }
        public bool NewMotocycle { get; set; }

    }
}
