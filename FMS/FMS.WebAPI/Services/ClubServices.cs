using AutoMapper;
using FMS.DAL.Models;
using FMS.DAL.Repository;
using FMS.WebAPI.Dtos;
using FMS.WebAPI.Services.Interfaces;

namespace FMS.WebAPI.Services
{
    public class ClubServices :IClubServices
    {
        private readonly IGenericRepository<Club> _clubRepository;
        private readonly IMapper _mapper;

        public ClubServices(IGenericRepository<Club> clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public Task AddAsync(ClubDto dto)
        {
            var club = _mapper.Map<Club>(dto);
            return _clubRepository.AddAsync(club);
        }
        public Task DeleteAsync(int id)
        {
            return _clubRepository.DeleteAsync(id);
        }
        
        public Task<bool> Exists(int id)
        {
            return _clubRepository.Exists(id);
        }
        public List<ClubDto> GetAll()
        {
            var clubs = _clubRepository.GetAll().ToList();
            return _mapper.Map<List<ClubDto>>(clubs);
        }
        public async Task<ClubDto?> GetByIdAsync(int id)
        {
            var club =  await _clubRepository.GetByIdAsync(id);
            return _mapper.Map<ClubDto?>(club);
        }
        public async Task UpdateAsync(ClubDto dto)
        {
            var club = _mapper.Map<Club>(dto);
            await _clubRepository.UpdateAsync(club);
        }
    }
}
