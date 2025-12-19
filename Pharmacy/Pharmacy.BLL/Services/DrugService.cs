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
    public class DrugService : IDrugservice
    {
        private readonly IGenericRepository<Drug> _drugRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DrugService> _logger;

        public DrugService(IGenericRepository<Drug> drugRepository, IMapper mapper, ILogger<DrugService> logger)
        {
            _drugRepository = drugRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddAsync(DrugDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
            _logger.LogInformation("Adding new category:\n{JsonData}", json);
            var entity = _mapper.Map<Drug>(dto);
            await _drugRepository.AddAsync(entity);
            _logger.LogInformation("Added new category with ID {CategoryId}", entity.Id);
        }

        public async Task DeleteAsync(int id)
        {
            var exists = await _drugRepository.Exists(id);
            if (!exists)
            {
                _logger.LogWarning("Attempted to delete non-existing category with ID {CategoryId}", id);
                return;
            }
            await _drugRepository.DeleteAsync(id);
            _logger.LogInformation("Deleted category with ID {CategoryId}", id);
        }

        public async Task<bool> Exists(int id)
        {
            var exists = await _drugRepository.Exists(id);
            if (!exists)
                _logger.LogInformation("Category with ID {CategoryId} does not exist", id);
            else
                _logger.LogInformation("Category with ID {CategoryId} exists", id);

            return exists;
        }

        public List<DrugDto> GetAll()
        {
            var entities = _drugRepository.GetAll().ToList();
            var dtos = _mapper.Map<List<DrugDto>>(entities);

            var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
            _logger.LogInformation("Retrieved all categories: {CategoriesJson}", json);

            return dtos;
        }

        public async Task<DrugDto?> GetByIdAsync(int id)
        {
            var entity = await _drugRepository.GetByIdAsync(id);
            var dto = _mapper.Map<DrugDto?>(entity);

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

        public async Task UpdateAsync(DrugDto dto)
        {
            var entity = _mapper.Map<Drug>(dto);

            await _drugRepository.UpdateAsync(entity);
            var json = System.Text.Json.JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
            _logger.LogInformation("Updated category with ID {CategoryId}:\n{JsonData}", dto.Id, json);
        }
    }
}
