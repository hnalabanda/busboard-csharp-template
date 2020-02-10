using System;

namespace BusBoard
{
    class Program
    { 
        static void Main(string[] args)
        {
            var stopCode = Console.ReadLine();
            var tflBus = new TFLBus(stopCode);
            tflBus.getNextBusTimes(stopCode);
            
        }
    }
}