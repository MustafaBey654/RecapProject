// See https://aka.ms/new-console-template for more information


using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.InMemories;

Console.WriteLine("ReCap Project");

CarManager carManager = new CarManager(new EfCarDal( new InMemoryContext()));
var liste = carManager.GetAll();
foreach (var car in liste)
{
    Console.WriteLine(car.Description +" "+car.ModelYear);
}
