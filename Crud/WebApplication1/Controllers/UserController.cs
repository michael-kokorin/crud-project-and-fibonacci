using System.Collections.Generic;
using Business.Models;
using Business.Services;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Requests;

namespace WebApplication1.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<UserModel> Get(int skip, int take)
        {
            return _userService.Get(skip, take);
        }

        [HttpGet("{id}")]
        public OperationResult<UserModel> Get(int id)
        {
            return _userService.GetById(id);
        }

        [HttpPost]
        public OperationResult<int> Post([FromBody] UserCreateRequest dto)
        {
            return _userService.Create(new UserCreateDto
            {
                BirthDate = dto.BirthDate,
                FirstName = dto.FirstName,
                LastName = dto.LastName
            });
        }

        [HttpPut("{id}")]
        public OperationResult Put(int id, [FromBody] UserUpdateRequest value)
        {
            return _userService.Update(new UserUpdateDto
            {
                Id = id,
                BirthDate = value.BirthDate,
                FirstName = value.FirstName,
                LastName = value.LastName
            });
        }

        [HttpDelete("{id}")]
        public OperationResult Delete(int id)
        {
            return _userService.Delete(new UserDeleteDto
            {
                Id = id
            });
        }
    }
}
