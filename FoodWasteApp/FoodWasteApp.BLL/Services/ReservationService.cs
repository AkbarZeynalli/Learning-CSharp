using AutoMapper;
using FoodWasteApp.BLL.Dtos;
using FoodWasteApp.BLL.Services.Interfaces;
using FoodWasteApp.DAL.Models;
using FoodWasteApp.DAL.Repository;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace FoodWasteApp.BLL.Services
{
    public class ReservationService :IReservationService
    {
        private readonly IGenericRepository<Reservation> _reservationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ReservationService> _logger;

        public ReservationService(IGenericRepository<Reservation> reservationRepository, IMapper mapper, ILogger<ReservationService> logger)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddAsync(ReservationDto dto)
        {
            var json = JsonSerializer.Serialize(dto,new JsonSerializerOptions { WriteIndented = true});
            _logger.LogInformation("Adding new reservation: {ReservationDto}", json);
            var entity = _mapper.Map<Reservation>(dto);
            await _reservationRepository.AddAsync(entity);
            _logger.LogInformation("Reservation added successfully with ID: {ReservationId}", entity.ID);
        }

        public async Task DeleteAsync(int id)
        {
            var exists = await _reservationRepository.Exists(id);
            if (!exists)
            {
                _logger.LogWarning("Attempted to delete non-existing reservation with ID: {ReservationId}", id);
                return;
            }
            await _reservationRepository.DeleteAsync(id);
            _logger.LogInformation("Deleted reservation with ID: {ReservationId}", id);
        }

        public async Task<bool> Exists(int id)
        {
            var exists = await _reservationRepository.Exists(id);
            if (exists)
            {
                _logger.LogInformation("Reservation with ID: {ReservationId} exists", id);
            }
            else
            {
                _logger.LogInformation("Reservation with ID: {ReservationId} does not exist", id);
            }
            return exists;
        }

        public List<ReservationDto> GetAll()
        {
            var entities = _reservationRepository.GetAll().ToList();
            var dtos = _mapper.Map<List<ReservationDto>>(entities);

            var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
            _logger.LogInformation("Retrieved all reservations: {Reservations}", json);
            return dtos;
        }

        public async Task<ReservationDto?> GetByIdAsync(int id)
        {
            var entity = await _reservationRepository.GetByIdAsync(id);
            var dto = _mapper.Map<ReservationDto?>(entity);
            if (dto != null)
            {
                var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
                _logger.LogInformation("Retrieved reservation with ID: {ReservationId}: {ReservationDto}", id, json);
            }
            else
            {
                _logger.LogWarning("Reservation with ID: {ReservationId} not found", id);
            }
            return dto;
        }
        public async Task UpdateAsync(ReservationDto dto)
        {
            var entity = _mapper.Map<Reservation>(dto);

            await _reservationRepository.UpdateAsync(entity);
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
            _logger.LogInformation("Updated reservation with ID: {ReservationId}: {ReservationDto}", dto.Id, json);
        }
    }
}
