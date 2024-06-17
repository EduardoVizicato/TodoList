using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Data.Models;

namespace TodoList.Domain.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> GetById(Guid id);
        Task<User> Add(User user);
        Task<bool> Delete(Guid id);
        Task<bool> Update(Guid id, User user);
    }
}
