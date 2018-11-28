using CarRentalServiceDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalServiceBL
{
    public class ReservationMethods
    {
        static private CarRentalServicesDBContext _context = new CarRentalServicesDBContext();
        static private CarMethods carMethods = new CarMethods();
        static private CustomerMethods customerMethods = new CustomerMethods();

        public List<Reservation> GetAllReservations()
        {
            return _context.Reservations.ToList();
        }

        public Reservation GetReservationById(int id)
        {
            return _context.Reservations.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool AddReservation(Reservation reservation)
        {
            try
            {
                //get car
                //reservation.Car = carMethods.GetCarById(reservation.CarId);
                //get customer
                //reservation.Customer = customerMethods.GetCustomerById(reservation.CustomerId);
                _context.Reservations.Add(reservation);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Reservation> GetReservationByString(string option, string term)
        {
            switch (option)
            {
                case "firstname":
                    Customer customer = customerMethods.GetCustomer("firstname", term);
                    return _context.Reservations.Where(x => x.CustomerId == customer.Id).ToList();

                case "lastname":
                    Customer customerLastName = customerMethods.GetCustomer("lastname", term);
                    return _context.Reservations.Where(x => x.CustomerId == customerLastName.Id).ToList();

                case "regnumber":
                    Car carRegistration = carMethods.GetCarByRegnum(term);
                    return _context.Reservations.Where(x => x.CarId == carRegistration.Id).ToList();

                default:
                    return new List<Reservation> { };


            }
        }

        public List<Reservation> GetReservationByDate(DateTime startDate, DateTime endDate)

        {
                return _context.Reservations.Where(x => x.StartDate == startDate && x.EndDate == endDate).ToList();

        }


        public void RemoveReservation(int id)
        {
            try
            {
                var reservation = _context.Reservations.Where(x => x.Id == id).First();
                _context.Reservations.Remove(reservation);              
                _context.SaveChanges();
      
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
