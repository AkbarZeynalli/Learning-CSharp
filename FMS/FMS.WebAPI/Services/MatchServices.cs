using AutoMapper;
using FMS.DAL.Models;
using FMS.DAL.Repository;
using FMS.WebAPI.Dtos;
using FMS.WebAPI.Services.Interfaces;
//using System.Text.RegularExpressions;

namespace FMS.WebAPI.Services
{
    public class MatchServices : IMatchServices
    {
        private readonly IGenericRepository<Match> _matchRepository;
        private readonly IMapper _mapper;

        public MatchServices(IGenericRepository<Match> matchRepository, IMapper mapper)
        {
            _matchRepository = matchRepository;
            _mapper = mapper;
        }

        public Task AddAsync(MatchDto dto)
        {
            var match = _mapper.Map<Match>(dto);
            return _matchRepository.AddAsync(match);
        }
        public Task DeleteAsync(int id)
        {
            return _matchRepository.DeleteAsync(id);
        }
        public Task<bool> Exists(int id)
        {
            return _matchRepository.Exists(id);
        }
        public List<MatchDto> GetAll()
        {
            var matches = _matchRepository.GetAll().ToList();
            return _mapper.Map<List<MatchDto>>(matches);
        }
        public async Task<MatchDto?> GetByIdAsync(int id)
        {
            var match = await _matchRepository.GetByIdAsync(id);
            return _mapper.Map<MatchDto?>(match);
        }
        public async Task UpdateAsync(MatchDto dto)
        {
            var match = _mapper.Map<Match>(dto);
            await _matchRepository.UpdateAsync(match);
        }
    }
}
