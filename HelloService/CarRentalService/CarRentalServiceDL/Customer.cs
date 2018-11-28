using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.ServiceModel;

namespace CarRentalServiceDL
{
    [MessageContract(IsWrapped = true,
        WrapperName = "CustomerRequestObject",
        WrapperNamespace = "http://arthead.se/Customer")] //Detta är vad klienten ska skicka till oss i M.Logging
    public class CustomerRequest
    {
        [MessageHeader(Namespace = "http://arthead.se/Customer")]
        public string LicenseKey { get; set; }
        [MessageBodyMember(Namespace = "http://arthead.se/Customer")]
        public string CustomerLastName { get; set; }  
    }

    [MessageContract(IsWrapped = true,
       WrapperName = "CustomerInfoObject",
       WrapperNamespace = "http://arthead.se/Customer")]
    public class CustomerInfo 
    {
        public CustomerInfo() { }//Om jag inte skapar en konstruktor får jag en default konstruktor men får inte det om jag skapar en och får därför inte null heller. Skapa därför en default tom konstruktor.
        public CustomerInfo(Customer customer) //Tar en employee och sätter alla våra properies nedan 
        {
            this.Id = customer.Id;
            this.FirstName = customer.FirstName;  
            this.LastName = customer.LastName;
            this.Phone = customer.Phone;
            this.Email = customer.Email;
        }

        [MessageBodyMember(Order = 1, Namespace = "http://arthead.se/Customer")]
        public int Id { get; set; }
        [MessageBodyMember(Order = 2, Namespace = "http://arthead.se/Customer")]
        public string FirstName { get; set; } 
        [MessageBodyMember(Order = 3, Namespace = "http://arthead.se/Customer")]
        public string LastName { get; set; } 
        [MessageBodyMember(Order = 4, Namespace = "http://arthead.se/Customer")]
        public string Phone { get; set; }
        [MessageBodyMember(Order = 5, Namespace = "http://arthead.se/Customer")]
        public string Email { get; set; } 
      
    }

    [DataContract]
    public class Customer
    {
        public Customer()
        {
            Reservations = new List<Reservation>();
        }

        [DataMember(Name = "_Id")]
        public int Id { get; set; }

        [DataMember(Name = "_FirstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "_LastName")]
        public string LastName { get; set; }

        [DataMember(Name = "_Phone")]
        public string  Phone { get; set; }

        [DataMember(Name = "_Email")]
        public string Email { get; set; }

        [DataMember]
        public List<Reservation> Reservations { get; set; }
    }
}
