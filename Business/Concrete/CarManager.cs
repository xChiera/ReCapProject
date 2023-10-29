    using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : IcarService
    {
        ICarDal carDal;
        public CarManager(ICarDal carDal)
        {
            this.carDal = carDal;
        }

        public List<Car> GetAll()
        {
            //Business codes
            return carDal.GetAll();
        }
        public List<Car> GetById(int id)
        {
            return carDal.GetById(id);
        }

        public void Add(Car car)
        {
            //Business codes
            carDal.Add(car);
        }

        public void Delete(Car car)
        {
            //Business codes
            carDal.Delete(car);
        }
        
        public void Update(Car car)
        {
            carDal.Update(car);
        }
    }
}
