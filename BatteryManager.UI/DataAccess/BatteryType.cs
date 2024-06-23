namespace BatteryManager.UI.DataAccess
{
    public class BatteryType
    {
        public int Id{ get; set; }
        public string ProductName{ get; set; }
        public BatteryClass BatteryClass{ get; set; }
        public int Capacity { get; set; }
        public int Voltage { get; set; }
    }
}
