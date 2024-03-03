using Hexagonal.Application.Domain.Entity;


namespace Hexagonal.Application.Port.Out
{
    public interface ICarPersistancePort
    {
        Task<Car?> FindCar(int carId);
        Task<List<Car?>> FindAllCars();
        Task<Car?> UpdateCar(Car car);
        Task<Car?> AddCar(Car car);
    }
}
