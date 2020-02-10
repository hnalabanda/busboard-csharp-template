using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using RestSharp.Serialization.Json;

namespace BusBoard
{
    public class TFLBus
    {
        private string stopCode { get; set; }
     

        public TFLBus()
        {
            
        }

        public TFLBus(string stopCode)
        {
            this.stopCode = stopCode;
        }

        public void getNextBusTimes(string stopCode)
        {   
            var client=new RestClient("https://api.tfl.gov.uk/");
            var request=new RestRequest($"StopPoint/{stopCode}/Arrivals",Method.GET);
            List<Bus> response2 = client.Get<List<Bus>>(request).Data;
            
            response2.Sort((Bus x,Bus y)=>  x.timeToStation.CompareTo(y.timeToStation));
     
            foreach (Bus bus in response2)
            {
                Console.Write(bus.LineName + "   ");
                Console.Write(bus.destinationName+ "   ");
                Console.Write(bus.expectedArrival+ "   ");
                var dueTime = bus.timeToStation / 60 <= 0 ? "Due" : bus.timeToStation / 60 + "mins";
                Console.WriteLine(dueTime);
            
            }
       
        }
    }
}