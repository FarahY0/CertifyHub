using CertifyHub.Core.Data;
using CertifyHub.Core.DTO;
using CertifyHub.Core.Service;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CertifyHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<List<User>> GetAllUsers()
        {
            return await _usersService.GetAllUsers();
        }

        [HttpPost]
        [Route("CreateUser")]
        public void CreateUser(User user)
        {
            _usersService.CreateUser(user);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public void UpdateUser(User user)
        {
            _usersService.UpdateUser(user);
        }

        [HttpGet]
        [Route("GetUserById/{id}")]

        public async Task<User> GetUserById(int id)
        {
            return await _usersService.GetUserById(id);
        }


        [HttpPut]
        [Route("UpdateUserPhone/{id}/{newPhoneNumber}")]
        public void UpdateUserPhone(int id, string newPhoneNumber)
        {
            _usersService.UpdateUserPhone(id, newPhoneNumber);
        }


        [HttpPut]
        [Route("UpdateUserImage/{id}/{newImagePath}")]
        public void UpdateUserImage(int id, string newImagePath)
        {
            _usersService.UpdateUserImage(id, newImagePath);
        }


        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public void DeleteUser(int id)
        {
            _usersService.DeleteUser(id);
        }

        [HttpPut]
        [Route("UpdateUserIsActive/{id}/{isActive}")]
        public void UpdateUserIsActive(int id,  int isActive)
        {
            _usersService.UpdateUserIsActive(id, isActive);
        }











    }
}
