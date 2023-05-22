using System.Text.RegularExpressions;
using parking_system.Model;
using parking_system.utils;

namespace parking_system.Controller;

public class ParkingLotController
{
    private List<Vehicle> parkedVehicles;
    private int totalLots;
    private int numberOfLot;

    public ParkingLotController(int totalLots)
    {
        this.totalLots = totalLots;
        parkedVehicles = new List<Vehicle>();
    }

    public void CheckIn(string licensePlate, VehicleType? type, string color)
    {
        if (!IsVehicleAllowed(type))
        {
            Console.WriteLine("Only Car and MotorCycle are Allowed.");
            return;
        }

        if (parkedVehicles.Count >= totalLots)
        {
            Console.WriteLine("Parking Lot is FULL.");
            return;
        }

        if (IsLicensePlateRegistered(licensePlate))
        {
            Console.WriteLine("Vehicle With The Same License Plate Already Exists.");
            return;
        }

        Vehicle vehicle = new Vehicle
        {
            licensePlate = licensePlate,
            type = type,
            checkIn = DateTime.Now,
            color = color
        };

        numberOfLot += 1;
        parkedVehicles.Add(vehicle);
        Console.WriteLine("\nParked " + vehicle.licensePlate + " " + vehicle.color + " " + vehicle.type);
        Console.WriteLine("Allocated Slot Number : " + numberOfLot);
    }

    public void CheckOut(string licensePlate)
    {
        var vehicle = parkedVehicles.FirstOrDefault(v => v.licensePlate == licensePlate);
        if (vehicle != null)
        {
            parkedVehicles.Remove(vehicle);
            DateTime checkOutTime = DateTime.Now;
            TimeSpan parkingTime = (vehicle.checkIn - checkOutTime);
            Console.WriteLine("\nVehicle Checked Out Successfully.");
            if (parkingTime < TimeSpan.FromMinutes(60))
                
            {
                Console.WriteLine("Parking Time : 1 hour" );
            }
        }
        else
        {
            Console.WriteLine("Vehicle Not Found.");
        }
    }

    public void DisplayOccupiedLots()
    {
        Console.WriteLine("\nOccupied Lots: " + parkedVehicles.Count);
    }

    public void DisplayAvailableLots()
    {
        int availableLots = totalLots - parkedVehicles.Count;
        Console.WriteLine("\nAvailable Lots: " + availableLots);
    }

    public void DisplayEvenOddReport()
    {
        int evenCount = parkedVehicles.Count(v => GetDigit.DigitOf(v.licensePlate) % 2 == 0);
        int oddCount = parkedVehicles.Count(v => GetDigit.DigitOf(v.licensePlate) % 2 != 0);

        Console.WriteLine("\nEven License Plates: " + evenCount);
        Console.WriteLine("Odd License Plates: " + oddCount);
    }

    public void DisplayVehicleTypeReport()
    {
        var groupedByType = parkedVehicles.GroupBy(v => v.type).Select(g => new { Type = g.Key, Count = g.Count() });

        if (!groupedByType.Any())
        {
            Console.WriteLine("\nThere is no Vehicles on The Parking");
        }
        else
        {
            foreach (var group in groupedByType)
            {
                Console.WriteLine("\nVehicle Type: " + group.Type + ", Count: " + group.Count);
            }
        }
    }

    private bool IsVehicleAllowed(VehicleType? type)
    {
        return type == VehicleType.Car || type == VehicleType.MotorCycle;
    }

    private bool IsLicensePlateRegistered(string licensePlate)
    {
        return parkedVehicles.Any(v => v.licensePlate == licensePlate);
    }

    public void status()
    {
        string[] headers = {"Lisence Plat", "Vehicle Type", "Color" };
        List<Vehicle> data = parkedVehicles;
        
        int[] columnWidths = new int[]
        {
            "Slot".Length,
            "Lisence".Length,
            "Type".Length,
            "Color".Length
        };

        foreach (Vehicle v in data)
        {
            if (v.licensePlate.Length > columnWidths[1])
            {
                columnWidths[1] = v.licensePlate.Length;
            }
            if (v.type.ToString().Length > columnWidths[2])
            {
                columnWidths[2] = v.type.ToString().Length;
            }
            if (v.color.Length > columnWidths[3])
            {
                columnWidths[3] = v.color.Length;
            }
        }
        

        string headerRow = "";
        for (int i = 0; i < headers.Length; i++)
        {
            headerRow += headers[i].PadRight(columnWidths[i]) + " │ ";
        }
        
        // string separatorRow = new string('─', headerRow.Length);
        string separatorRow = new string('─', (columnWidths.Sum() + 3 * columnWidths.Length) - 1);

        Console.WriteLine(headerRow);
        Console.WriteLine(separatorRow);
        
        foreach (Vehicle vehicle in data)
        {
            string dataRow = "";
            dataRow += vehicle.licensePlate.PadRight(columnWidths[1]) + " │ ";
            dataRow += vehicle.type.ToString().PadRight(columnWidths[2]) + " │ ";
            dataRow += vehicle.color.PadRight(columnWidths[3]) + " │ ";
            Console.WriteLine(dataRow);
        }

    }

    // private int GetDigit(string licensePlate)
    // {
    //     string digit = string.Empty;
    //     int fixedDigit = 0;
    //     var matches = Regex.Matches(licensePlate, @"\d+");
    //     foreach(var match in matches){
    //         digit += match;
    //     }
    //
    //     fixedDigit = int.Parse(digit);
    //     return fixedDigit;
    // }
}