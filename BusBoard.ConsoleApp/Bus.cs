﻿namespace BusBoard
{
    public class Bus
    {
  
        public string id;
        public string operationType;
        public string vehicleId;
        public string naptanId;
        public string stationName { get; set; }
        public string lineId;
        public string LineName { get; set; }
        public string platformName;
        public string direction;
        public string bearing;
        public string destinationNaptanId;
        public string destinationName { get; set; }
        public string timestamp;
        public int timeToStation{ get; set; }
        public string currentLocation;
        public string towards;
        public string expectedArrival { get; set; }
        public string timeToLive;
        public string modeName;
       
       
    }
}