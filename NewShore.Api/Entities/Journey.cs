using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Journey
    {
        public string origin { get; set; }
        public string destination { get; set; }
        public decimal price { get; set; }
        public List<JourneyFlight> flights { get; set; }
    }

    public class JourneyFlight
    {
        public string origin { get; set; }
        public string destination { get; set; }
        public decimal price { get; set; }
        public JourneyTransport transport { get; set; }
    }
    
    public class JourneyTransport
    {
        public string flightCarrier { get; set; }
        public string flightNumber { get; set; }
    }
}
