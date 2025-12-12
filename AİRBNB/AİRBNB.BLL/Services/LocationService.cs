using AİRBNB.BLL.Dtos;
using AİRBNB.BLL.Services.Interfaces;
using AİRBNB.DAL.Models;
using AİRBNB.DAL.Repositroy;
using AutoMapper;

namespace AİRBNB.BLL.Services
{
    public class LocationService : ILocationService
    {
        private readonly IGenericRepository<Location> _locationRepository;
        private readonly IMapper _mapper;

        public LocationService(IGenericRepository<Location> locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public Task AddAsync(LocationDto dto)
        {
            var entity = _mapper.Map<Location>(dto);
            return _locationRepository.AddAsync(entity);
        }

        public Task DeleteAsync(int id)
        {

            return _locationRepository.DeleteAsync(id);
        }

        public Task<bool> Exists(int id)
        {
            return _locationRepository.Exists(id);
        }

        public List<LocationDto> GetAll()
        {
            var entities = _locationRepository.GetAll().ToList();
            return _mapper.Map<List<LocationDto>>(entities);
        }

        public async Task<LocationDto?> GetByIdAsync(int id)
        {
            var entity = await _locationRepository.GetByIdAsync(id);
            var dto = _mapper.Map<LocationDto?>(entity);
            return dto;
        }

        public Task UpdateAsync(LocationDto dto)
        {
            var entity = _mapper.Map<Location>(dto);
            return _locationRepository.UpdateAsync(entity);
        }
    }
}
