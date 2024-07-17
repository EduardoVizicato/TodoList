using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Models;
using TodoList.Domain.Models.Requests;
using TodoList.Domain.Repositories.Interfaces;
using TodoList.Infrastructure.Data;

namespace TodoList.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDataContext _context;
        public UserRepository(ApplicationDataContext context) 
        {
            _context = context;
        }
        public async Task<UserModelRequest> AddAsync(UserModelRequest request)
        {
            var user = new UserModel()
            {
                Name = request.Name,
                Password = request.Password,
                IsActive = request.IsActive,
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<bool?> DeleteAsync(Guid id)
        {
            var userToDelete = await GetByIdAsync(id);
            if (userToDelete == null)
            {
                return null;
            }
            _context.Users.Remove(userToDelete);
            return await _context.SaveChangesAsync()> 0;
        }

        public async Task<bool?> Desactive(Guid id)
        {
            var userToDesactive = await GetByIdAsync(id);
            userToDesactive.IsActive = false;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<UserModel>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserModel> GetByIdAsync(Guid id)
        {
            return await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool?> UpdateAsync(Guid id, UserModelRequest request)
        {
            var userToUpdate = await GetByIdAsync(id);
            if (userToUpdate == null)
            {
                return null;
            }
            userToUpdate.Name = request.Name;
            userToUpdate.Password = request.Password;

            _context.Users.Update(userToUpdate);
            return await _context.SaveChangesAsync() > 0;
            
        }
    }
}
