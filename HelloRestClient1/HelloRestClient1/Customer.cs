using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HelloRestClient1
{
        [DataContract]
        public class Customer
        {
            [DataMember(Name = "_Id")]
            public int Id { get; set; }

            [DataMember(Name = "_FirstName")]
            public string FirstName { get; set; }

            [DataMember(Name = "_LastName")]
            public string LastName { get; set; }

            [DataMember(Name = "_Phone")]
            public string Phone { get; set; }

            [DataMember(Name = "_Email")]
            public string Email { get; set; }
        }
}