using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Models;
using TodoList.Domain.Models.Requests;

namespace TodoList.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllAsync();
        Task<UserModel> GetByIdAsync(Guid id);
        Task<UserModelRequest> AddAsync(UserModelRequest request);
        Task<bool?> UpdateAsync(Guid id, UserModelRequest request);
        Task<bool?> DeleteAsync(Guid id);
        Task<bool?> Desactive(Guid id);

    }
}
