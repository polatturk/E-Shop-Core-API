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
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;

        public UserService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Response<List<User>>> GetAllAsync()
        {
            var users = await _userRepository.GetAll().ToListAsync();
            return Response<List<User>>.Success(users, 200);
        }

        public async Task<Response<User>> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return Response<User>.Fail("Kullanıcı bulunamadı", 404);

            return Response<User>.Success(user, 200);
        }

        public async Task<Response<User>> CreateAsync(User user)
        {
            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();
            return Response<User>.Success(user, 201);
        }

        public async Task<Response<bool>> Update(User user)
        {
            _userRepository.Update(user);
            await _userRepository.SaveAsync();
            return Response<bool>.Success(204); // No Content
        }

        public async Task<Response<bool>> Remove(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return Response<bool>.Fail("Kullanıcı bulunamadı", 404);

            _userRepository.Remove(user);
            await _userRepository.SaveAsync();
            return Response<bool>.Success(204);
        }
    }
}
