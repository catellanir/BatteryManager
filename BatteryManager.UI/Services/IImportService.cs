using BatteryManager.UI.Models;

namespace BatteryManager.UI.Services
{
    public interface IImportService
    {
        Task Import(BatteryData batteryData);
    }
}