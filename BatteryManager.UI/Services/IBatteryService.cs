using BatteryManager.UI.DataAccess;

namespace BatteryManager.UI.Services
{
    public interface IBatteryService
    {
        Task<IList<Battery>> GetAll();
    }
}