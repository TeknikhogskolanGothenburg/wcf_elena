using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace CarRentalServiceDL
{

    [MessageContract(IsWrapped = true,
     WrapperName = "CarInfoObject",
     WrapperNamespace = "http://arthead.se/Car")]
    public class CarInfo 
    {
        public CarInfo() { }
        public CarInfo(Car car) 
        {
            this.Id = car.Id;
            this.Brand = car.Brand;
            this.Model = car.Model;
            this.Year = car.Year;
            this.Regnumber = car.Regnumber;
        }

        [MessageBodyMember(Order = 1, Namespace = "http://arthead.se/Customer")]
        public int Id { get; set; }
        [MessageBodyMember(Order = 2, Namespace = "http://arthead.se/Customer")]
        public string Brand { get; set; }
        [MessageBodyMember(Order = 3, Namespace = "http://arthead.se/Customer")]
        public string Model { get; set; }
        [MessageBodyMember(Order = 4, Namespace = "http://arthead.se/Customer")]
        public int Year { get; set; }
        [MessageBodyMember(Order = 5, Namespace = "http://arthead.se/Customer")]
        public string Regnumber { get; set; }

    }

    [DataContract]
    public class Car
    {
        [DataMember(Name = "_Id")]
        public int Id { get; set; }

        [DataMember(Name = "_Brand")]
        public string Brand { get; set; }

        [DataMember(Name = "_Model")]
        public string Model { get; set; }

        [DataMember(Name = "_Year")]
        public int Year { get; set; }

        [DataMember(Name = "_Regnumber")]
        public string Regnumber { get; set; }
    }
}
    