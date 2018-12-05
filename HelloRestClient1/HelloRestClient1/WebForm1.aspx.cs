using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HelloRestClient1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddReservation_Click(object sender, EventArgs e) //btnDeleteCar
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:8082/DeleteCar");
            request.Method = "DELETE";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            using (StreamWriter swJSON = new StreamWriter(request.GetRequestStream()))
            {
                string jsonId = new JavaScriptSerializer().Serialize(new
                {
                    id = txtCarId.Text.ToString(),
                });
                swJSON.Write(jsonId);
                swJSON.Flush();
                swJSON.Close();
            }

            HttpWebResponse response;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            var resultMessage = reader.ReadToEnd();
                            txtCarId.Text = "";
                            txtBrand.Text = "";
                            txtModel.Text = "";
                            txtYear.Text = "";
                            txtReg.Text = "";
                            lblResult.Text = resultMessage;
                        }
                    }
                }
            }
            catch (WebException x)
            {
                // lblResult.Text = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
                using (WebResponse response2 = x.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response2;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data = response2.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();
                        txtCarId.Text = "";
                        txtBrand.Text = "";
                        txtModel.Text = "";
                        txtYear.Text = "";
                        txtReg.Text = "";
                        lblResult.Text = text;
                    }
                }
            }


        }

        protected void btnGetReservation_Click(object sender, EventArgs e) //btnGetCarById
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:8082/GetCarById");
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            using (StreamWriter swJSON = new StreamWriter(request.GetRequestStream()))
            {
                string jsonId = new JavaScriptSerializer().Serialize(new
                {
                    id = txtCarId.Text.ToString(),
                });
                swJSON.Write(jsonId);
                swJSON.Flush();
                swJSON.Close();
            }

            HttpWebResponse response;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            var carReturned = reader.ReadToEnd();
                            var stringobj = JsonConvert.DeserializeObject(carReturned);
                            Car json = JsonConvert.DeserializeObject<Car>(stringobj.ToString());
                            txtCarId.Text = json.Id.ToString();
                            txtBrand.Text = json.Brand;
                            txtModel.Text = json.Model;
                            txtYear.Text = json.Year.ToString();
                            txtReg.Text = json.Regnumber;
                            lblResult.Text = "Got your car";
                        }
                    }
                }
            }
            catch (WebException x)
            {
                // lblResult.Text = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
                using (WebResponse response2 = x.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response2;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data = response2.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();
                        lblResult.Text = text;
                        txtCarId.Text = "";
                        txtBrand.Text = "";
                        txtModel.Text = "";
                        txtYear.Text = "";
                        txtReg.Text = "";
                    }
                }
            }

        }

        protected void btnGetCustomer_Click(object sender, EventArgs e) //Get customer by first and last name
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:8082/Customer");
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            using (StreamWriter swJSON = new StreamWriter(request.GetRequestStream()))
            {
                string jsonObj = new JavaScriptSerializer().Serialize(new
                {

                    firstname = txtFirstName.Text.ToString(),
                    lastname = txtLastname.Text.ToString()
                });
                swJSON.Write(jsonObj);
                swJSON.Flush();
                swJSON.Close();
            }

            HttpWebResponse response;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            var customerReturned = reader.ReadToEnd();

                            var stringobj = JsonConvert.DeserializeObject(customerReturned);
                            Customer json = JsonConvert.DeserializeObject<Customer>(stringobj.ToString());
                            lblId.Text = json.Id.ToString();
                            txtFirstName.Text = json.FirstName;
                            txtLastname.Text = json.LastName;
                            txtPhone.Text = json.Phone;
                            txtEmail.Text = json.Email;
                            lblCustomerResult.Text = "Got your customer";
                        }
                    }
                }
            }
            catch (WebException x)
            {
                txtFirstName.Text = "";
                txtLastname.Text = "";
                txtPhone.Text = "";
                txtEmail.Text = "";
                lblCustomerResult.Text = "Customer doesn't exist or something went wrong: ";
                lblCustomerResult.Text += "{\"errorMessages\":[\"" + x.Message.ToString() + "\"],\"errors\":{}}";

            }
        } 

        protected void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:8082/CustomerUpdate");
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            using (StreamWriter swJSON = new StreamWriter(request.GetRequestStream()))
            {
                string jsonObj = new JavaScriptSerializer().Serialize(new
                {
                    id = lblId.Text.ToString(),
                    firstname = txtFirstName.Text.ToString(),
                    lastname = txtLastname.Text.ToString(),
                    phone = txtPhone.Text.ToString(),
                    email = txtEmail.Text.ToString()
                });
                swJSON.Write(jsonObj);
                swJSON.Flush();
                swJSON.Close();
            }

            HttpWebResponse response;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            var result = reader.ReadToEnd();

                            lblCustomerResult.Text = "Customer updated successfully! " + result;
                        }
                    }
                }
            }
            catch (WebException x)
            {
                txtFirstName.Text = "";
                txtLastname.Text = "";
                txtPhone.Text = "";
                txtEmail.Text = "";
                lblCustomerResult.Text = "Something went wrong: ";
                lblCustomerResult.Text += "{\"errorMessages\":[\"" + x.Message.ToString() + "\"],\"errors\":{}}";
            }
        }

        protected void btnGetAllCars_Click(object sender, EventArgs e)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:8082/GetAllCars");
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            HttpWebResponse response;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {

                            var carReturned = reader.ReadToEnd();
                            var stringobj = JsonConvert.DeserializeObject(carReturned);
                            List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(stringobj.ToString());
                            foreach (Car car in cars)
                            {
                                lstCars.Items.Add("Brand: " + car.Brand + " | Regnumb: " + car.Regnumber);
                            }
                        }
                    }
                }
            }
            catch (WebException x)
            {
               
                using (WebResponse response2 = x.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response2;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data = response2.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();
                        lblAllCars.Text = text;
                    }
                }
            }

        }
    }
}