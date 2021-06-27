using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Admin.Entities;
using db = Admin.InMemoryDb.InMemoryDb;
using Admin.Dtos;

namespace Admin.Repository
{
    public class Repository : IRepository
    {
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await Task.FromResult(db.GetUsers());
        }

        public async Task<User> GetUserByCredentialsAsync(LoginCredentialDto loginCreds)
        {
            return await Task.FromResult(db.GetUserByCredentials(loginCreds.UserName,loginCreds.Password));
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await Task.FromResult(db.GetUserByEmail(email));
        }

        public async Task<User> GetUserByIdAsync(Guid Id)
        {
            return await Task.FromResult(db.GetUser(Id));
            
        }
 
    }
}