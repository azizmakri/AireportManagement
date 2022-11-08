using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicatinCore.Domain
{
    public class Flight
    {
        public String airLine { get; set; }
        public String Destination { get; set; }
        public String Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }

        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        public int planeId { get; set; }
        [ForeignKey("planeId")]
        public virtual Plane Plane { get; set; }
        public virtual ICollection<Passenger> passes { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

        public override string? ToString()
        {
            return ("votre destination est "+ Destination+"Aire Line"+airLine);
        }
    }
}
