using System.Text.RegularExpressions;
using parking_system.Controller;
using parking_system.utils;

public class Program
{
    
    // private static int GetDigit(string licensePlate)
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
    
    static void Main(string[] args)
    {
        ParkingLotController parkingLotController = new ParkingLotController(6); // Menggunakan 6 lot

        while (true)
        {
            Console.WriteLine("1. Check-in Vehicle");
            Console.WriteLine("2. Check-out Vehicle");
            Console.WriteLine("3. Display Occupied Lots");
            Console.WriteLine("4. Display Available Lots");
            Console.WriteLine("5. Display Even/Odd License Plate Report");
            Console.WriteLine("6. Display Vehicle Type Report");
            Console.WriteLine("7. Status");
            Console.WriteLine("8. Exit");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Enter license plate: ");
                    string licensePlate = Console.ReadLine();
                    
                    if (GetDigit.DigitOf(licensePlate) < 1 || GetDigit.DigitOf(licensePlate) > 9999)
                    {
                        Console.WriteLine("INVALID Lisence Plat Number");
                        Console.WriteLine("Lisence Plat Number Should between 1 and 9999");
                        break;
                    }

                    Console.Write("Enter vehicle type (Car/Motorcycle): ");
                    string? stringType = Console.ReadLine();
                    
                    VehicleType? type = null;

                    switch (stringType)
                    {
                        case "car":
                            type = VehicleType.Car;
                            break;
                        case "motorcycle":
                            type = VehicleType.MotorCycle;
                            break;
                        case "truck":
                            type = VehicleType.Truck;
                            break;
                        case "suv":
                            type = VehicleType.Suv;
                            break;
                        default:
                            Console.WriteLine("Vehicle Type INVALID");
                            break;
                    }
                    
                    Console.Write("Enter vehicle color : ");
                    string? color = Console.ReadLine();

                    // VehicleColor? color = null;
                    //
                    // switch (colorInput)
                    // {
                    //     case "black":
                    //         color = VehicleColor.Black;
                    //         break;
                    //     case "white":
                    //         color = VehicleColor.White;
                    //         break;
                    //     case "red":
                    //         color = VehicleColor.Red;
                    //         break;
                    //     case "yellow":
                    //         color = VehicleColor.Yellow;
                    //         break;
                    //     case "green" :
                    //         color = VehicleColor.Green;
                    //         break;
                    //     case "grey" :
                    //         color = VehicleColor.Grey;
                    //         break;
                    //     case "brown" :
                    //         color = VehicleColor.Brown;
                    //         break;
                    //     default:
                    //         Console.WriteLine("Vehicle Color INVALID");
                    //         break;
                    // }
                    
                    parkingLotController.CheckIn(licensePlate, type, color);
                    break;
                case "2":
                    Console.Write("Enter license plate of the vehicle to be checked out: ");
                    string plate = Console.ReadLine();

                    parkingLotController.CheckOut(plate);
                    break;

                case "3":
                    parkingLotController.DisplayOccupiedLots();
                    break;

                case "4":
                    parkingLotController.DisplayAvailableLots();
                    break;

                case "5":
                    parkingLotController.DisplayEvenOddReport();
                    break;

                case "6":
                    parkingLotController.DisplayVehicleTypeReport();
                    break;
                
                case "7":
                    parkingLotController.status();
                    break;

                case "8":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}