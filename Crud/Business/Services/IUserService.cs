using System.Collections.Generic;
using Business.Models;
using Common.Models;

namespace Business.Services
{
    public interface IUserService
    {
        OperationResult<int> Create(UserCreateDto dto);

        OperationResult Update(UserUpdateDto dto);

        OperationResult Delete(UserDeleteDto dto);

        IEnumerable<UserModel> Get(int skip, int take);

        OperationResult<UserModel> GetById(int id);
    }
}
