using Core.Entities;
using Core.Interfaces;
using Core.Response;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CategoryService(IGenericRepository<Category> _repository) : ICategoryService
    {
        public async Task<Response<List<Category>>> GetAllAsync()
        {
            var categories = await _repository.GetAll().ToListAsync();
            return Response<List<Category>>.Success(categories, 200);
        }

        public async Task<Response<Category>> GetByIdAsync(Guid id)
        {
            var category = await _repository.GetByIdAsync(id);

            if (category == null)
                return Response<Category>.Fail("Kategori bulunamadı", 404);

            return Response<Category>.Success(category, 200);
        }

        public async Task<Response<Category>> CreateAsync(Category entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return Response<Category>.Success(entity, 201);
        }

        public async Task<Response<bool>> Update(Category entity)
        {
            _repository.Update(entity);
            await _repository.SaveAsync();
            return Response<bool>.Success(204);
        }

        public async Task<Response<bool>> Remove(Guid id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null) return Response<bool>.Fail("Kategori bulunamadı", 404);

            _repository.Remove(category);
            await _repository.SaveAsync();
            return Response<bool>.Success(204);
        }
    }
}
