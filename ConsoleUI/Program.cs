// See https://aka.ms/new-console-template for more information




using Business.Concrete;

Console.WriteLine("ReCap Project");

CarManager carManager = new CarManager();
var result = carManager.GetCarDetails();

foreach (var car in result.Data)
{
    Console.WriteLine($"{car.CarID} {car.ModelYear} {car.Description} {car.Color}");
}




