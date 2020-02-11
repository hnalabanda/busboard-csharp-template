using System;
using RestSharp;
using System.Collections.Generic;
namespace BusBoard
{
    public class PostCode
    {
        
        private RestClient Client { get;set; }
        private RestRequest Request { get;set; }

        public PostCodeResult result { get;set; }

        public PostCode()
        {
            Client=new RestClient("http://api.postcodes.io/");
          
        }
        
        public string GetLatLongFromPostCode(string lineType, string postCode)
        {
            Request=new RestRequest($"postcodes/{postCode}",Method.GET);
            var response = Client.Get<PostCode>(Request).Data;
            string result = "";
            if (lineType == "LA")
            {
               
                result= response.result.latitude;
            }

            if (lineType == "LO")
            {  
                result= response.result.latitude;
            }

            return result;
        }
        
      

    }
   
}