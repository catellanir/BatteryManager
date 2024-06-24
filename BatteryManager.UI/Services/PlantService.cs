using BatteryManager.UI.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BatteryManager.UI.Services
{
    public class PlantService(BatteryManagerContext context) : IPlantService
    {
        public async Task AddPlant(string name, int customerId)
        {
            var customer = await context.Customers.SingleAsync(c => c.Id == customerId);
            var plant = new Plant()
            {
                Name = name,
                Customer = customer
            };
            await context.Plants.AddAsync(plant);
        }

        public async Task<IList<Plant>> GetAll()
        {
            return await context.Plants.Include(p => p.Customer).ToListAsync();
        }

        public async Task<Plant?> GetByName(string name)
        {
            return await context.Plants.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}