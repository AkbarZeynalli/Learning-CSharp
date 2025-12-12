using AİRBNB.BLL.Dtos;
using AİRBNB.BLL.Services.Interfaces;
using AİRBNB.DAL.Models;
using AİRBNB.DAL.Repositroy;
using AutoMapper;

namespace AİRBNB.BLL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IGenericRepository<Booking> _bookingRepository;
        private readonly IMapper _mapper;

        public BookingService(IGenericRepository<Booking> bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public Task AddAsync(BookingDto dto)
        {
            var entity = _mapper.Map<Booking>(dto);
            return _bookingRepository.AddAsync(entity);
        }

        public Task DeleteAsync(int id)
        {

            return _bookingRepository.DeleteAsync(id);
        }

        public Task<bool> Exists(int id)
        {
            return _bookingRepository.Exists(id);
        }

        public List<BookingDto> GetAll()
        {
            var entities = _bookingRepository.GetAll().ToList();
            return _mapper.Map<List<BookingDto>>(entities);
        }

        public async Task<BookingDto?> GetByIdAsync(int id)
        {
            var entity = await _bookingRepository.GetByIdAsync(id);
            var dto = _mapper.Map<BookingDto?>(entity);
            return dto;
        }

        public Task UpdateAsync(BookingDto dto)
        {
            var entity = _mapper.Map<Booking>(dto);
            return _bookingRepository.UpdateAsync(entity);
        }
    }
}