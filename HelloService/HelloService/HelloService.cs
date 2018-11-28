using System;
using System.Collections.Generic;
using CarRentalServiceBL;
using CarRentalServiceDL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Net;

namespace HelloService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HelloService" in both code and config file together.
    public class HelloService : IHelloService
    {
        static private CarMethods carMethods = new CarMethods();
        static private ReservationMethods reservMethods = new ReservationMethods();
        static private CustomerMethods customerMethods = new CustomerMethods();

        public Car GetCarByReg(string name)
        {
            return carMethods.GetCarByRegnum(name);
        }


        public Car GetCarByString(string option, string term)
        {

            Car car = carMethods.GetCarByString(option, term);
            if (car == null)
            {
                throw new FaultException("Finns ingen sådan bil förstår du...");

            }
            return car;
        }

        public Car GetCarById(int id)
        {
            Car car = new Car();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetCarById", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@Id";
                parameterId.Value = id;

                cmd.Parameters.Add(parameterId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    car.Id = id;
                    car.Model = reader["Model"].ToString();
                    car.Brand = reader["Brand"].ToString();
                    car.Regnumber = reader["Regnumber"].ToString();
                    car.Year = Convert.ToInt32(reader["Year"]);
                }
            }

            return car;
        }

        public void DeleteCar(string regnum)
        {
            carMethods.RemoveCar(regnum);
        }

        public CustomerInfo GetCustomer(CustomerRequest request)
        {
            if (request.LicenseKey != "SuperSecret123")
            {
                throw new WebFaultException<string>(
                    "Wrong license key",
                HttpStatusCode.Forbidden); //Gör ett web fault exception
            }
            else
            {
                Customer customer = new Customer();

                //Configuration manager för att få kontakt med vår connectionstring i hosten
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("spGetCustomer", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameterId = new SqlParameter();
                    parameterId.ParameterName = "@LastName";
                    //parameterId.Value = id;
                    parameterId.Value = request.CustomerLastName;

                    cmd.Parameters.Add(parameterId);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        customer.FirstName = reader["FirstName"].ToString();
                        customer.LastName = reader["LastName"].ToString();
                        customer.Phone = reader["Phone"].ToString();
                        customer.Email = reader["Email"].ToString();
                    }
                }
                return new CustomerInfo(customer);
            }
        }

        public void SaveCustomer(CustomerInfo customer)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spAddNewCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterFirstname = new SqlParameter
                {
                    ParameterName = "@FirstName",
                    Value = customer.FirstName
                };
                cmd.Parameters.Add(parameterFirstname);

                SqlParameter parameterLastname = new SqlParameter
                {
                    ParameterName = "@LastName",
                    Value = customer.LastName
                };
                cmd.Parameters.Add(parameterLastname);

                SqlParameter parameterPhone = new SqlParameter
                {
                    ParameterName = "@Phone",
                    Value = customer.Phone
                };
                cmd.Parameters.Add(parameterPhone);

                SqlParameter parameterEmail = new SqlParameter
                {
                    ParameterName = "@Email",
                    Value = customer.Email
                };
                cmd.Parameters.Add(parameterEmail);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ListReservationsInfo GetReservationByDate(ReservationRequestByDate request)
        {
            if (request.LicenseKey != "SuperSecret123")
            {
                throw new WebFaultException<string>(
                    "Wrong license key",
                HttpStatusCode.Forbidden); //Gör ett web fault exception
            }
            else
            {
                ICollection<Reservation> reservations = new List<Reservation>();
                ICollection<ReservationInfo> ri = new List<ReservationInfo>();

                //Configuration manager för att få kontakt med vår connectionstring i hosten
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("spGetReservationsByDate", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameterStartdate = new SqlParameter();
                    SqlParameter parameterEnddate = new SqlParameter();
                    parameterStartdate.ParameterName = "@Startdate";
                    parameterEnddate.ParameterName = "@Enddate";
                    parameterStartdate.Value = Convert.ToDateTime(request.Startdate);
                    parameterEnddate.Value = Convert.ToDateTime(request.Enddate);

                    cmd.Parameters.Add(parameterStartdate);
                    cmd.Parameters.Add(parameterEnddate);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ReservationInfo reserv = new ReservationInfo()
                        {
                            Brand = reader["Brand"].ToString(),
                            Model = reader["Model"].ToString(),
                            Regnumber = reader["Regnumber"].ToString(),
                            Year = Convert.ToInt32(reader["Year"]),
                            StartDate = Convert.ToDateTime(reader["StartDate"]),
                            EndDate = Convert.ToDateTime(reader["EndDate"])

                        };
                        ri.Add(reserv);
                    }
                }
                return new ListReservationsInfo(ri);
            }
        }

        public ReservationInfo GetReservationByBrand(ReservationRequestByBrand request)
        {
            if (request.LicenseKey != "SuperSecret123")
            {
                throw new WebFaultException<string>(
                    "Wrong license key",
                HttpStatusCode.Forbidden); //Gör ett web fault exception
            }
            else
            {
                Reservation reservation = new Reservation();

                //Configuration manager för att få kontakt med vår connectionstring i hosten
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;


                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("spGetReservationByBrand", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    SqlParameter parameterId = new SqlParameter();
                    parameterId.ParameterName = "@Brand";
                    //parameterId.Value = id;
                    parameterId.Value = request.CarBrand;

                    cmd.Parameters.Add(parameterId);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        reservation.Car.Model = reader["Model"].ToString();
                        reservation.Car.Regnumber = reader["Regnumber"].ToString();
                        reservation.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        reservation.EndDate = Convert.ToDateTime(reader["EndDate"]);
                    }
                }
                return new ReservationInfo(reservation);
            }
        }

        public ListReservationsInfo GetAvailableCars(ReservationRequestByDate request)
        {
            if (request.LicenseKey != "SuperSecret123")
            {
                throw new WebFaultException<string>(
                    "Wrong license key",
                HttpStatusCode.Forbidden); //Gör ett web fault exception
            }
            else
            {
                ICollection<Reservation> reservations = new List<Reservation>();
                ICollection<ReservationInfo> ri = new List<ReservationInfo>();

                //Configuration manager för att få kontakt med vår connectionstring i hosten
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("spGetAvailableCars", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameterStartdate = new SqlParameter();
                    SqlParameter parameterEnddate = new SqlParameter();
                    parameterStartdate.ParameterName = "@Startdate";
                    parameterEnddate.ParameterName = "@Enddate";
                    parameterStartdate.Value = Convert.ToDateTime(request.Startdate);
                    parameterEnddate.Value = Convert.ToDateTime(request.Enddate);

                    cmd.Parameters.Add(parameterStartdate);
                    cmd.Parameters.Add(parameterEnddate);


                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ReservationInfo reserv = new ReservationInfo()
                        {
                            Brand = reader["Brand"].ToString(),
                            Model = reader["Model"].ToString(),
                            Regnumber = reader["Regnumber"].ToString(),
                            Year = Convert.ToInt32(reader["Year"]),
                            StartDate = Convert.ToDateTime(reader["StartDate"]),
                            EndDate = Convert.ToDateTime(reader["EndDate"])

                        };
                        ri.Add(reserv);
                    }
                }
                return new ListReservationsInfo(ri);
            }
        }

        public void DeleteCustomer(string option, string name)
        {
            customerMethods.RemoveCustomer(option, name);

        }
    }
}
