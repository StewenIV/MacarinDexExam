using System.Drawing;

namespace Buildings.Domain.Models;

public class Sensor
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? UrlPhoto { get; set; }
    public int ChargeLevel { get; set; }
    public Location Location { get; set; }
    public double Temperature { get; set; }
    public double MaxTemperature { get; set; }
    public double MinTemperature { get; set; }
    public Building Building { get; set; }
    public Guid IdBuilding { get; set; }
    public List<Notification> Notifications { get; set; }
    
    public event Action<string> OnLowBattery;
    public event Action<string> OnOutOfRange;
    
    public void UpdateReadings(double newTemperature, int newChargeLevel)
    {
        Temperature = newTemperature;
        ChargeLevel = newChargeLevel;
        
        if (Temperature > MaxTemperature || Temperature < MinTemperature)
        {
            OnOutOfRange?.Invoke($"Температура {Temperature} выходит за допустимые пределы.");
        }
        
        if (ChargeLevel < 10)
        {
            OnLowBattery?.Invoke("Уровень заряда датчика ниже 10%");
        }
    }
}
public class Location
{
    public int X { get; set; }
    public int Y { get; set; }
}
