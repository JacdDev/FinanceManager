﻿using FinanceManager.Domain.UserAggregate;

namespace FinanceManager.Application.Common.Interfaces
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(User user);
    }
}
