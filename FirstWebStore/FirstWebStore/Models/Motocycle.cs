namespace FirstWebStore.Models
{
    public class Motocycle : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Hp { get; set; }
        public int EngineCapacity { get; set; }
        public MotocycleClass motocycleClass { get; set; }
        public bool CarMileage { get; set; }

    }
}
