using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicatinCore.Domain
{
    public class Plane
    {
        [Range(0,int.MaxValue)]
        public int Capacity { get; set; } 
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }

        public virtual ICollection<Flight> Flights{ get; set; }

       // public Plane(string planeType,int capacity, DateTime manufactureDate)
       // {
       //     Capacity = capacity;
       //     ManufactureDate = manufactureDate;
      //      PlaneType = planeType;
      //  }

    }


    public enum PlaneType
    {
        Boing,
        Airbus
    }
}
