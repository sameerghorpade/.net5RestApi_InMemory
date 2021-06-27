using System;
using Microsoft.AspNetCore.Mvc;
using Admin.Repository;
using System.Linq;
using System.Collections.Generic;
using Admin.Dtos;
using System.Threading.Tasks;
using Admin.Helper;

namespace Admin.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController: ControllerBase
    {
        private readonly IRepository _repository;
        public UserController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersAsync()
        {
            try
            {
                var users = (await _repository.GetAllUsersAsync()).Select(x=> x.AsUserDto());
                return  Ok(users);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<UserDto>> GetUsersByIdAsync(Guid Id)
        {
            try
            {
                //this will return notfound since each time the in mem users list is fetched it will have new guid
                var user = await _repository.GetUserByIdAsync(Id);
                if(user is null) return NotFound();
                return  user.AsUserDto();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<UserDto>> GetUsersByEmailAsync(string email)
        {
            try
            {
                var user = await _repository.GetUserByEmailAsync(email);
                if(user is null) return NotFound();
                return  user.AsUserDto();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> GetUsersByCredentialsAsync(LoginCredentialDto loginCredentials)
        {
            try
            {
                var user = await _repository.GetUserByCredentialsAsync(loginCredentials);
                if(user is null) return NotFound();
                return  user.AsUserDto();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }

}