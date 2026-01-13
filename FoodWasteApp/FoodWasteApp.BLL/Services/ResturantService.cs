using AutoMapper;
using FoodWasteApp.BLL.Dtos;
using FoodWasteApp.BLL.Services.Interfaces;
using FoodWasteApp.DAL.Models;
using FoodWasteApp.DAL.Repository;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace FoodWasteApp.BLL.Services
{
    public class ResturantService : IResturantService
    {
        private readonly IGenericRepository<Restaurant> _restaurantRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ResturantService> _logger;

        public ResturantService(IGenericRepository<Restaurant> restaurantRepository, IMapper mapper, ILogger<ResturantService> logger)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddAsync(RestaurantDto dto)
        {
            var json = JsonSerializer.Serialize(dto,new JsonSerializerOptions { WriteIndented = true});
            _logger.LogInformation("Adding new restaurant: {RestaurantDto}", json);
            var entity = _mapper.Map<Restaurant>(dto);
            await _restaurantRepository.AddAsync(entity);
            _logger.LogInformation("Restaurant added successfully with ID: {RestaurantId}", entity.ID);
        }

        public async Task DeleteAsync(int id)
        {
            var exits = await _restaurantRepository.Exists(id);
            if (!exits)
            {
                _logger.LogWarning("Attempted to delete non-existing restaurant with ID: {RestaurantId}", id);
                return;
            }
            await _restaurantRepository.DeleteAsync(id);
            _logger.LogInformation("Deleted restaurant with ID: {RestaurantId}", id);
        }

        public async Task<bool> Exists(int id)
        {
            var exists = await _restaurantRepository.Exists(id);
            if (exists)
            {
                _logger.LogInformation("Restaurant with ID: {RestaurantId} exists", id);
            }
            else
            {
                _logger.LogInformation("Restaurant with ID: {RestaurantId} does not exist", id);
            }
            return exists;
        }

        public List<RestaurantDto> GetAll()
        {
            var entities = _restaurantRepository.GetAll().ToList();
            var dtos = _mapper.Map<List<RestaurantDto>>(entities);

            var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
            _logger.LogInformation("Retrieved {Count} restaurants", dtos.Count);
            return dtos;
        }
         
        public async Task<RestaurantDto?> GetByIdAsync(int id)
        {
            var entity = await _restaurantRepository.GetByIdAsync(id);
            var dto = _mapper.Map<RestaurantDto?>(entity);
            if (dto != null)
            {
                var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
                _logger.LogInformation("Retrieved restaurant: {Restaurant}", json);
            }
            else
            {
                _logger.LogWarning("Restaurant with ID: {RestaurantId} not found", id);
            }
            return dto;
        }

        public async Task UpdateAsync(RestaurantDto dto)
        {
            var entity = _mapper.Map<Restaurant>(dto);

            await _restaurantRepository.UpdateAsync(entity);
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
            _logger.LogInformation("Updated restaurant: {RestaurantDto}", json);
        }
    }
}
