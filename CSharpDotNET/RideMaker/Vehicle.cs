Vehicle car1 = new Vehicle("benz c class", 5, "Blue", true);
Vehicle car2 = new Vehicle("audi a7",5, "Red",true);
Vehicle car3 = new Vehicle("fiat punto", 4, "Black", true);
Vehicle car4 = new Vehicle("range rover ", 7, "green", false);

List<Vehicle> vehicles = new List<Vehicle> { car1, car2, car3, car4 };

foreach (var vehicle in vehicles)
{
    vehicle.ShowInfo();
}

car2.Travel(100);
car2.ShowInfo();
car2.Travel(350);
car2.ShowInfo();

public class Vehicle
{
  
    private string name;
    private int passengers;
    private string color;
    private bool hasEngine;
    private int distanceTraveled;

   
    public Vehicle(string name, int passengers, string color, bool hasEngine)
    {
        this.name = name;
        this.passengers = passengers;
        this.color = color;
        this.hasEngine = hasEngine;
        this.distanceTraveled = 0;
    }

    public Vehicle(string name, string color)
    {
        this.name = name;
        this.color = color;
        
        this.passengers = 4; 
        this.hasEngine = true;
        this.distanceTraveled = 0;
    }

    public void ShowInfo()
    {
        System.Console.WriteLine($"Vehicle: {name}");
        System.Console.WriteLine($"Passengers: {passengers}");
        System.Console.WriteLine($"Color: {color}");
        System.Console.WriteLine($"Has Engine: {(hasEngine ? "Yes" : "No")}");
        System.Console.WriteLine($"Distance Traveled: {distanceTraveled} miles");
        System.Console.WriteLine();
    }

    public void Travel(int distance)
    {
        distanceTraveled += distance;
        Console.WriteLine($"Traveled {distance} miles. Total distance: {distanceTraveled} miles.");
    }
}
