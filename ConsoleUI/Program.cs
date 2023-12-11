// See https://aka.ms/new-console-template for more information




using Business.Concrete;
using Entities.Concrete;

Console.WriteLine("ReCap Project");

Console.WriteLine("*/*/*/*/Araba Kiralama ve Müşteri Ekleme */* /*/*/ */ ");

//var userList = new List<User>
//{

//    new User { Email="candar@gmail.com",Password="Mustafa75",FirstName="Mustafa",LastName="yilmaz" },
//    new User { Email="ali@gmail.com",Password="Ali7575",FirstName="Ali",LastName="yalçın" },
//    new User { Email="veli@gmail.com",Password="veli",FirstName="Veli",LastName="aslan" },
//    new User { Email="yusuf@gmail.com",Password="yusuf8589",FirstName="yusuf",LastName="ardan" },
//    new User { Email="seref@gmail.com",Password="Şeref785",FirstName="Şeref",LastName="Demir" },
//    new User { Email="osman@gmail.com",Password="Osman898",FirstName="Osman",LastName="Öztürk" }


//};

UserManager userManager = new UserManager();
//foreach (var user in userList)
//{
//    userManager.Add(user);
//}

var userListesi = userManager.GetAllUser().Data;
foreach (var user in userListesi)
{
    Console.WriteLine(user.FirstName + " " + user.LastName);
}

CustomerManager customerManager = new CustomerManager();

var customerList = new List<Customer>
{
    new Customer{CompanyName="Kiralama",UserId=1},
    new Customer{CompanyName="Kiralama",UserId=2},
    new Customer{CompanyName="Kiralama",UserId=3},
    new Customer{CompanyName="Kiralama",UserId=4},
    new Customer{CompanyName="Kiralama",UserId=5}
};

//foreach (var customer in customerList)
//{
//    customerManager.Add(customer);
//}


var customerListe = customerManager.GetAllCustomer().Data;
foreach (var customer in customerListe)
{
    Console.WriteLine(customer.CompanyName +" "+ customer.UserId);
}


RentalManager rentalManager = new RentalManager();

var rental = new Rental { CarId = 8,CustomerId=3,RentDate=DateTime.Now,ReturnDate=DateTime.Now.AddDays(5)};
rentalManager.AddRental(rental);

Console.WriteLine("*/*/*/*/Kiralana Araçlar -/*/*/*/*/*/ ");
var kiralananAraclar = rentalManager.GetAll().Data;

foreach(var rentCar in kiralananAraclar)
{
    Console.WriteLine($"{rentCar.CarId} {rentCar.RentDate} {rentCar.ReturnDate} ");
}




