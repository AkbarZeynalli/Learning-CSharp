using AutoMapper;
using FoodWasteApp.BLL.Services.Interfaces;
using FoodWasteApp.DAL.Models;
using FoodWasteApp.DAL.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FoodWasteApp.BLL.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IGenericRepository<Review> _reviewRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ReviewService> _logger;

        public ReviewService(IGenericRepository<Review> reviewRepository, IMapper mapper, ILogger<ReviewService> logger)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddAsync(Review dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
            _logger.LogInformation("Adding new review: {ReviewDto}", json);
            var entity = _mapper.Map<Review>(dto);
            await _reviewRepository.AddAsync(entity);
            _logger.LogInformation("Review added successfully with ID: {ReviewId}", entity.ID);
        }

        public async Task DeleteAsync(int id)
        {
            var exits = await _reviewRepository.Exists(id);
            if (!exits)
            {
                _logger.LogWarning("Attempted to delete non-existing review with ID: {ReviewId}", id);
                return;
            }
            await _reviewRepository.DeleteAsync(id);
            _logger.LogInformation("Deleted review with ID: {ReviewId}", id);
        }

        public async Task<bool> Exists(int id)
        {
            var exists = await _reviewRepository.Exists(id);
            if (exists)
            {
                _logger.LogInformation("Review with ID: {ReviewId} exists", id);
            }
            else
            {
                _logger.LogInformation("Review with ID: {ReviewId} does not exist", id);
            }
            return exists;
        }

        public List<Review> GetAll()
        {
            var entities = _reviewRepository.GetAll().ToList();
            var dtos = _mapper.Map<List<Review>>(entities);

            var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
            _logger.LogInformation("Retrieved all reviews: {Reviews}", json);
            return dtos;
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            var entity = await _reviewRepository.GetByIdAsync(id);
            var dto = _mapper.Map<Review?>(entity);
            if (dto != null)
            {
                var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
                _logger.LogInformation("Retrieved review with ID: {ReviewId}: {Review}", id, json);
            }
            else
            {
                _logger.LogWarning("Review with ID: {ReviewId} not found", id);
            }
            return dto;
        }

        public async Task UpdateAsync(Review dto)
        {
            var entity = await _reviewRepository.GetByIdAsync(dto.ID);

            await _reviewRepository.UpdateAsync(entity!);
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
            _logger.LogInformation("Updated review with ID: {ReviewId}: {ReviewDto}", dto.ID, json);    
        }
    }
}
