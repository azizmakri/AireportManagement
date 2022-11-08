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
    public class ServiceTicket:Service<Ticket>,IServiceTicket
    {
        private readonly IUnitOfWork unitOfWork;

        public ServiceTicket(IUnitOfWork iunitOFWork) : base(iunitOFWork)
        {
            this.unitOfWork = iunitOFWork;
        }
    }
}
