using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driver.Entities.DbSet;

namespace Driver.DataService.Repositories.Interfaces
{
    public interface IAchievementRepository : IGenericRepository<Achievement>
    {
        Task<Achievement> GetDriverAchievementAsync (Guid driverId);
    }
}
