using AutoMapper;
using BMS.BLL.Dtos;
using BMS.BLL.Services.Interfaces;
using BMS.DAL.Models;
using BMS.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IGenericRepository<Author> _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IGenericRepository<Author> authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public Task AddAsync(AuthorDto dto)
        {
            var entity = _mapper.Map<Author>(dto);
            return _authorRepository.AddAsync(entity);
        }

        public Task DeleteAsync(int id)
        {

            return _authorRepository.DeleteAsync(id);
        }

        public Task<bool> Exists(int id)
        {
            return _authorRepository.Exists(id);
        }

        public List<AuthorDto> GetAll()
        {
            var entities = _authorRepository.GetAll().ToList();
            return _mapper.Map<List<AuthorDto>>(entities);
        }

        public async Task<AuthorDto?> GetByIdAsync(int id)
        {
            var entity = await _authorRepository.GetByIdAsync(id);
            var dto = _mapper.Map<AuthorDto?>(entity);
            return dto;
        }

        public Task UpdateAsync(AuthorDto dto)
        {
            var entity = _mapper.Map<Author>(dto);
            return _authorRepository.UpdateAsync(entity);
        }
    }
}
