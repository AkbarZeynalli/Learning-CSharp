using AİRBNB.BLL.Dtos;
using AİRBNB.BLL.Services.Interfaces;
using AİRBNB.DAL.Models;
using AİRBNB.DAL.Repositroy;
using AutoMapper;

namespace AİRBNB.BLL.Services
{
    public class RoomService : IRoomService
    {
        private readonly IGenericRepository<Room> _roomRepository;
        private readonly IMapper _mapper;
        public RoomService(IGenericRepository<Room> roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }
        public Task AddAsync(RoomDto dto)
        {
            var entity = _mapper.Map<Room>(dto);
            return _roomRepository.AddAsync(entity);
        }
        public Task DeleteAsync(int id)
        {
            return _roomRepository.DeleteAsync(id);
        }
        public Task<bool> Exists(int id)
        {
            return _roomRepository.Exists(id);
        }
        public List<RoomDto> GetAll()
        {
            var entities = _roomRepository.GetAll().ToList();
            return _mapper.Map<List<RoomDto>>(entities);
        }
        public async Task<RoomDto?> GetByIdAsync(int id)
        {
            var entity = await _roomRepository.GetByIdAsync(id);
            var dto = _mapper.Map<RoomDto?>(entity);
            return dto;
        }
        public Task UpdateAsync(RoomDto dto)
        {
            var entity = _mapper.Map<Room>(dto);
            return _roomRepository.UpdateAsync(entity);
        }
    }
}
