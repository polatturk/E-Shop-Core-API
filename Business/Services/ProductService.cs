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
    public class ProductService(IGenericRepository<Product> productRepository) : IProductService
    {
        public async Task<Response<List<Product>>> GetAllAsync()
        {
            var products = await productRepository.GetAll().ToListAsync();
            return Response<List<Product>>.Success(products, 200);
        }

        public async Task<Response<Product>> GetByIdAsync(Guid id)
        {
            var product = await productRepository.GetByIdAsync(id);
            return product == null
                ? Response<Product>.Fail("Ürün bulunamadı", 404)
                : Response<Product>.Success(product, 200);
        }

        public async Task<Response<Product>> CreateAsync(Product product)
        {
            await productRepository.AddAsync(product);
            await productRepository.SaveAsync();
            return Response<Product>.Success(product, 201);
        }

        public async Task<Response<bool>> Update(Product product)
        {
            productRepository.Update(product);
            await productRepository.SaveAsync();
            return Response<bool>.Success(204);
        }

        public async Task<Response<bool>> Remove(Guid id)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product == null) return Response<bool>.Fail("Ürün bulunamadı", 404);
            productRepository.Remove(product);
            await productRepository.SaveAsync();
            return Response<bool>.Success(204);
        }
    }
}
