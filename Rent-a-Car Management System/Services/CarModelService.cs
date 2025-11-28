using Rent_a_Car_Management_System.Models;
using Rent_a_Car_Management_System.Dots;
using Rent_a_Car_Management_System.Repository;
using Rent_a_Car_Management_System.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Rent_a_Car_Management_System.Services
{
    public class CarModelService : ICarModelService
    {
        private readonly IGenericRepository<CarModel> _carModelRepository;
        private readonly IMapper _mapper;


        public CarModelService(IGenericRepository<CarModel> carModelRepository, IMapper mapper)
        {
            _carModelRepository = carModelRepository;
            _mapper = mapper;
        }

        public async Task<List<CarModelDto>> GetAllAsync()
        {
            var models = await _carModelRepository.GetAll().ToListAsync();

            var dtos = _mapper.Map<List<CarModelDto>>(models);
            return dtos;
        }

        public async Task<CarModelDto> GetByIdAsync(int id)
        {
            var model = await _carModelRepository.GetByIdAsync(id);
            if (model == null) return null;

            var dto = _mapper.Map<CarModelDto>(model);
            return dto;
        }

        public async Task AddAsync(CarModelDto dto)
        {
            var entity = _mapper.Map<CarModel>(dto);

            await _carModelRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(int id, CarModelDto dto)
        {
            var existing = await _carModelRepository.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Car model not found");

            var entity = _mapper.Map<CarModel>(dto);
            entity.Id = id;
            entity.Name = dto.Name;
            entity.BrandId = dto.BrandId;

            await _carModelRepository.UpdateAsync(id, existing);
        }

        public async Task DeleteAsync(int id) 
        {
            var brand = await _carModelRepository.GetByIdAsync(id);
            if (brand == null) return;
            await _carModelRepository.DeleteAsync(id);
        }

        public async Task<List<CarModelDto>> GetByBrandId(int brandId)
        {
            var models=await _carModelRepository.GetAll().Where(m=>m.BrandId==brandId).ToListAsync();
            
            var modelDtos= new List<CarModelDto>();
            foreach (var item in models)
            {
                var modelDto = new CarModelDto()
                {

                    BrandId = item.BrandId,
                    Name = item.Name,
                    Id = item.Id
                };
                modelDtos.Add(modelDto);
            }
            return modelDtos;
        }
    }
}
