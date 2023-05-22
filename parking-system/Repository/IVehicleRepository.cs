using parking_system.Model;
using parking_system.utils;

namespace parking_system.Repository;

public interface IVehicleRepository
{
    public List<Vehicle> GetAll();
    public void Add(Vehicle vehicle);
    public Vehicle? FindByLicensePlat(string licensePlat);
    public List<Vehicle> FIndByColor(VehicleColor color);
}