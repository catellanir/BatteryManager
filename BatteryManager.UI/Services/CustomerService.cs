using BatteryManager.UI.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BatteryManager.UI.Services
{
    public class CustomerService(BatteryManagerContext context) : ICustomerService
    {
        public async Task AddCustomer(string name)
        {
            var customer = new Customer() { Name = name };
            await context.Customers.AddAsync(customer);
        }

        public async Task<IList<Customer>> GetAll()
        {
            return await context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetByName(string name)
        {
            return await context.Customers.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}