using System.ComponentModel.DataAnnotations;

namespace Hexagonal.Adapter.Out.Persistance
{
    public class CarEfEntity
    {
        [Key]
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}
