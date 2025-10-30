using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRewardSystem.Domain.Entities.User;

namespace UserRewardSystem.Application.Interfaces
{
    // Contract for UserAccount repository
    public interface IUserAccountRepository
    {
        Task AddAsync(UserAccount account);
        Task<UserAccount> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<UserAccount>> GetAllAsync();
        Task UpdateAsync(UserAccount account);
    }
}
