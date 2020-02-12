using System;
using System.Collections.Generic;
using System.Linq;
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

        public void getListOfBusStops(string lon, string lat)
        {

            var client = new RestClient("https://api.tfl.gov.uk/");
            var request =
                new RestRequest($"StopPoint?radius=500&stopTypes=NaptanPublicBusCoachTram&lat={lat}&lon={lon}",
                    Method.GET);

            StopPoints response2 = client.Get<StopPoints>(request).Data;

            var stopCodes = GetStopList(response2.stopPoints);
            foreach (var stop in stopCodes)
            {
                getNextBusTimes(stop);
            }
              
            


        }

        public void getNextBusTimes(string stopCode)
        {
            var client = new RestClient("https://api.tfl.gov.uk/");
            var request = new RestRequest($"StopPoint/{stopCode}/Arrivals", Method.GET);

            List<Bus> response2 = client.Get<List<Bus>>(request).Data;

            DisplayArrivals(response2);


        }

        private void DisplayArrivals(List<Bus> busList)
        {
            busList.Sort((Bus x, Bus y) => x.timeToStation.CompareTo(y.timeToStation));
            var counter = 1;
            foreach (Bus bus in busList)
            {
                if (counter == 1)
                {
                    Console.WriteLine(bus.destinationName);
                    Console.WriteLine("towards" + bus.towards);
                    Console.WriteLine("Live arrivals at " + bus.timestamp.ToString("HH:mm:ss"));
                }

                Console.Write(bus.LineName + "   ");
                Console.Write(bus.destinationName + "   ");
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

        private string[] GetStopList(List<StopPointDetail> stopsList)
        {
            string[] stopCodes = new string[2];
            stopsList.Sort((StopPointDetail x, StopPointDetail y) => x.distance.CompareTo(y.distance));
            int counter = 0;
            foreach (StopPointDetail stopPointDetails in stopsList)
            {

                Console.Write(stopPointDetails.naptanId + "   ");
                Console.Write(stopPointDetails.indicator + "   ");
                Console.Write(stopPointDetails.distance + "   ");
                Console.WriteLine(stopPointDetails.commonName + "   ");
                stopCodes[counter] = stopPointDetails.naptanId;
                counter += 1;
                if (counter == 2)
                {
                    break;
                }
            }

            return stopCodes;
        }
    }
}
