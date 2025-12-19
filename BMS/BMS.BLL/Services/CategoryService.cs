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
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public Task AddAsync(CategoryDto dto)
        {
            var entity = _mapper.Map<Category>(dto);
            return _categoryRepository.AddAsync(entity);
        }

        public Task DeleteAsync(int id)
        {

            return _categoryRepository.DeleteAsync(id);
        }

        public Task<bool> Exists(int id)
        {
            return _categoryRepository.Exists(id);
        }

        public List<CategoryDto> GetAll()
        {
            var entities = _categoryRepository.GetAll().ToList();
            return _mapper.Map<List<CategoryDto>>(entities);
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var entity = await _categoryRepository.GetByIdAsync(id);
            var dto = _mapper.Map<CategoryDto?>(entity);
            return dto;
        }

        public Task UpdateAsync(CategoryDto dto)
        {
            var entity = _mapper.Map<Category>(dto);
            return _categoryRepository.UpdateAsync(entity);
        }
    }
}
