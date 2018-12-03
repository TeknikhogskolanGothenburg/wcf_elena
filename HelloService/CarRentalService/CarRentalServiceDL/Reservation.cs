using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.ServiceModel;

namespace CarRentalServiceDL
{
    [MessageContract(IsWrapped = true,
      WrapperName = "ReservationRequestBrandObject",
      WrapperNamespace = "http://arthead.se/Reservation")] //Detta är vad klienten ska skicka till oss i M.Logging
    public class ReservationRequestByBrand  
    {
        [MessageHeader(Namespace = "http://arthead.se/Reservation")]
        public string LicenseKey { get; set; }
        [MessageBodyMember(Namespace = "http://arthead.se/Reservation")]
        public string CarBrand { get; set; } 
    }

    [MessageContract(IsWrapped = true,
   WrapperName = "ReservationRequestDateObject",
   WrapperNamespace = "http://arthead.se/Reservation")] //Detta är vad klienten ska skicka till oss i M.Logging
    public class ReservationRequestByDate
    {
        [MessageHeader(Namespace = "http://arthead.se/Reservation")]
        public string LicenseKey { get; set; }
        [MessageBodyMember(Namespace = "http://arthead.se/Reservation")]
        public string Startdate { get; set; }
        [MessageBodyMember(Namespace = "http://arthead.se/Reservation")]
        public string Enddate { get; set; }
    }


    [MessageContract(IsWrapped = true,
       WrapperName = "ReservationInfoObject",
       WrapperNamespace = "http://arthead.se/Reservation")]
    public class ReservationInfo 
    { 
        public ReservationInfo() { }//Om jag inte skapar en konstruktor får jag en default konstruktor men får inte det om jag skapar en och får därför inte null heller. Skapa därför en default tom konstruktor.
        public ReservationInfo(Reservation reservation) //Tar en employee och sätter alla våra properies nedan 
        { 
          
            this.Brand = reservation.Car.Brand; 
            this.Model = reservation.Car.Model;
            this.Regnumber = reservation.Car.Regnumber;
            this.StartDate = reservation.StartDate;
            this.EndDate = reservation.EndDate;
            this.Year = reservation.Car.Year;
            this.LastName = reservation.Customer.LastName;
            this.Returned = reservation.Returned;
            
        }

        [MessageBodyMember(Order = 1, Namespace = "http://arthead.se/Reservation")]
        public int Id { get; set; }
        [MessageBodyMember(Order = 2, Namespace = "http://arthead.se/Reservation")]
        public string Brand { get; set; } 
        [MessageBodyMember(Order = 3, Namespace = "http://arthead.se/Reservation")]
        public string Model { get; set; }
        [MessageBodyMember(Order = 4, Namespace = "http://arthead.se/Reservation")]
        public string Regnumber { get; set; }
        [MessageBodyMember(Order = 5, Namespace = "http://arthead.se/Reservation")]
        public DateTime StartDate { get; set; }
        [MessageBodyMember(Order = 6, Namespace = "http://arthead.se/Reservation")]
        public DateTime EndDate { get; set; }
        [MessageBodyMember(Order =7, Namespace = "http://arthead.se/Reservation")]
        public int Year { get; set; }
        [MessageBodyMember(Order = 8, Namespace = "http://arthead.se/Reservation")]
        public string LastName { get; set; }
        [MessageBodyMember(Order = 9, Namespace = "http://arthead.se/Reservation")]
        public bool Returned { get; set; }


    }

    [MessageContract(IsWrapped = true,
       WrapperName = "ListReservationsInfoObject",
       WrapperNamespace = "http://arthead.se/Reservation")]
    public class ListReservationsInfo  
    {
        public ListReservationsInfo() { }//Om jag inte skapar en konstruktor får jag en default konstruktor men får inte det om jag skapar en och får därför inte null heller. Skapa därför en default tom konstruktor.
        //public ListReservationsInfo(ICollection<Reservation> reservations) //Tar en employee och sätter alla våra properies nedan 
        //{
        //    ReservationCollection = new List<ReservationInfo>();
        //    foreach(Reservation reserv in reservations)
        //    {
        //        ReservationInfo ri = new ReservationInfo(reserv);
        //        ReservationCollection.Add(ri);
        //    }
        //}
        public ListReservationsInfo(ICollection<ReservationInfo> reservations) //Tar en employee och sätter alla våra properies nedan 
        {
            ReservationCollection = reservations;
        }

        [MessageBodyMember(Order = 1, Namespace = "http://arthead.se/Reservation")]
        public ICollection<ReservationInfo> ReservationCollection { get; set; }

    }

    [DataContract]
    public class Reservation
    {
      
        public Reservation()
        {
            Car = new Car();
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [ForeignKey("Car")]
        public int CarId { get; set; }
        [DataMember]
        public Car Car { get; set; }

        [DataMember]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [DataMember]
        public Customer Customer { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }

        [DataMember]
        public bool Returned { get; set; }
    }
}
