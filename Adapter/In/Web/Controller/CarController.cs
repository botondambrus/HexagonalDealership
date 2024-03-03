using Hexagonal.Application.Port.In;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Hexagonal.Application.Domain.Entity;
using Hexagonal.Adapter.In.Web.DTO.Incoming;
using Hexagonal.Adapter.In.Web.DTO.Outgoing;

namespace Hexagonal.Adapter.In.Web.Controller
{
    [Route("api/car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarServiceUseCase _carService;
        private readonly IMapper _mapper;

        public CarController(ICarServiceUseCase carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var cars = await _carService.GetCars();
            if (cars == null)
            {
                return NotFound("Cars not found");
            }

            var carsDTO = _mapper.Map<IEnumerable<GetCarDTO>>(cars);
            return Ok(carsDTO);
        }

        [HttpGet("buy/{carId}")]
        public async Task<IActionResult> BuyCar(int carId)
        {
            var car = await _carService.BuyCar(carId);
            if (car == null)
            {
                return NotFound("Car not found");
                
            }

            var carDTO = _mapper.Map<GetCarDTO>(car);
            return Ok(carDTO);
        }

        [HttpGet("sell/{carId}")]
        public async Task<IActionResult> SellCar(int carId)
        {
            var car = await _carService.SellCar(carId);
            if (car == null)
            {
                return NotFound("Car not found");

            }

            var carDTO = _mapper.Map<GetCarDTO>(car);
            return Ok(carDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(CreateCarDTO createCarDTO)
        {
            var car = _mapper.Map<Car>(createCarDTO);
            var createdCar = await _carService.AddCar(car);

            if (createdCar == null)
            {
                return BadRequest("Error in creating car");
               
            }

            var createdCarDTO = _mapper.Map<GetCarDTO>(createdCar);
            return Ok(createdCarDTO);
        }
    }
}
