using Hexagonal.Application.Domain.Entity;

namespace Hexagonal.Application.Port.In
{
    public interface ICarServiceUseCase
    {
        Task<List<Car?>> GetCars();
        Task<Car?> BuyCar(int carId);
        Task<Car?> SellCar(int carId);
        Task<Car?> AddCar(Car car);
    }
}
