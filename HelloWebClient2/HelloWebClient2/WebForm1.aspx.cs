using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;

namespace HelloWebClient2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static List<string> carsRegnum = new List<string>();


        protected void btnGetCarById_Click(object sender, EventArgs e)
        {
            ServiceReference1.HelloServiceClient client = new ServiceReference1.HelloServiceClient("wsHttpBinding_IHelloService");
            ServiceReference1.Car car = new ServiceReference1.Car();
            car = client.GetCarById(Convert.ToInt32(txtGetCar.Text));
            if (car._Year != 0)
            {

                lblBrand.Text = car._Brand;
                lblModel.Text = car._Model;
                lblYear.Text = Convert.ToString(car._Year);
                lblReg.Text = car._Regnumber;
                lblMessage.Text = "The car is retrieved";
            }
            else
            {
                lblBrand.Text = "-";
                lblModel.Text = "-";
                lblYear.Text = "-";
                lblReg.Text = "-";
                lblMessage.Text = "The search didn't brig any cars";

            }

        }

        protected void btnGetCarByReg_Click(object sender, EventArgs e)
        {
            ServiceReference1.HelloServiceClient client = new ServiceReference1.HelloServiceClient("wsHttpBinding_IHelloService");
            ServiceReference1.Car car = client.GetCarByReg(txtGetCar.Text);
            if (car != null)
            {

                lblBrand.Text = car._Brand;
                lblModel.Text = car._Model;
                lblYear.Text = Convert.ToString(car._Year);
                lblReg.Text = car._Regnumber;
                lblMessage.Text = "The car is retrieved";
            }
            else
            {
                lblBrand.Text = "-";
                lblModel.Text = "-";
                lblYear.Text = "-";
                lblReg.Text = "-";
                lblMessage.Text = "The search didn't brig any cars";
            }


        }

        protected void btnSaveCar_Click(object sender, EventArgs e)
        {
            ServiceReference1.IHelloService client = new ServiceReference1.HelloServiceClient("wsHttpBinding_IHelloService");
            ServiceReference1.CarInfo car = new ServiceReference1.CarInfo();
            try
            {
                car.Brand = lblBrand.Text;
                car.Model = lblModel.Text;
                car.Year = Convert.ToInt16(lblYear.Text);
                car.Regnumber = lblReg.Text;

                client.SaveCar(car);
                lblMessage.Text = "The car is saved";
            }
            catch
            {
                lblBrand.Text = "-";
                lblModel.Text = "-";
                lblYear.Text = "-";
                lblReg.Text = "-";

                lblMessage.Text = "Could not save car. Something went wrong";
            }


        }

        protected void btnDeleteCar_Click(object sender, EventArgs e)
        {
            ServiceReference1.HelloServiceClient client = new ServiceReference1.HelloServiceClient("wsHttpBinding_IHelloService");
            if (lblReg.Text != null || lblReg.Text != "")
            {
                client.DeleteCar(lblReg.Text);
                lblBrand.Text = "-";
                lblModel.Text = "-";
                lblYear.Text = "-";
                lblReg.Text = "-";
                lblMessage.Text = "The car with registrationumber " + lblReg.Text + " is removed.";
            }
            else
            {
                lblMessage.Text = "You have to find a car to remove!";
            }

        }

        protected void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            ServiceReference1.IHelloService client = new ServiceReference1.HelloServiceClient("wsHttpBinding_IHelloService");
            ServiceReference1.CustomerInfo customer = new ServiceReference1.CustomerInfo();


            customer.FirstName = txtCustomFirstName.Text;
            customer.LastName = txtCustomLastName.Text;
            customer.Phone = txtPhone.Text;
            customer.Email = txtEmail.Text;

            client.SaveCustomer(customer);
            lblCustomer.Text = "Customer saved";
        }

        protected void btnGetCustomer_Click(object sender, EventArgs e)
        {
            ServiceReference1.IHelloService client = new ServiceReference1.HelloServiceClient("wsHttpBinding_IHelloService"/*"BasicHttpBinding_IHelloService"*/);

            ServiceReference1.CustomerRequest request = new ServiceReference1.CustomerRequest();
            request.LicenseKey = "SuperSecret123";
            request.CustomerLastName = txtCustomLastName.Text;

            ServiceReference1.CustomerInfo customer = client.GetCustomer(request);

            if (customer.FirstName != null)
            {

                txtCustomFirstName.Text = customer.FirstName;
                txtCustomLastName.Text = customer.LastName;
                txtPhone.Text = customer.Phone;
                txtEmail.Text = customer.Email;

                lblCustomer.Text = "Customer retrieved";

            }
            else
            {
                txtCustomFirstName.Text = "-";
                txtCustomLastName.Text = "-";
                txtEmail.Text = "-";
                txtPhone.Text = "-";

                lblCustomer.Text = "Couldn't find customer";
            }


        }

        protected void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            ServiceReference1.HelloServiceClient client = new ServiceReference1.HelloServiceClient("wsHttpBinding_IHelloService");
            if (txtCustomLastName.Text != null || txtCustomLastName.Text != "")
            {
                client.DeleteCustomer("lastname", txtCustomLastName.Text);
                txtCustomFirstName.Text = "-";
                txtCustomLastName.Text = "-";
                txtEmail.Text = "-";
                txtPhone.Text = "-";
                lblCustomer.Text = "The customer with lastname " + txtCustomLastName.Text + " is removed.";
            }
            else
            {
                lblCustomer.Text = "No customer to remove!";
            }
        }

        protected void btnGetReservationByBrand_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.IHelloService client = new ServiceReference1.HelloServiceClient("wsHttpBinding_IHelloService");

                ServiceReference1.Car car = client.GetCarByString("brand", txtResBrand.Text);

                ServiceReference1.ReservationRequestByBrand request = new ServiceReference1.ReservationRequestByBrand();
                request.LicenseKey = "SuperSecret123";
                request.CarBrand = txtResBrand.Text;


                ServiceReference1.ReservationInfo1 reservation = client.GetReservationByBrand(request);

                if (reservation.Model != null)
                {
                    lblResModel.Text = reservation.Model;
                    lblResReg.Text = reservation.Regnumber;
                    lblStartDate.Text = reservation.StartDate.ToShortDateString();
                    lblEndDate.Text = reservation.EndDate.ToShortDateString();

                    lblResMessage.Text = "This car is reserved";

                }
                else
                {
                    lblResModel.Text = car._Model;
                    lblResReg.Text = car._Regnumber;
                    lblStartDate.Text = "-";
                    lblEndDate.Text = "-";

                    lblResMessage.Text = "Car have no reservations";

                }

            }
            catch (FaultException faultException)
            {
                lblResMessage.Text = faultException.Message;
            }

        }

        protected void btnGetBookedCars_Click(object sender, EventArgs e)
        {

            lblLabelReservations.Text = " ";
            lblCarModel.Text = " ";
            lblCarBrand.Text = " ";
            lblCarReg.Text = " ";
            lblCarYear.Text = " ";
            lblBookingStart.Text = " ";
            lblReservationResult.Text = " ";

            txtAvailableRegCar.Visible = false;
            lblAvailableModel.Visible = false;
            lblAvailableBrand.Visible = false;
            txtFirstName.Visible = false;
            txtLastName.Visible = false;
            txtPhonenumber.Visible = false;
            txtEmailAddress.Visible = false;
            txtBookStartDate.Visible = false;
            txtBookuntil.Visible = false;
            btnSaveBook.Visible = false;

            txtAvailableRegCar.Text = " ";
            lblAvailableModel.Text = " ";
            lblAvailableBrand.Text = " ";
            txtFirstName.Text = " ";
            txtLastName.Text = " ";
            txtPhonenumber.Text = " ";
            txtEmailAddress.Text = " ";
            txtBookStartDate.Text = " ";
            txtBookuntil.Text = " ";
            btnSaveBook.Text = " ";


            ServiceReference1.IHelloService client = new ServiceReference1.HelloServiceClient("wsHttpBinding_IHelloService");

            ServiceReference1.ReservationRequestByDate request = new ServiceReference1.ReservationRequestByDate();
            request.LicenseKey = "SuperSecret123";
            request.Startdate = calStartdate.SelectedDate.ToShortDateString();
            lblDateFrom.Text = request.Startdate;
            request.Enddate = calEnddate.SelectedDate.ToShortDateString();
            lblDateTo.Text = request.Enddate;

            ServiceReference1.ListReservationsInfo reservationsInfo = new ServiceReference1.ListReservationsInfo();
            reservationsInfo = client.GetReservationByDate(request);

            if (reservationsInfo.ReservationCollection != null && reservationsInfo.ReservationCollection.Count() != 0)
            {
                lblLabelReservations.Text = "Reserved car(s)";
                foreach (ServiceReference1.ReservationInfo reservation in reservationsInfo.ReservationCollection)
                {

                    string number = reservationsInfo.ReservationCollection.IndexOf(reservation).ToString();
                    lblCarModel.Text += number + ": " + reservation.Model + "|| ";
                    lblCarReg.Text += number + ": " + reservation.Regnumber + "|| ";
                    lblCarBrand.Text += number + ": " + reservation.Brand + "|| ";
                    lblCarYear.Text += number + ": " + reservation.Year.ToString() + "|| ";
                    lblBookingStart.Text += number + ": " + reservation.StartDate.ToShortDateString() + " - " + reservation.EndDate.ToShortDateString() + "|| ";

                }


                lblReservationResult.Text = "Found reservations";
            }
            else
            {
                lblCarModel.Text = "-";
                lblCarBrand.Text = "-";
                lblCarReg.Text = "-";
                lblCarYear.Text = "-";
                lblBookingStart.Text = "-";


                lblReservationResult.Text = "Didn't find any reservations";
            }

        }

        protected void btnGetAvailableCars_Click(object sender, EventArgs e)
        {

            lblLabelReservations.Text = " ";
            lblCarModel.Text = " ";
            lblCarBrand.Text = " ";
            lblCarReg.Text = " ";
            lblCarYear.Text = " ";
            lblBookingStart.Text = " ";
            lblReservationResult.Text = " ";

            txtAvailableRegCar.Visible = false;
            lblAvailableModel.Visible = false;
            lblAvailableBrand.Visible = false;
            txtFirstName.Visible = false;
            txtLastName.Visible = false;
            txtPhonenumber.Visible = false;
            txtEmailAddress.Visible = false;
            txtBookStartDate.Visible = false;
            txtBookuntil.Visible = false;
            btnSaveBook.Visible = false;

            txtAvailableRegCar.Text = " ";
            lblAvailableModel.Text = " ";
            lblAvailableBrand.Text = " ";
            txtFirstName.Text = " ";
            txtLastName.Text = " ";
            txtPhonenumber.Text = " ";
            txtEmailAddress.Text = " ";
            txtBookStartDate.Text = " ";
            txtBookuntil.Text = " ";
            btnSaveBook.Text = " ";


            ServiceReference1.IHelloService client = new ServiceReference1.HelloServiceClient("wsHttpBinding_IHelloService");

            ServiceReference1.ReservationRequestByDate request = new ServiceReference1.ReservationRequestByDate();
            request.LicenseKey = "SuperSecret123";
            request.Startdate = calStartdate.SelectedDate.ToShortDateString();
            lblDateFrom.Text = request.Startdate;
            request.Enddate = calEnddate.SelectedDate.ToShortDateString();
            lblDateTo.Text = request.Enddate;

            ServiceReference1.ListReservationsInfo reservationsInfo = new ServiceReference1.ListReservationsInfo();
            reservationsInfo = client.GetAvailableCars(request);

            List<ServiceReference1.Reservation> allReser = client.GetAllReservations();
            List<int> carId = new List<int>();
            foreach(ServiceReference1.Reservation res in allReser)
            {
                carId.Add(res.CarId);
            }
            List<ServiceReference1.Car> allCars = client.GetAllCars();

            foreach (ServiceReference1.Car car1 in allCars)
            {
                if (!carId.Contains(car1._Id))
                {
                    carsRegnum.Add(car1._Regnumber);
                    lblCarModel.Text += ": " + car1._Model + "|| ";
                    lblCarReg.Text += ": " + car1._Regnumber + "|| ";
                    lblCarBrand.Text += ": " + car1._Brand + "|| ";
                    lblCarYear.Text += ": " + car1._Year.ToString() + "|| ";
                    lblBookingStart.Text += ": never been booked || ";
                }
            }

            if (reservationsInfo.ReservationCollection != null && reservationsInfo.ReservationCollection.Count() != 0)
            {
                lblLabelReservations.Text = "Available car(s)";

                foreach (ServiceReference1.ReservationInfo reservation in reservationsInfo.ReservationCollection)
                {
                    carsRegnum.Add(reservation.Regnumber);
                    lblCarModel.Text += ": " + reservation.Model + "|| ";
                    lblCarReg.Text += ": " + reservation.Regnumber + "|| ";
                    lblCarBrand.Text += ": " + reservation.Brand + "|| ";
                    lblCarYear.Text += ": " + reservation.Year.ToString() + "|| ";
                    lblBookingStart.Text += ": " + reservation.StartDate.ToShortDateString() + " - " + reservation.EndDate.ToShortDateString() + "|| ";

                }

                txtBookStartDate.Text = lblDateFrom.Text;
                txtBookuntil.Text = lblDateTo.Text;
                btnMakeReservation.Visible = true;
                lblReservationResult.Text = "Found available car(s)";
            }
            else
            {
                lblCarModel.Text = "-";
                lblCarBrand.Text = "-";
                lblCarReg.Text = "-";
                lblCarYear.Text = "-";
                lblBookingStart.Text = "-";


                btnMakeReservation.Visible = true;
                lblReservationResult.Text = "No available car(s)";
            }
        }

        protected void btnMakeReservation_Click(object sender, EventArgs e)
        {
            txtAvailableRegCar.Visible = true;

            lblAvailableModel.Visible = true;
            lblAvailableBrand.Visible = true;
            txtFirstName.Visible = true;
            txtLastName.Visible = true;
            txtPhonenumber.Visible = true;
            txtEmailAddress.Visible = true;
            txtBookStartDate.Visible = true;
            txtBookuntil.Visible = true;
            btnSaveBook.Visible = true;

        }

        protected void btnSaveBook_Click(object sender, EventArgs e)
        {
            ServiceReference1.IHelloService client = new ServiceReference1.HelloServiceClient("wsHttpBinding_IHelloService");
            //ServiceReference1.HelloServiceClient client = new ServiceReference1.HelloServiceClient("wsHttpBinding_IHelloService");
            ServiceReference1.Car car = client.GetCarByReg(txtAvailableRegCar.Text);
            //ServiceReference1.Customer customer = new ServiceReference1.Customer();
            ServiceReference1.ReservationInfo1 reservation = new ServiceReference1.ReservationInfo1();
            ServiceReference1.CustomerInfo customer = new ServiceReference1.CustomerInfo();

            if (carsRegnum.Contains(car._Regnumber))
            {
                customer.FirstName = txtFirstName.Text;
                customer.LastName = txtLastName.Text;
                customer.Phone = txtPhonenumber.Text;
                customer.Email = txtEmailAddress.Text;

                try
                {
                    client.SaveCustomer(customer);
                }
                catch (FaultException faultException)
                {
                    lblReservationResult.Text = faultException.Message;
                }

                reservation.Brand = car._Brand;
                reservation.Model = car._Model;
                reservation.Regnumber = car._Regnumber;
                reservation.Year = car._Year;
                reservation.StartDate = Convert.ToDateTime(txtBookStartDate.Text);
                reservation.EndDate = Convert.ToDateTime(txtBookuntil.Text);
                reservation.LastName = customer.LastName;
                reservation.Returned = false;

               
                try
                {
                    client.AddReservation(reservation);
                    lblReservationResult.Text = "Reservation successfully saved";
                }
                catch (FaultException faultException)
                {
                    lblReservationResult.Text = faultException.Message;
                }

            }
            else
            {
                lblReservationResult.Text = "Car is not available during the period of choice";
            }
        }

        protected void btnClearSearch_Click(object sender, EventArgs e)
        {
            lblLabelReservations.Text = " ";
            lblCarModel.Text = " ";
            lblCarBrand.Text = " ";
            lblCarReg.Text = " ";
            lblCarYear.Text = " ";
            lblBookingStart.Text = " ";
            lblReservationResult.Text = " ";

            txtAvailableRegCar.Visible = false;
            lblAvailableModel.Visible = false;
            lblAvailableBrand.Visible = false;
            txtFirstName.Visible = false;
            txtLastName.Visible = false;
            txtPhonenumber.Visible = false;
            txtEmailAddress.Visible = false;
            txtBookStartDate.Visible = false;
            txtBookuntil.Visible = false;
            btnSaveBook.Visible = false;

            txtAvailableRegCar.Text = " ";
            lblAvailableModel.Text = " ";
            lblAvailableBrand.Text = " ";
            txtFirstName.Text = " ";
            txtLastName.Text = " ";
            txtPhonenumber.Text = " ";
            txtEmailAddress.Text = " ";
            txtBookStartDate.Text = " ";
            txtBookuntil.Text = " ";
            btnSaveBook.Text = " ";
        }




    }
}