namespace BatteryManager.UI.DataAccess
{
    public class Battery
    {
        public int Id { get; set; } 
        public string Serial {  get; set; }
        public Plant Plant { get; set; }   
        public BatteryType BatteryType { get; set; }
    }
}
