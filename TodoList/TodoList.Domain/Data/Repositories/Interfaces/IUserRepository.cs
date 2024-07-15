using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Data.Models;
using TodoList.Domain.Data.Models.Request;

namespace TodoList.Domain.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> GetById(Guid id);
        Task<UserRequest> Add(UserRequest userRequest);
        Task<bool?> Delete(Guid id);
        Task<bool?> Update(Guid id, UserRequest userRequest);
        Task<bool?> Desactive (Guid id, UserRequest userRequest);
    }
}
