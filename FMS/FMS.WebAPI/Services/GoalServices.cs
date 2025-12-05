using AutoMapper;
using FMS.DAL.Models;
using FMS.DAL.Repository;
using FMS.WebAPI.Dtos;
using FMS.WebAPI.Services.Interfaces;

namespace FMS.WebAPI.Services
{
    public class GoalServices : IGoalServices
    {
        private readonly IGenericRepository<Goal> _goalRepository;
        private readonly IMapper _mapper;

        public GoalServices(IGenericRepository<Goal> goalRepository, IMapper mapper)
        {
            _goalRepository = goalRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(GoalDto dto)
        {
            var goal = _mapper.Map<Goal>(dto);
            await _goalRepository.AddAsync(goal);
        }
        public async Task DeleteAsync(int id)
        {
            await _goalRepository.DeleteAsync(id);
        }
        public async Task<bool> Exists(int id)
        {
            return await _goalRepository.Exists(id);
        }
        public List<GoalDto> GetAll()
        {
            var goals = _goalRepository.GetAll().ToList();
            return _mapper.Map<List<GoalDto>>(goals);
        }
        public async Task<GoalDto?> GetByIdAsync(int id)
        {
            var goal = await _goalRepository.GetByIdAsync(id);
            return _mapper.Map<GoalDto?>(goal);
        }
        public async Task UpdateAsync(GoalDto dto)
        {
            var goal = _mapper.Map<Goal>(dto);
            await _goalRepository.UpdateAsync(goal);
        }

    }
}
