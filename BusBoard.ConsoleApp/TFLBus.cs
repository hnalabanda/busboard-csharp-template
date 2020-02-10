using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
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

            DisplayArrivals(response2);


        }

        private void DisplayArrivals(List<Bus> busList)
        {
            busList.Sort((Bus x,Bus y)=>  x.timeToStation.CompareTo(y.timeToStation));
            var counter = 1;
            foreach (Bus bus in busList)
            {
                if (counter == 1)
                {
                    Console.WriteLine(bus.destinationName);
                    Console.WriteLine("towards" + bus.towards);
                    Console.WriteLine("Live arrivals at " + bus.timestamp.ToString("HH:mm:ss") );
                }
                Console.Write(bus.LineName + "   ");
                Console.Write(bus.destinationName+ "   ");
                Console.Write(bus.expectedArrival.ToString("HH:mm:ss") + "   ");
                var dueTime = bus.timeToStation / 60 <= 0 ? "Due" : bus.timeToStation / 60 + "mins";
                Console.WriteLine(dueTime);
                counter += 1;
                if (counter > 5)
                {
                    break;
                }
            }
        }
    }
}