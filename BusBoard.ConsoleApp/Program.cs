using System;

namespace BusBoard
{
    class Program
    { 
        static void Main(string[] args)
        {
            var postCode = Console.ReadLine();
            PostCode pc=new PostCode();
   
             var tflBus = new TFLBus();
             tflBus.getListOfBusStops(pc.GetLatLongFromPostCode("LO",postCode),pc.GetLatLongFromPostCode("LA",postCode));
             var stopCode = Console.ReadLine();
              tflBus.getNextBusTimes(stopCode);

        }
    }
}