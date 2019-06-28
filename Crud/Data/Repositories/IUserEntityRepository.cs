using System.Linq;
using Data.Entities;

namespace Data.Repositories
{
    public interface IUserEntityRepository
    {
        int Create(UserEntity entity);

        void Update(UserEntity entity);

        void Delete(UserEntity entity);

        IQueryable<UserEntity> GetAllQuery();

        IQueryable<UserEntity> GetActiveQuery();

        UserEntity GetById(int id);
    }
}
