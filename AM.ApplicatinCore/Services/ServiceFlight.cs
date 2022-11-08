using AM.ApplicatinCore.Domain;
using AM.ApplicatinCore.Interfaces;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicatinCore.Services
{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {
        private readonly IUnitOfWork unitOfWork;

        public ServiceFlight(IUnitOfWork iunitOFWork): base(iunitOFWork) {
            this.unitOfWork = iunitOFWork;
        }

        public List<Flight> Flights { get; set; }=new List<Flight>();

        public List<Flight> GetFlights(string filtreType, string filtreValue)
        {
            List<Flight> NewFlights= new List<Flight>();
            switch (filtreType)
            {
                case "Destination":
                    for (int i = 0; i < Flights.Count; i++)
                    {
                        if (Flights[i].Destination == filtreValue)
                        {
                            NewFlights.Add(Flights[i]);
                        }
                    }
                    break;
                case "FlightDate":
                    for (int i = 0; i < Flights.Count; i++)
                    {
                        if (Flights[i].FlightDate == DateTime.Parse(filtreValue) )
                        {
                            NewFlights.Add(Flights[i]);
                        }
                    }
                    break;

                case "EffectiveArrival":
                    for (int i = 0; i < Flights.Count; i++)
                    {
                        if (Flights[i].EffectiveArrival == DateTime.Parse(filtreValue))
                        {
                            NewFlights.Add(Flights[i]);
                        }
                    }
                    break;
                    default:
                    Console.WriteLine("chiox invalide");
                    break;
            }
            return NewFlights;
        }

        public List<DateTime> GetFlightsDates(string destination)
        {
            List<DateTime> dates =new List<DateTime>();
            //for (int i = 0; i < Flights.Count; i++)
            //{
            //    if(Flights[i].Destination == destination)
            //    {
            //        dates.Add(Flights[i].FlightDate);
            //    }
            //}
            //return dates;
            var requete =
            from flight in Flights
            where (flight.Destination == destination)
            select flight.FlightDate;
            return requete.ToList();
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            int i = 0;
            var requete=
                from flight in Flights
                where(DateTime.Parse(flight.Departure)<=startDate.AddDays(7))
                select i++;
            return i;
        }

        public void ShowFlightDetails(Plane plane)
        {

            // sans experession lambda 
            var Querry = from F in Flights
                         where F.Plane == plane
                         select new
                         {
                             F.Destination,
                             F.FlightDate
                         };
            foreach (var F in Querry)
            {
                Console.WriteLine("Distination = " + F.Destination, " FlightDate =  " + F.FlightDate);
            }

            // Avec Fonction lambda : 

            //var Query2 = Flights.Where(F => F.Plane == plane).Select(F => new { F.Destination, F.FlightDate });
        }
        public double DurationAverage(string destination)
        {
            var requete =
                from flight in Flights
                where (flight.Destination == destination)
                select flight.EstimatedDuration;
            return requete.Average();
        }

        public List<Flight> OrderedDurationFlights()
        {
            var requete =
                from flight in Flights
                orderby flight.EstimatedDuration descending
                select flight;
            return requete.ToList();
        }
        public void SeniorTravellers(Flight flight)
        {
            var requete =
                (from p in flight.passes.OfType<Traveller>()
                orderby p.BirthDate
                select p).Take(3);
        }

        public void DestinationGroupedByFlights()
        {
            //var requete = (from f in Flights group f by f.Destination);
            //foreach(var des in requete)
            //{
            //  Console.Write("destination"+des.Key);
            //    foreach(var f in Flights)
            //    {
            //        Console.Write("decollage: " + f.EffectiveArrival);
            //    }
            //}

            var GroupByDest = Flights.GroupBy(f1 => f1.Destination);
            foreach (var des in GroupByDest)
            {
                Console.Write("destination " + des.Key + "\n");
                foreach (var f1 in Flights)
                {
                    Console.Write("  décollage " + f1.EffectiveArrival + "\n");
                }
            }
        }
        /*
        public Action<Plane> FlightDetailDel;
        public Func<string, double> DurationAverageDel;

        public ServiceFlight()
        {
            FlightDetailDel = ShowFlightDetails;

            DurationAverageDel = dest =>
            {
                return (from f in Flights
                        where f.Destination.Equals(dest)
                        select f.EstimatedDuration).Average();
            };
        }*/


    }
}
