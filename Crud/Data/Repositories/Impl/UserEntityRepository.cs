using System.Linq;
using Data.Entities;

namespace Data.Repositories.Impl
{
    internal sealed class UserEntityRepository: IUserEntityRepository
    {
        private readonly IDataContext _context;

        public UserEntityRepository(IDataContext context)
        {
            _context = context;
        }

        public int Create(UserEntity entity)
        {
            _context.UserEntities.Add(entity);
            _context.Save();
            return entity.Id;
        }

        public void Update(UserEntity entity)
        {
            _context.UserEntities.Update(entity);
            _context.Save();
        }

        public void Delete(UserEntity entity)
        {
            entity.IsActive = false;
            _context.Save();
        }

        public IQueryable<UserEntity> GetAllQuery()
        {
            return _context.UserEntities;
        }

        public IQueryable<UserEntity> GetActiveQuery()
        {
            return _context.UserEntities.Where(_ => _.IsActive);
        }

        public UserEntity GetById(int id)
        {
            return _context.UserEntities.FirstOrDefault(_ => _.Id == id);
        }
    }
}
