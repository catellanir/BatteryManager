using BatteryManager.UI.DataAccess;

namespace BatteryManager.UI.Services
{
    public interface IPlantService
    {
        Task AddPlant(string name, int customerId);

        Task<IList<Plant>> GetAll();

        Task<Plant?> GetByName(string name);
    }
}