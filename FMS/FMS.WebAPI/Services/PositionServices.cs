using AutoMapper;
using FMS.DAL.Models;
using FMS.DAL.Repository;
using FMS.WebAPI.Dtos;
using FMS.WebAPI.Services.Interfaces;

namespace FMS.WebAPI.Services
{
    public class PositionServices : IPositionServices
    {
       private readonly IGenericRepository<Position> _positionRepository;
        private readonly IMapper _mapper;
        public PositionServices(IGenericRepository<Position> positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }
        public Task AddAsync(PositionDto dto)
        {
            var position = _mapper.Map<Position>(dto);
            return _positionRepository.AddAsync(position);
        }
        public Task DeleteAsync(int id)
        {
            return _positionRepository.DeleteAsync(id);
        }
        public Task<bool> Exists(int id)
        {
            return _positionRepository.Exists(id);
        }
        public List<PositionDto> GetAll()
        {
            var positions = _positionRepository.GetAll().ToList();
            return _mapper.Map<List<PositionDto>>(positions);
        }
        public async Task<PositionDto?> GetByIdAsync(int id)
        {
            var position = await _positionRepository.GetByIdAsync(id);
            return _mapper.Map<PositionDto?>(position);
        }
        public async Task UpdateAsync(PositionDto dto)
        {
            var position = _mapper.Map<Position>(dto);
            await _positionRepository.UpdateAsync(position);
        }
    }
}
