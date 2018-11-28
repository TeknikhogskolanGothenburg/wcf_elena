using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CarRentalServiceDL
{
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
    