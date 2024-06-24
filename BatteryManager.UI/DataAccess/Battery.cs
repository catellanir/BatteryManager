namespace BatteryManager.UI.DataAccess
{
    public class Battery
    {
        public BatteryType BatteryType { get; set; }
        public int Id { get; set; }
        public Plant Plant { get; set; }
        public string Serial { get; set; }
    }
}