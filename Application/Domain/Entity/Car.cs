namespace Hexagonal.Application.Domain.Entity
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}
