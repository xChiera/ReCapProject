using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
        }
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new InMemoryDal());
            List<Colour> colours = new List<Colour> {
                new Colour { ColourId = 0, ColourName="Black"},
                new Colour { ColourId = 1, ColourName="White"},
                new Colour { ColourId = 2, ColourName="Red"},
                new Colour { ColourId = 3, ColourName="Blue"},
                new Colour { ColourId = 4, ColourName="Yellow"},
                new Colour { ColourId = 5, ColourName="Brown"},
                new Colour { ColourId = 6, ColourName="Grey"}
            };
            List<Brand> brands = new List<Brand> {
                new Brand { BrandId = 0, BrandName="Bugatti"},
                new Brand { BrandId = 1, BrandName="Ferrari"},
                new Brand { BrandId = 2, BrandName="Lamborgini"},
                new Brand { BrandId = 3, BrandName="BMW"},
                new Brand { BrandId = 4, BrandName="Mercedes"},
                new Brand { BrandId = 0, BrandName="Alfa Romeo"},
                new Brand { BrandId = 0, BrandName="Maserati"}
            };
            carManager.Add(new Car { BrandId = 1, ColourId = 3, ModelYear = 2013, DailyPrice = 340000, Description = "This car is awesome!" });
            carManager.Delete(new Car { Id = 4, BrandId = 0, ColourId = 1, ModelYear = 2019, DailyPrice = 410000, Description = "" });
            carManager.Update(new Car { Id = 3, BrandId = 2, ColourId = 2, ModelYear = 2022, DailyPrice = 422000, Description = "This car's maximum speed is 420km/h." });
            foreach (var car in carManager.GetAll())
            {
                if (car.Description == "")
                    car.Description = "This car does not have any description.";
                Console.WriteLine(car.Id+"-"+ BrandName(car.BrandId, brands)+"-"+ ColourName(car.ColourId,colours)+"-"+car.ModelYear+"-"+car.DailyPrice+"-"+car.Description);  
            }
            List<Car> carById = carManager.GetById(1);
            foreach (var car in carById)
            {
                Console.WriteLine(@"This car writed with 'GetById' fuvnction. -->" + car.Id + "-" + BrandName(car.BrandId, brands) + "-" + ColourName(car.ColourId, colours) + "-" + car.ModelYear + "-" + car.DailyPrice + "-" + car.Description);
            }
            

        }
        private static string BrandName(int id, List<Brand> brands) { 
            foreach (var brand in brands)
            {
                if(id==brand.BrandId)
                    return brand.BrandName;
            }
            return "Undefined Brand.";
        }
        private static string ColourName(int id, List<Colour> colours)
        {
            foreach (var colour in colours)
            {
                if (id == colour.ColourId)
                    return colour.ColourName;
            }
            return "Undefined Brand.";
        }
    }
}
