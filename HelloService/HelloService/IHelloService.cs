using CarRentalServiceDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net.Security;
using System.ServiceModel.Web;

namespace HelloService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHelloService" in both code and config file together.
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract(ProtectionLevel = ProtectionLevel.None)]
        Car GetCarById(int id);

        [OperationContract(ProtectionLevel = ProtectionLevel.None)]
        Car GetCarByReg(string name);

        [OperationContract]
        Car GetCarByString(string option, string term);

        [OperationContract(ProtectionLevel = ProtectionLevel.Sign)]
        CustomerInfo GetCustomer(CustomerRequest customer);

        [OperationContract]
        void SaveCustomer(CustomerInfo employee);

        [OperationContract]
        ReservationInfo GetReservationByBrand(ReservationRequestByBrand reservation);

        [OperationContract]
        ListReservationsInfo GetReservationByDate(ReservationRequestByDate request);

        [OperationContract]
        ListReservationsInfo GetAvailableCars(ReservationRequestByDate request);

        [OperationContract]
        void DeleteCar(string regnum);

        [OperationContract]
        void DeleteCustomer(string option, string name);


    }
}
