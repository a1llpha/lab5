using System;
using System.Collections.Generic;


public abstract class Vehicle
{
    public int Speed { get; set; }
    public int Capacity { get; set; }

    public abstract void Move();
}


public class Human
{
    public int Speed { get; set; }

    public void Move()
    {
        Console.WriteLine("Human is moving.");
    }
}


public class Car : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Car is moving.");
    }
}

public class Bus : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Bus is moving.");
    }
}

public class Train : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Train is moving.");
    }
}


public class Route
{
    public string StartPoint { get; set; }
    public string EndPoint { get; set; }
}


public class TransportNetwork
{
    private List<Vehicle> vehicles;

    public TransportNetwork()
    {
        vehicles = new List<Vehicle>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void ControlMovement()
    {
        foreach (var vehicle in vehicles)
        {
            vehicle.Move();
        }
    }

    public string CalculateOptimalRoute(Route route, Vehicle vehicle)
    {
        return $"Optimal route from {route.StartPoint} to {route.EndPoint} for {vehicle.GetType().Name}";
    }

    public void PassengerHandling(Vehicle vehicle, int passengers)
    {
        Console.WriteLine($"Handling {passengers} passengers for {vehicle.GetType().Name}");
    }
}

class Program
{
    static void Main()
    {
        Car car = new Car();
        Bus bus = new Bus();
        Train train = new Train();

        TransportNetwork transportNetwork = new TransportNetwork();
        transportNetwork.AddVehicle(car);
        transportNetwork.AddVehicle(bus);
        transportNetwork.AddVehicle(train);

        transportNetwork.ControlMovement();

        Route route = new Route { StartPoint = "A", EndPoint = "B" };
        Console.WriteLine(transportNetwork.CalculateOptimalRoute(route, car));

        transportNetwork.PassengerHandling(bus, 30);
    }
}
