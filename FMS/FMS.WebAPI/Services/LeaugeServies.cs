using AutoMapper;
using FMS.DAL.Models;
using FMS.DAL.Repository;
using FMS.WebAPI.Dtos;
using FMS.WebAPI.Services.Interfaces;

namespace FMS.WebAPI.Services
{
    public class LeaugeServies : ILeaugeServies
    {
        private readonly IGenericRepository<League> _leaugeRepository;
        private readonly IMapper _mapper;

        public LeaugeServies(IGenericRepository<League> leaugeRepository, IMapper mapper)
        {
            _leaugeRepository = leaugeRepository;
            _mapper = mapper;
        }


        public Task AddAsync(LeaugeDto dto)
        {
            var leage = _mapper.Map<League>(dto);
            return _leaugeRepository.AddAsync(leage);
        }
        public Task DeleteAsync(int id)
        {
            return _leaugeRepository.DeleteAsync(id);
        }
        public Task<bool> Exists(int id)
        {
            return _leaugeRepository.Exists(id);
        }
        public List<LeaugeDto> GetAll()
        {
            var leauges = _leaugeRepository.GetAll().ToList();
            return _mapper.Map<List<LeaugeDto>>(leauges);
        }
        public async Task<LeaugeDto?> GetByIdAsync(int id)
        {
            var leauge = await _leaugeRepository.GetByIdAsync(id);
            return _mapper.Map<LeaugeDto?>(leauge);
        }
        public async Task UpdateAsync(LeaugeDto dto)
        {
            var leage = _mapper.Map<League>(dto);
            await _leaugeRepository.UpdateAsync(leage);
        }
    }
}
