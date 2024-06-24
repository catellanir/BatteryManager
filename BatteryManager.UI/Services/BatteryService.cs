using BatteryManager.UI.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BatteryManager.UI.Services
{
    public class BatteryService(BatteryManagerContext context) : IBatteryService
    {
        public async Task<IList<Battery>> GetAll()
        {
            return await context.Batteries
                .AsNoTracking()
                .Include(x => x.Plant)
                .ThenInclude(x => x.Customer)
                .OrderBy(x => x.Plant.Name)
                .Take(100)
                .ToListAsync();
        }
    }
}