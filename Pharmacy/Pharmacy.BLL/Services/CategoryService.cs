using AutoMapper;
using Microsoft.Extensions.Logging;
using Pharmacy.BLL.Dtos;
using Pharmacy.BLL.Services.Interfaces;
using Pharmacy.DAL.Models;
using Pharmacy.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pharmacy.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(IGenericRepository<Category> categoryRepository, IMapper mapper, ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddAsync(CategoryDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
            _logger.LogInformation("Adding new category:\n{JsonData}", json);
            var entity = _mapper.Map<Category>(dto);
            await _categoryRepository.AddAsync(entity);
            _logger.LogInformation("Added new category with ID {CategoryId}", entity.Id);
        }

        public async Task DeleteAsync(int id)
        {
            var exists = await _categoryRepository.Exists(id);
            if (!exists)
            {
                _logger.LogWarning("Attempted to delete non-existing category with ID {CategoryId}", id);
                return;
            }
            await _categoryRepository.DeleteAsync(id);
            _logger.LogInformation("Deleted category with ID {CategoryId}", id);
        }

        public async Task<bool> Exists(int id)
        {
            var exists = await _categoryRepository.Exists(id);
            if (!exists)
                _logger.LogInformation("Category with ID {CategoryId} does not exist", id);
            else
                _logger.LogInformation("Category with ID {CategoryId} exists", id);

            return exists;
        }

        public List<CategoryDto> GetAll()
        {
            var entities = _categoryRepository.GetAll().ToList();
            var dtos = _mapper.Map<List<CategoryDto>>(entities);

            var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
            _logger.LogInformation("Retrieved all categories: {CategoriesJson}", json);

            return dtos;
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var entity = await _categoryRepository.GetByIdAsync(id);
            var dto = _mapper.Map<CategoryDto?>(entity);

            if (dto != null)
            {
                var json = System.Text.Json.JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });

                _logger.LogInformation("Retrieved category with ID {CategoryId}: {CategoryJson}", id, json);
            }
            else
            {
                _logger.LogWarning("Category with ID {CategoryId} not found.", id);
            }
            return dto;
        }

        public async Task UpdateAsync(CategoryDto dto)
        {
            var entity = _mapper.Map<Category>(dto);

            await _categoryRepository.UpdateAsync(entity);
            var json = System.Text.Json.JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
            _logger.LogInformation("Updated category with ID {CategoryId}:\n{JsonData}", dto.Id, json);
        }
    }
}
