using Hexagonal.Application.Domain.Entity;
using Hexagonal.Application.Port.Out;
using Hexagonal.Application.Port.In;

namespace Hexagonal.Application.Domain.Service
{
    public class CarService : ICarServiceUseCase
    {
        private readonly ICarPersistancePort _carPersistanceAdapter;


        public CarService(ICarPersistancePort carPersistanceAdapter)
        {
            _carPersistanceAdapter = carPersistanceAdapter;
        }

        public async Task<List<Car?>> GetCars()
        {
            var cars = await _carPersistanceAdapter.FindAllCars();

            return cars;
        }

        public async Task<Car?> BuyCar(int carId)
        {
            var car = await _carPersistanceAdapter.FindCar(carId);

            if (car == null)
            {
                return null;
            }

            car.Stock++;
            var updatedCar = await _carPersistanceAdapter.UpdateCar(car);

            return updatedCar;
        }

        public async Task<Car?> SellCar(int carId)
        {
            var car = await _carPersistanceAdapter.FindCar(carId);

            if (car == null || car.Stock == 0)
            {
                return null;
            }

            car.Stock--;
            var updatedCar = await _carPersistanceAdapter.UpdateCar(car);

            return updatedCar;
        }

        public async Task<Car?> AddCar(Car createCar)
        {
            var car = await _carPersistanceAdapter.AddCar(createCar);

            return car;
        }
    }
}
