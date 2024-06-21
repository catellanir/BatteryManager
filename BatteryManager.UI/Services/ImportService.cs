using BatteryManager.UI.DataAccess;
using BatteryManager.UI.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace BatteryManager.UI.Services
{
    public class ImportService(BatteryManagerContext context) : IImportService
    {


        public async Task Import(BatteryData batteryData)
        {
            var customer = await GetOrCreateCustomer(batteryData.Customer);
            var plant = await GetOrCreatePlant(batteryData.Plant, customer);
            _ = await GetOrCreateBattery(batteryData.Serial, plant);
            await context.SaveChangesAsync();
        }

        private async Task<Battery> GetOrCreateBattery(string serial, Plant plant)
        {
            var battery = await context.Batteries.SingleOrDefaultAsync(c => c.Serial == serial);
            if (battery == null)
            {
                battery = new Battery() { Serial = serial, Plant = plant };
                await context.Batteries.AddAsync(battery);
            }
            return battery;
        }

        private async Task<Plant> GetOrCreatePlant(string plantName, Customer customer)
        {
            var plant = await context.Plants.SingleOrDefaultAsync(c => c.Name == plantName && customer.Id == c.Customer.Id);
            if (plant is null)
            {
                plant = new Plant() { Name = plantName, Customer = customer };
                await context.Plants.AddAsync(plant);
            }

            return plant;
        }

        private async Task<Customer> GetOrCreateCustomer(string customerName)
        {
            var customer = await context.Customers.SingleOrDefaultAsync(c => c.Name == customerName);
            if (customer is null)
            {
                customer = new Customer() { Name = customerName };
                await context.AddAsync(customer);
            }
            return customer;
        }
    }
}
