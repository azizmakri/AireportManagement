using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicatinCore.Domain
{
    public class Ticket
    {
        public double prix { get; set; }
        public string siege { get; set; }
        public Boolean vip { get; set; }
        public int flightFK { get; set; }
        public int numTicket { get; set; }
        public int passengerFk { get; set; }
        public virtual Flight Flight { get; set; }
        public virtual Passenger Passenger { get; set; }
    }
}
