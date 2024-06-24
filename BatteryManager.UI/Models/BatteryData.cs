namespace BatteryManager.UI.Models
{
    public class BatteryData
    {
        public int Capacity { get; internal set; }
        public string CellGeneration { get; internal set; }
        public string Customer { get; set; }
        public string Plant { get; set; }
        public string ProductName { get; internal set; }
        public string Serial { get; set; }
        public int Voltage { get; internal set; }
    }
}