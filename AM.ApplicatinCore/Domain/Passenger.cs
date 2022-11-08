using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AM.ApplicatinCore.Domain
{
    public class Passenger
    {
        public int Id { get; set; }
        [Display(Name ="Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [StringLength(7)]
        public String PassportNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public String EmailAddress { get; set; }


        [MinLength(3, ErrorMessage = "longueur minimale incorrect")]
        [MaxLength(25,ErrorMessage ="longueur maximale incorrect")]
        public FullName fullName { get; set; }


        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Invalid Phone Number!")]
        public int TelNumber { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

      

        public Boolean CheckPrenomProfile(String nom, String prenom) { 
            return true;
        }

        //public Boolean CheckEmailProfile(  String nom, String prenom, String email) 
        //{
        //    if ((this.EmailAddress == email)&&(this.FirstName==prenom)&&(this.LastName==nom)) {
        //        return true;
        //        }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger") ;
        }
    }
}
