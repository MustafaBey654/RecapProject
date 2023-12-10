// See https://aka.ms/new-console-template for more information




using Business.Concrete;
using Entities.Concrete;

Console.WriteLine("ReCap Project");

CarManager carManager = new CarManager();

var MyBmw = new Car { BrandId = 1, ColorId = 3, DailyPrice = 15000, Description = "bmw s yeni 500", ModelYear = 2009 };

//carManager.Add(MyBmw);

//var result = carManager.GetCarDetails();

//foreach (var car in result.Data)
//{
//    Console.WriteLine($"{car.CarID} {car.ModelYear} {car.Description} {car.ColorName} {car.BrandName}");

//}

Console.WriteLine("-*-*-//-/*-*-*--");
var car = carManager.GetById(9);
Console.WriteLine(car.Data.Description);




