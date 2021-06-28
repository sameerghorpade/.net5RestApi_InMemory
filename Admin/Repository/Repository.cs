using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Admin.Entities;
using Admin.InMemoryDb;
using Admin.Dtos;
using System.Linq;

namespace Admin.Repository
{
    public class Repository : IRepository
    {
        private InMemoryDatabase _db = null;

        public Repository()
        {
            _db = new InMemoryDatabase();
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await Task.FromResult(_db.users);
        }

        public async Task<User> GetUserByCredentialsAsync(string userName, string password)
        {
            return await Task.FromResult(
                _db.users
                .Where(x=>x.UserName == userName && x.Password == password)
                .SingleOrDefault());
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await Task.FromResult(
                _db.users.Where(x=>x.Email == email).SingleOrDefault()
            );
        }

        public async Task<User> GetUserByIdAsync(Guid Id)
        {
            return await Task.FromResult(
                _db.users.Where(x=>x.Id == Id).SingleOrDefault()
                );
            
        }
 
        public Task CreateUserAsync(User newUser)
        {
           _db.users.Add(newUser);
           return Task.CompletedTask;
        }

        public Task<bool> DeleteUserAsync(Guid Id)
        {
             var userToDelete = _db.users.SingleOrDefault(x=>x.Id == Id);
             if(userToDelete != null){
                _db.users.Remove(userToDelete);
                return Task.FromResult(true);
             }
             return Task.FromResult(false);
        }
        
        public Task UpdateUserAsync(User user)
        {
            var index = _db.users.FindIndex(x=>x.Id == user.Id);
            _db.users[index] = user;
            return Task.CompletedTask;
        } 

    }
}