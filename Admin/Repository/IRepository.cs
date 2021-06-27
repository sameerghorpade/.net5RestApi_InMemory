using System;
using Admin.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Admin.Dtos;

namespace Admin.Repository
{
    public interface  IRepository
    {
        //Get Users
        Task<IEnumerable<User>> GetAllUsersAsync();

        //Get UserById
        Task<User> GetUserByIdAsync(Guid Id);

        //Get User By Email
        Task<User> GetUserByEmailAsync(string Id);

        //Validate User
        Task<User> GetUserByCredentialsAsync(LoginCredentialDto loginCreds);

    }
}