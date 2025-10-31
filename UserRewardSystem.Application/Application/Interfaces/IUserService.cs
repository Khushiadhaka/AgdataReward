using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRewardSystem.Domain.Entities.User;
using UserRewardSystem.Domain.Enums;

namespace UserRewardSystem.Application.Interfaces
{
    // Service interface for user-related operations
    public interface IUserService
    {
        Task<User> CreateUserAsync(string name, string email, string employeeId, UserRole role);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task AddPointsAsync(Guid userId, int points);
        Task RedeemPointsAsync(Guid userId, int points);
    }
}
