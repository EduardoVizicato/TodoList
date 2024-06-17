using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Data.Models;
using TodoList.Domain.Data.Repositories.Interfaces;

namespace TodoList.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> Add(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Guid id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
