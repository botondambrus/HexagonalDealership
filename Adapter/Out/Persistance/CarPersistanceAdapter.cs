using AutoMapper;
using Hexagonal.Application.Domain.Entity;
using Hexagonal.Application.Port.Out;
using Microsoft.EntityFrameworkCore;

namespace Hexagonal.Adapter.Out.Persistance
{
    public class CarPersistanceAdapter : ICarPersistancePort
    {
        private readonly IMapper _mapper;
        private readonly CarDbContext _context;

        public CarPersistanceAdapter(IMapper mapper, CarDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Car?> FindCar(int carId)
        {
            var car = await _context.Cars.FindAsync(carId);

            return _mapper.Map<Car?>(car);
        }


        public async Task<List<Car?>> FindAllCars()
        {
            var cars = await _context.Cars.ToListAsync();

            return _mapper.Map<List<Car?>>(cars);
        }

        public async Task<Car?> AddCar(Car car)
        {
            var carEfEntity = _mapper.Map<CarEfEntity>(car);
            _context.Cars.Add(carEfEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Car>(carEfEntity);
        }

        public async Task<Car?> UpdateCar(Car car)
        {

            var carToUpdate = await _context.Cars.FindAsync(car.Id);
            if (carToUpdate != null)
            {
                carToUpdate.Model = car.Model;
                carToUpdate.Price = car.Price;
                carToUpdate.Stock = car.Stock;
                await _context.SaveChangesAsync();
            }

            return _mapper.Map<Car?>(carToUpdate);
        }


    }
}
