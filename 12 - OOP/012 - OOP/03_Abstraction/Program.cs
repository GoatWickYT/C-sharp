Console.WriteLine("Car honks");
Car car = new Car();
car.Honk();
// car.Error();
SignalVehicleError(car);

await Task.Delay(2000);

Console.WriteLine("Truck honks");
Truck truck = new Truck();
truck.Honk();
// truck.Error();
SignalVehicleError(truck);

await Task.Delay(2000);

void SignalVehicleError(Vehicle vehicle)
{
    vehicle.Error();
}