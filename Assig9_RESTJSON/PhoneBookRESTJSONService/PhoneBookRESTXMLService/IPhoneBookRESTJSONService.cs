using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PhoneBookRESTJSONService
{
   [ServiceContract]
   public interface IPhoneBookRESTJSONService
   {
      // add an entry to the phone book database
      [OperationContract]
      [WebGet(ResponseFormat = WebMessageFormat.Json,UriTemplate ="/AddEntry/{LastName}/{FirstName}/{PhoneNumber}")]
        void AddEntry(string LastName, string FirstName, string PhoneNumber);

        // retrieve phone book entries with a given last name
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetEntries/{LastName}")]
        PhoneBook[] GetEntries(string LastName);
    } // end interface IPhoneBookRESTXMLService
}

