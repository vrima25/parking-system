using System.Runtime.InteropServices;
using parking_system.Model;
using parking_system.utils;

namespace parking_system.Repository;

public class VehicleRepo : IVehicleRepository
{
    private readonly List<Vehicle> vehicles = new List<Vehicle>();

    public List<Vehicle> GetAll()
    {
        if (vehicles == null)
        {
            Console.WriteLine("Database is Empty");
        }

        return vehicles;
    }

    public void Add(Vehicle vehicle)
    {
        foreach (var v in vehicles)
        {
            if (v.Equals(vehicle))
            {
                Console.WriteLine("Data already Exist");
            }
            vehicles.Add(vehicle);
        }
    }

    public Vehicle? FindByLicensePlat(string licensePlat)
    {
        foreach (var vehicle in vehicles)
        {
            if (vehicle.licensePlate.Equals(licensePlat))
            {
                return vehicle;
            }
        }
        return null;
    }

    public List<Vehicle> FIndByColor(VehicleColor color)
    {
        List<Vehicle> list = new List<Vehicle>();
        foreach (var vehicle in vehicles)
        {
            if (vehicle.color.Equals(color))
            {
                list.Add(vehicle);
            }
        }
        return list;
    }
}