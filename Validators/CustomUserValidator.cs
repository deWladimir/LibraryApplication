using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApplication.Models;
using Microsoft.AspNetCore.Identity;

namespace LibraryApplication.Validators
{
    public class CustomUserValidator : IUserValidator<User>
    {
        public interface IUserValidator<TUser> where TUser : class
        {
            Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user);
        }

        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            List<IdentityError> errors = new List<IdentityError>();

            if (!(user.Email.ToLower().EndsWith("@gmail.com")|| user.Email.ToLower().EndsWith("@knu.ua")))
            {
                errors.Add(new IdentityError
                {
                    Description = "Будь ласка, введіть пошту домену @gmail.com або домену @knu.ua"
                });
            }
            return Task.FromResult(errors.Count == 0 ?
                IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}
