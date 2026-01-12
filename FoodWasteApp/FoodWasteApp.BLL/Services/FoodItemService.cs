using AutoMapper;
using FoodWasteApp.BLL.Dtos;
using FoodWasteApp.BLL.Services.Interfaces;
using FoodWasteApp.DAL.Models;
using FoodWasteApp.DAL.Repository;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace FoodWasteApp.BLL.Services
{
    public class FoodItemService : IFoodItemService
    {
        private readonly IGenericRepository<FoodItem> _foodItemRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<FoodItemService> _logger;

        public FoodItemService(IGenericRepository<FoodItem> foodItemRepository, IMapper mapper, ILogger<FoodItemService> logger)
        {
            _foodItemRepository = foodItemRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddAsync(FoodItemDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
            _logger.LogInformation("Adding FoodItem: {FoodItemJson}", json);
            var entity = _mapper.Map<FoodItem>(dto);
            await _foodItemRepository.AddAsync(entity);
            _logger.LogInformation("FoodItem added with ID: {FoodItemId}", entity.ID);
        }

        public async Task DeleteAsync(int id)
        {
            var exists = await _foodItemRepository.Exists(id);
            if (!exists)
            {
                _logger.LogWarning("Attempted to delete FoodItem with ID: {FoodItemId}, but it does not exist.", id);
                return;
            }
           await _foodItemRepository.DeleteAsync(id);
            _logger.LogInformation("Deleted FoodItem with ID: {FoodItemId}", id);
        }

        public async Task<bool> Exists(int id)
        {
            var exists = await _foodItemRepository.Exists(id);
            if (!exists)
                _logger.LogWarning("FoodItem with ID: {FoodItemId} does not exist.", id);
            else
                _logger.LogInformation("FoodItem with ID: {FoodItemId} exists.", id);
            return exists;
        }

        public List<FoodItemDto> GetAll()
        {
            var entites = _foodItemRepository.GetAll().ToList();
            var dtos = _mapper.Map<List<FoodItemDto>>(entites);

            var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
            _logger.LogInformation("Retrieved all FoodItems: {FoodItemsJson}", json);
            return dtos;
        }

        public async Task<FoodItemDto?> GetByIdAsync(int id)
        {
            var entity = await _foodItemRepository.GetByIdAsync(id);
            var dto = _mapper.Map<FoodItemDto?>(entity);

            if(dto != null)
            {
                var json = System.Text.Json.JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });

                _logger.LogInformation("FoodItem GetByIdAsync uğurla icra olundu. Id: {Id}, Json: {Json}",id,json);
            }
            else
            {
                _logger.LogWarning("not found. Id: {id}",id);
            }
            return dto;
        }

        public async Task UpdateAsync(FoodItemDto dto)
        {
            var entity = _mapper.Map<FoodItem>(dto);    

            await _foodItemRepository.UpdateAsync(entity);
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
            _logger.LogInformation("Updated FoodItem: {id}/{FoodItemJson}",dto.Id, json);
        }
    }
}
