using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using static System.Console;
using CarRentalServiceDL;
using CarRentalServiceBL;
using static CarRentalServiceBL.CarMethods;

namespace CarRentalServiceTest
{
    class Program
    {
         //<!--connectionString="Server=tcp:zilver-tester.database.windows.net,1433;Initial Catalog=TestDB;Persist Security Info=False;User ID= zilver;Password = qawsedrf123@@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"-->

        static private CarMethods carMethods = new CarMethods();
        static private CustomerMethods methods = new CustomerMethods();
        static void Main(string[] args)
        {
            CarRentalServicesDBContext _context = new CarRentalServicesDBContext();



            //var car = new Car{
            //    Brand = "Tesla",
            //    Model = "X",
            //    Year = 2016,
            //    Regnumber = "test"
            //};
            //var addCar = carMethods.AddCar(car);
            //_context.SaveChanges();



            var cust = new Customer { FirstName = "Ramin", LastName = "Runesson", Phone = "0703454545", Email = "ramin@min.ra" };
            methods.ChangeCustomer(cust);
            List<Customer> customers = methods.GetAllCustomers();
            foreach (Customer c in customers)
            {
                Write(c.FirstName);
            }
            ReadKey();


        }
    }
}
