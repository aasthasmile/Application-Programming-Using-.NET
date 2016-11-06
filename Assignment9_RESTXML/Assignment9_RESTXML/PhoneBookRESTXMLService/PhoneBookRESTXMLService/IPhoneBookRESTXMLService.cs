using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PhoneBookRESTXMLService
{
   [ServiceContract]
   public interface IPhoneBookRESTXMLService
   {
       // add an entry to the phone book database
       [OperationContract]
       [WebGet(UriTemplate = "/AddEntry/{LastName}/{FirstName}/{PhoneNumber}")]
        void AddEntry(string LastName, string FirstName, string PhoneNumber);

        // retrieve phone book entries with a given last name
        [OperationContract]
        [WebGet(UriTemplate = "/GetEntry/{LastName}")]
        IQueryable<PhoneBook> GetEntry(string LastName);

   } // end interface IPhoneBookRESTXMLService
}

