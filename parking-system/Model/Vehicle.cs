using System.ComponentModel.Design;
using parking_system.utils;

namespace parking_system.Model;

public class Vehicle
{
    public string licensePlate { get; set; }
    public VehicleType? type { get; set; }
    public DateTime checkIn { get; set; }
    public string color { get; set; }

    public Vehicle(string licensePlate, VehicleType type, string color ,DateTime checkIn)
    {
        this.licensePlate = licensePlate;
        this.type = type;
        this.color = color;
        this.checkIn = checkIn;
    }

    public Vehicle()
    {
        
    }
    
    

    public override string ToString() => $"{licensePlate}-{type}-{color}-{checkIn}";
}