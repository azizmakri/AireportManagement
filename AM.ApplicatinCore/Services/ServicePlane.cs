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
    public class ServicePlane : Service<Plane>,IServicePlane
    {
        /*private IGenericRepository<Plane> genericRepository;

        public ServicePlane (IGenericRepository<Plane> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public void Add(Plane plane)
        {
            genericRepository.Add(plane);
        }

        public IList<Plane> GetAll()
        {
            return genericRepository.GetAll().ToList();
        }

        public void Remove(Plane plane)
        {
            genericRepository.Delete(plane);
        }
    }*/
        private IUnitOfWork unitOfWork;

        public ServicePlane(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

      /*  public void Add(Plane plane)
        {
            unitOfWork.Repository<Plane>().Add(plane);
        }

        public IList<Plane> GetAll()
        {
            return unitOfWork.Repository<Plane>().GetAll().ToList();
        }

        public void Remove(Plane plane)
        {
            unitOfWork.Repository<Plane>().Delete();
        }

        public void Update(Plane plane)
        {
            unitOfWork.Repository<Plane>().Update(plane);
        }
      */
    }
}
