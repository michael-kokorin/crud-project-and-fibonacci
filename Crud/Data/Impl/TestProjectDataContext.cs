using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    internal sealed class TestProjectDataContext: DbContext, IDataContext
    {
        public DbSet<UserEntity> UserEntities { get; set; }

        public void Save()
        {
            SaveChanges();
        }
    }
}
