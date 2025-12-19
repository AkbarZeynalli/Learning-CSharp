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
    public class BookService : IBookService
    {
        private readonly IGenericRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IGenericRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public Task AddAsync(BookDto dto)
        {
            var entity = _mapper.Map<Book>(dto);
            return _bookRepository.AddAsync(entity);
        }

        public Task DeleteAsync(int id)
        {

            return _bookRepository.DeleteAsync(id);
        }

        public Task<bool> Exists(int id)
        {
            return _bookRepository.Exists(id);
        }

        public List<BookDto> GetAll()
        {
            var entities = _bookRepository.GetAll().ToList();
            return _mapper.Map<List<BookDto>>(entities);
        }

        public async Task<BookDto?> GetByIdAsync(int id)
        {
            var entity = await _bookRepository.GetByIdAsync(id);
            var dto = _mapper.Map<BookDto?>(entity);
            return dto;
        }

        public Task UpdateAsync(BookDto dto)
        {
            var entity = _mapper.Map<Book>(dto);
            return _bookRepository.UpdateAsync(entity);
        }
    }
}
