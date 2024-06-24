using BatteryManager.UI.DataAccess;
using BatteryManager.UI.Models;
using Microsoft.EntityFrameworkCore;

namespace BatteryManager.UI.Services
{
    public class ImportService(BatteryManagerContext context) : IImportService
    {
        public async Task Import(BatteryData batteryData)
        {
            var battery = await TryGetBattery(batteryData.Serial);
            if (battery is null)
            {
                var batteryType = await TryGetBatteryType(batteryData.ProductName);
                if (batteryType is null)
                {
                    var batteryClass = await GetOrCreateBatteryClass(batteryData.CellGeneration);
                    batteryType = await CreateBatteryType(batteryData.ProductName, batteryClass, batteryData.Capacity, batteryData.Voltage);
                }
                var customer = await GetOrCreateCustomer(batteryData.Customer);
                var plant = await GetOrCreatePlant(batteryData.Plant, customer);
                await CreateBattery(batteryData.Serial, plant, batteryType);
            }
            await context.SaveChangesAsync();
        }

        private async Task<Battery> CreateBattery(string serial, Plant plant, BatteryType batteryType)
        {
            var battery = new Battery() { Serial = serial, Plant = plant, BatteryType = batteryType };
            await context.Batteries.AddAsync(battery);
            return battery;
        }

        private async Task<BatteryType> CreateBatteryType(string productName, BatteryClass batteryClass, int capacity, int voltage)
        {
            var batteryType = new BatteryType()
            {
                ProductName = productName,
                BatteryClass = batteryClass,
                Capacity = capacity,
                Voltage = voltage
            };
            await context.BatteryTypes.AddAsync(batteryType);
            return batteryType;
        }

        private async Task<BatteryClass> GetOrCreateBatteryClass(string cellGeneration)
        {
            var batteryClass = await context.BatteryClasses.SingleOrDefaultAsync(c => c.Name == cellGeneration);
            if (batteryClass == null)
            {
                batteryClass = new BatteryClass() { Name = cellGeneration };
                await context.BatteryClasses.AddAsync(batteryClass);
            }
            return batteryClass;
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

        private async Task<Battery?> TryGetBattery(string serial)
        {
            return await context.Batteries.SingleOrDefaultAsync(c => c.Serial == serial);
        }

        private async Task<BatteryType?> TryGetBatteryType(string productName)
        {
            return await context.BatteryTypes.SingleOrDefaultAsync(c => c.ProductName == productName);
        }
    }
}