using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    /// <summary>
    ///     Represents context for database storage
    /// </summary>
    public interface IDataContext
    {
        DbSet<UserEntity> UserEntities { get; set; }

        void Save();
    }
}
