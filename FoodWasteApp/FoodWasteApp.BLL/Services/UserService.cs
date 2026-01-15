using AutoMapper;
using Microsoft.Extensions.Logging;
using FoodWasteApp.BLL.Dtos;
using FoodWasteApp.BLL.Services.Interfaces;
using FoodWasteApp.DAL.Models;
using FoodWasteApp.DAL.Repository;
using System.Text.Json;

namespace FoodWasteApp.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IGenericRepository<User> userRepository, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddAsync(UserDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
            _logger.LogInformation("Adding new user: {UserDto}", json);
            var entity = _mapper.Map<User>(dto);
            await _userRepository.AddAsync(entity);
            _logger.LogInformation("User added successfully with ID: {UserId}", entity.ID);
        }

        public async Task DeleteAsync(int id)
        {
            var exits = await _userRepository.Exists(id);
            if (!exits)
            {
                _logger.LogWarning("Attempted to delete non-existing user with ID: {UserId}", id);
                return;
            }
            await _userRepository.DeleteAsync(id);
            _logger.LogInformation("Deleted user with ID: {UserId}", id);
        }

        public async Task<bool> Exists(int id)
        {
            var exists = await _userRepository.Exists(id);
            if (exists)
            {
                _logger.LogInformation("User with ID: {UserId} exists", id);
            }
            else
            {
                _logger.LogInformation("User with ID: {UserId} does not exist", id);
            }
            return exists;
        }

        public List<UserDto> GetAll()
        {
            var entities = _userRepository.GetAll().ToList();
            var dtos = _mapper.Map<List<UserDto>>(entities);

            var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
            _logger.LogInformation("Retrieved all users: {UserDtos}", json);
            return dtos;
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var entity = await _userRepository.GetByIdAsync(id);
            var dto = _mapper.Map<UserDto?>(entity);
            if(dto != null)
            {
                var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
                _logger.LogInformation("Retrieved user by ID {UserId}: {UserDto}", id, json);
            }
            else
            {
                _logger.LogWarning("User with ID {UserId} not found", id);
            }
            return dto;
        }

        public async Task UpdateAsync(UserDto dto)
        {
            var entity =  await _userRepository.GetByIdAsync(dto.Id);

            await _userRepository.UpdateAsync(_mapper.Map(dto, entity));
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
            _logger.LogInformation("Updated user with ID {UserId}: {UserDto}", dto.Id, json);

        }
    }
}
