﻿using LibIdentity.Domain.UserAgg;
using Microsoft.AspNetCore.Identity;

namespace LibIdentity.Infrastructure.Repositories
{
    //Interface Phone Book Password Validator
    public class ILIPasswordValidator : IPasswordValidator<UserIdentity>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<UserIdentity> manager, UserIdentity user, string password)
        {
            List<IdentityError> errors = new();
            if (user.UserName == password || user.UserName.Contains(password))
            {
                errors.Add(new IdentityError
                {
                    Code = "Password",
                    Description = "Password is equal to username"
                });
            }
            return Task.FromResult(errors.Any() ?
                IdentityResult.Failed(errors.ToArray()) :
                IdentityResult.Success);
        }
    }
}
