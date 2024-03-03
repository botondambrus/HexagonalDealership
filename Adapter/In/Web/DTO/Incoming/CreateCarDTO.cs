namespace Hexagonal.Adapter.In.Web.DTO.Incoming
{
    public class CreateCarDTO
    {
        public string Model { get; set; } = null!;
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}
