using AM.ApplicatinCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicatinCore.Interfaces
{
    public interface IServiceFlight
    {
        public List<DateTime> GetFlightsDates(String destination);
        public List<Flight> GetFlights(String filtreType,String filtreValue);
        public void ShowFlightDetails(Plane plane);
        public int ProgrammedFlightNumber(DateTime startDate);
        public double DurationAverage(string destination);
        public List<Flight> OrderedDurationFlights();
        public void SeniorTravellers(Flight flight);
    }
}
