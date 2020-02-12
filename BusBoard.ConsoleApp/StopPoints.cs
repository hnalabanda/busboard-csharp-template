using System.Collections.Generic;
namespace BusBoard
{
    public class StopPoints
    {
        public List<StopPointDetail> stopPoints { get;set; }
    }
    
    public class StopPointDetail
    {
        public string naptanId{ get; set; }
        public string indicator{ get; set; }
        public double distance{ get; set; }
        public string commonName{ get; set; }
    }
}