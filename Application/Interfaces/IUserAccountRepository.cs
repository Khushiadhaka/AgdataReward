using System;
using System.Collections.Generic;
using Domain.Domain.Entities.User;

namespace Application.Interfaces
{
    // Abstraction for user account repository
    public interface IUserAccountRepository
    {
        void Add(UserAccount account);
        UserAccount GetByUserId(Guid userId);
        void Update(UserAccount account);
        IEnumerable<UserAccount> GetAll();
    }
}

