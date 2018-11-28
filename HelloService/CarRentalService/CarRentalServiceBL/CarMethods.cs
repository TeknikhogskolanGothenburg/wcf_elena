using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalServiceDL;

namespace CarRentalServiceBL
{
    public class CarMethods
    {
        static private CarRentalServicesDBContext _context = new CarRentalServicesDBContext();
       
        public Car GetCarById(int id)
        {
            return _context.Cars.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Car> GetCars()
        {
            return _context.Cars.ToList();
        }
        
        public Car GetCarByRegnum(string regnum)
        {
            return _context.Cars.Where(x => x.Regnumber == regnum).FirstOrDefault();
        }

        public Car GetCarByString(string option, string term)    
        {
            switch (option)
            {
                case "brand":
                    return _context.Cars.Where(x => x.Brand == term).FirstOrDefault();
                case "model":
                    return _context.Cars.Where(x => x.Model == term).FirstOrDefault();
                case "regnumber":
                    return _context.Cars.Where(x => x.Regnumber == term).FirstOrDefault();
                default:
                    return new Car { };
            }
            //return _context.Cars.Where(x => x.Brand == brand).FirstOrDefault();
        }

        public bool AddCar(Car car)
        {
            try
            {
                _context.Cars.Add(car);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }

        public bool RemoveCar(string regnum)
        {
            try
            {
                var car = _context.Cars.Where(x => x.Regnumber == regnum).First();
                _context.Cars.Remove(car);
                //_context.Entry(idForCar).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
                throw e;
            }
        }
       



    }
}
