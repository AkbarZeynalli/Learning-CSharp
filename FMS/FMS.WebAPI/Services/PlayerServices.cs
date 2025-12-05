using AutoMapper;
using FMS.DAL.Models;
using FMS.DAL.Repository;
using FMS.WebAPI.Dtos;
using FMS.WebAPI.Services.Interfaces;

namespace FMS.WebAPI.Services
{
    public class PlayerServices: IPlayerServices
    {
        private readonly IGenericRepository<Player> _playerRepository;
        private readonly IMapper _mapper;


        public PlayerServices(IGenericRepository<Player> playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }
        public Task AddAsync(PlayerDto dto)
        {
            var player = _mapper.Map<Player>(dto);
            return _playerRepository.AddAsync(player);
        }
        public Task DeleteAsync(int id)
        {
            return _playerRepository.DeleteAsync(id);
        }
        public Task<bool> Exists(int id)
        {
            return _playerRepository.Exists(id);
        }
        public List<PlayerDto> GetAll()
        {
            var players = _playerRepository.GetAll().ToList();
            return _mapper.Map<List<PlayerDto>>(players);
        }
        public async Task<PlayerDto?> GetByIdAsync(int id)
        {
            var player = await _playerRepository.GetByIdAsync(id);
            return _mapper.Map<PlayerDto?>(player);
        }
        public async Task UpdateAsync(PlayerDto dto)
        {
            var player = _mapper.Map<Player>(dto);
            await _playerRepository.UpdateAsync(player);
        }
    }
}
