using BatteryManager.UI.DataAccess;

namespace BatteryManager.UI.Services
{
    public interface ICustomerService
    {
        Task AddCustomer(string name);
        Task<IList<Customer>> GetAll();
        Task<Customer?> GetByName(string name);
    }
}