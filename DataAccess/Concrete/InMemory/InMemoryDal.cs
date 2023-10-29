using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryDal : ICarDal
    {
        List<Car> cars;

        public InMemoryDal()
        {
            cars = new List<Car> {
            new Car{Id=0,BrandId=1,ColourId=0,ModelYear=2018,DailyPrice=470000,Description=""},
            new Car{Id=1,BrandId=3,ColourId=5,ModelYear=2020,DailyPrice=500000,Description=""},
            new Car{Id=2,BrandId=2,ColourId=3,ModelYear=2021,DailyPrice=550000,Description=""},
            new Car{Id=3,BrandId=2,ColourId=4,ModelYear=2015,DailyPrice=390000,Description=""},
            new Car{Id=4,BrandId=0,ColourId=1,ModelYear=2019,DailyPrice=410000,Description=""},
            };
        }
        public void Add(Car car)
        {
            car.Id = cars.Count;
            cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carDelete = cars.SingleOrDefault(c => c.Id == car.Id);
            cars.Remove(carDelete);
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public List<Car> GetById(int Id)
        {
            return cars.Where(x => x.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColourId = car.ColourId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
        }
    }
}
