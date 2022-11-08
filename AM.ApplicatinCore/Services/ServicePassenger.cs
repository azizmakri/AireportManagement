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
    public class ServicePassenger:Service<Passenger>,IServicePassenger
    {
        private readonly IUnitOfWork unitOfWork;

        public ServicePassenger(IUnitOfWork iunitOFWork) : base(iunitOFWork)
        {
            this.unitOfWork = iunitOFWork;
        }
    }
}
