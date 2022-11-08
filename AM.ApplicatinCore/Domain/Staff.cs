using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AM.ApplicatinCore.Domain
{
    public class Staff : Passenger
    {
       

        public DateTime EmployementDate { get; set; }
        public String Function { get; set; }
        [DataType(DataType.Currency)]
        public float Salary { get; set; }

        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine(" and i'm a staff");
        }
    }
}
