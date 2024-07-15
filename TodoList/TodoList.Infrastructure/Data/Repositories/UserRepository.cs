using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Data.Models;
using TodoList.Domain.Data.Models.Request;
using TodoList.Domain.Data.Repositories.Interfaces;

namespace TodoList.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDataContext _context;
        public UserRepository(ApplicationDataContext context) 
        {
            _context = context;
        }

        public async Task<UserRequest> Add(UserRequest userRequest)
        {
            var user = new User()
            {
                Name = userRequest.Name,
                Password = userRequest.Password,
                IsActive = userRequest.IsActive,
            };
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            var addedUserRequest = new UserRequest()
            {
                Name = user.Name,
                Password = user.Password,
                IsActive = user.IsActive,
            };
            
            return addedUserRequest;
        }

        public async Task<bool?> Delete(Guid id)
        {
            var userToDelete = await GetById(id);
            if (userToDelete == null)
            {
                return false; 
            }

            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> Desactive(Guid id, UserRequest userRequest)
        {
            var userToUpdate = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            userToUpdate.IsActive = false;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.Where(x =>  x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool?> Update(Guid id, UserRequest userRequest)
        {
            var userToUpdate = await _context.Users.FirstOrDefaultAsync(x=>x.Id == id);
            if (userToUpdate == null)
            {
                return null;
            }
            userToUpdate.Name = userRequest.Name;
            userToUpdate.Password = userRequest.Password;
            
            _context.Users.Update(userToUpdate);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
