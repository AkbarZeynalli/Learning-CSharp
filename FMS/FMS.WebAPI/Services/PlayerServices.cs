using AutoMapper;
using FMS.DAL.Models;
using FMS.DAL.Repository;
using FMS.WebAPI.Dtos;
using FMS.WebAPI.Services.Interfaces;


namespace FMS.WebAPI.Services
{
    public class PlayerServices : IPlayerServices
    {
        private readonly IGenericRepository<Player> _playerRepository;
        private readonly IGenericRepository<Club> _clubRepository;
        private readonly IMapper _mapper;

        public PlayerServices(
            IGenericRepository<Player> playerRepository,
            IGenericRepository<Club> clubRepository,
            IMapper mapper)
        {
            _playerRepository = playerRepository;
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public async Task<PlayerDto> AddAsync(PlayerDto dto)
        {
            // Validate FK target exists before attempting insert to avoid DB FK exception
            if (!await _clubRepository.Exists(dto.ClubId))
            {
                throw new InvalidOperationException($"Club with id {dto.ClubId} does not exist.");
            }

            var player = _mapper.Map<Player>(dto);
            await _playerRepository.AddAsync(player);

            // Map saved entity back to DTO (ensures Id from DB is present)
            var created = _mapper.Map<PlayerDto>(player);
            return created;
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