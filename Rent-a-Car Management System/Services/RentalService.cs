using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rent_a_Car_Management_System.Dots;
using Rent_a_Car_Management_System.Models;
using Rent_a_Car_Management_System.Repository;
using Rent_a_Car_Management_System.Services.Interfaces;

namespace Rent_a_Car_Management_System.Services
{
    public class RentalService : IRentalService
    {
        private readonly IGenericRepository<Rental> _rentalRepository;
        private readonly IMapper _mapper;

        public RentalService(IGenericRepository<Rental> rentalRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<List<RentalDto>> GetAllAsync()
        {
            var rentals = await _rentalRepository.GetAll().ToListAsync();

            var dtos = _mapper.Map<List<RentalDto>>(rentals);
            return dtos;
        }

        public async Task<RentalDto> GetByIdAsync(int id)
        {
            var rental = await _rentalRepository.GetByIdAsync(id);
            if (rental == null)
                return null;

            var dto = _mapper.Map<RentalDto>(rental);
            return dto;
        }

        public async Task AddAsync(RentalDto dto)
        {
            var entity = _mapper.Map<Rental>(dto);

            await _rentalRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(int id, RentalDto dto)
        {
            var rental = await _rentalRepository.GetByIdAsync(id);
            if (rental == null) return;


            var entity = _mapper.Map<Rental>(dto);
            entity.Id = id;

            await _rentalRepository.UpdateAsync(rental);
        }

        public async Task DeleteAsync(int id)
        {
            var brand = await _rentalRepository.GetByIdAsync(id);
            if (brand == null) return;

            await _rentalRepository.DeleteAsync(id);
        }
    }
}
