using System;
using System.Collections.Generic;
using System.Linq;
using Business.Models;
using Common.Models;
using Data.Entities;
using Data.Repositories;

namespace Business.Services.Impl
{
    internal sealed class UserService: IUserService
    {
        private readonly IUserEntityRepository _repository;

        public UserService(IUserEntityRepository repository)
        {
            _repository = repository;
        }

        public OperationResult<int> Create(UserCreateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            if (string.IsNullOrWhiteSpace(dto.FirstName))
            {
                return new OperationResult<int>
                {
                    Success = false,
                    Message = "First name is empty"
                };
            }

            if (dto.FirstName.Length > 200)
            {
                return new OperationResult<int>
                {
                    Success = false,
                    Message = "First name is too long"
                };
            }

            if (string.IsNullOrWhiteSpace(dto.LastName))
            {
                return new OperationResult<int>
                {
                    Success = false,
                    Message = "Last name is empty"
                };
            }

            if (dto.LastName.Length > 200)
            {
                return new OperationResult<int>
                {
                    Success = false,
                    Message = "Last name is too long"
                };
            }

            var entity = new UserEntity
            {
                Created = DateTime.UtcNow,
                BirthDate = dto.BirthDate,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                IsActive = true
            };

            var id = _repository.Create(entity);
            return new OperationResult<int>
            {
                Success = true,
                Data = id
            };
        }

        public OperationResult Update(UserUpdateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            if (string.IsNullOrWhiteSpace(dto.FirstName))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "First name is empty"
                };
            }

            if (dto.FirstName.Length > 200)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "First name is too long"
                };
            }

            if (string.IsNullOrWhiteSpace(dto.LastName))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "Last name is empty"
                };
            }

            if (dto.LastName.Length > 200)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "Last name is too long"
                };
            }

            var entity = _repository.GetById(dto.Id);
            if (entity == null)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "User is not found"
                };
            }

            entity.BirthDate = dto.BirthDate;
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;

            _repository.Update(entity);
            return new OperationResult
            {
                Success = true
            };
        }

        public OperationResult Delete(UserDeleteDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var entity = _repository.GetById(dto.Id);
            if (entity == null)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "User is not found"
                };
            }

            _repository.Delete(entity);
            return new OperationResult
            {
                Success = true
            };
        }

        public IEnumerable<UserModel> Get(int skip, int take)
        {
            return _repository.GetActiveQuery().Skip(skip).Take(take).Select(_ => new UserModel
            {
                Id = _.Id,
                Created = _.Created,
                BirthDate = _.BirthDate,
                FirstName = _.FirstName,
                LastName = _.LastName
            }).ToArray();
        }

        public OperationResult<UserModel> GetById(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                return new OperationResult<UserModel>
                {
                    Success = false,
                    Message = "User is not found"
                };
            }

            return new OperationResult<UserModel>
            {
                Success = true,
                Data = new UserModel
                {
                    Created = entity.Created,
                    Id = entity.Id,
                    BirthDate = entity.BirthDate,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName
                }
            };
        }
    }
}
