using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rent_a_Car_Management_System.Dots;
using Rent_a_Car_Management_System.Models;
using Rent_a_Car_Management_System.Repository;
using Rent_a_Car_Management_System.Services.Interfaces;

namespace Rent_a_Car_Management_System.Services
{
    public class CarService : ICarService
    {
        private readonly IGenericRepository<Car> _carRepository;
        private readonly IGenericRepository<CarModel> _modelRepository;
        private readonly IMapper _mapper;

        public CarService(IGenericRepository<Car> carRepository, IGenericRepository<CarModel> modelRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<List<CarDto>> GetAllAsync()
        {
            var cars = await _carRepository.GetAll().ToListAsync();

            var dtos = _mapper.Map<List<CarDto>>(cars);
            return dtos;
        }

        public async Task<CarDto> GetByIdAsync(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car == null) return null;

            var dto = _mapper.Map<CarDto>(car);
            return dto;
        }

        public async Task AddAsync(CarDto dto)
        {
            var entity = _mapper.Map<Car>(dto);

            await _carRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(int id, CarDto dto)
        {
            var existing = await _carRepository.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Car not found");

            var entity = _mapper.Map<Car>(dto);
            entity.Id = id;

            await _carRepository.UpdateAsync(id, existing);
        }

        public async Task DeleteAsync(int id)
        {
            var brand = await _carRepository.GetByIdAsync(id);
            if (brand == null) return;
            await _carRepository.DeleteAsync(id);
        }

        public async Task<List<CarDto>> GetByModelId(int modelId)
        {
            var cars = await _carRepository.GetAll().Where(c => c.CarModelId == modelId).ToListAsync();
            var carsDtos = new List<CarDto>();
            foreach (var car in cars)
            {
                var carDto = new CarDto
                {
                    Id = car.Id,
                    Plate = car.Plate,
                    BrandId = car.BrandId,
                    CarModelId = car.CarModelId
                };
                carsDtos.Add(carDto);


            }
            return carsDtos;
        }

        public async Task<List<CarDto>> GetByBrandId(int brandId)
        {
            var models = await _modelRepository.GetAll().Where(m => m.BrandId == brandId).ToListAsync();

            var carDtos = new List<CarDto>();

            foreach (var model in models)
            {

                var cars = _carRepository.GetAll().Where(c => c.CarModelId == model.Id).ToList();

                foreach (var car in cars)
                {
                    var carDto = new CarDto
                    {
                        Id = car.Id,
                        Plate = car.Plate,
                        BrandId = car.BrandId,
                        CarModelId = car.CarModelId
                    };
                    carDtos.Add(carDto);
                }
            }
            return carDtos;

        }
    }
}
