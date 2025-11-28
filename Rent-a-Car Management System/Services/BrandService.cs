using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rent_a_Car_Management_System.Dots;
using Rent_a_Car_Management_System.Models;
using Rent_a_Car_Management_System.Repository;
using Rent_a_Car_Management_System.Services.Interfaces;

namespace Rent_a_Car_Management_System.Services
{
    public class BrandService :IBrandService
    {
        private readonly IGenericRepository<Brand> _brandRepository;
        private readonly IMapper _mapper;

        public BrandService(IGenericRepository<Brand> brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<List<BrandDto>> GetAllAsync()
        {
            var brands = await _brandRepository.GetAll().ToListAsync();

            var dtos=_mapper.Map<List<BrandDto>>(brands);
            return dtos;
        }

        public async Task<BrandDto?> GetByIdAsync(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null) return null;

            var dto = _mapper.Map<BrandDto>(brand);
            return dto;
        }

        public async Task AddAsync(BrandDto dto)
        {
           var entity=_mapper.Map<Brand>(dto);

            await _brandRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(int id, BrandDto dto)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null) return;

            var entity = _mapper.Map<Brand>(dto);
            entity.Id=id;
            await _brandRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null) return;

            await _brandRepository.DeleteAsync(id);
        }
    }
}
