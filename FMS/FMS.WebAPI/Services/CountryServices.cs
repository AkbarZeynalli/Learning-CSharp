using AutoMapper;
using FMS.DAL.Models;
using FMS.DAL.Repository;
using FMS.WebAPI.Dtos;
using FMS.WebAPI.Services.Interfaces;

namespace FMS.WebAPI.Services
{
    public class CountryServices : ICountryServices
    {
        private readonly IGenericRepository<Country> _countryRepository;
        private readonly IMapper _mapper;
        public CountryServices(IGenericRepository<Country> countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public Task AddAsync(CountryDto dto)
        {
            var country = _mapper.Map<Country>(dto);
            return _countryRepository.AddAsync(country);
        }
        public Task DeleteAsync(int id)
        {
            return _countryRepository.DeleteAsync(id);
        }

        public Task<bool> Exists(int id)
        {
            return _countryRepository.Exists(id);
        }

        public List<CountryDto> GetAll()
        {
            var countries = _countryRepository.GetAll().ToList();
            return _mapper.Map<List<CountryDto>>(countries);
        }

        public async Task<CountryDto?> GetByIdAsync(int id)
        {
            var country = await _countryRepository.GetByIdAsync(id);
            return _mapper.Map<CountryDto?>(country);
        }
        public async Task UpdateAsync(CountryDto dto)
        {
            var country = _mapper.Map<Country>(dto);
            await _countryRepository.UpdateAsync(country);
        }




    }
}
