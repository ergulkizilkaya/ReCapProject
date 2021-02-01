using ReCapProject.Business.Abstract;
using ReCapProject.Business.Concrete;
using ReCapProject.DataAccess.Concrete.InMemory;
using ReCapProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.ConsoleUI
{
    class Program
    {
        static ICarService _carDal = new CarManager(new InMemoryCarDal());
        static void Main(string[] args)
        {
            Console.WriteLine("\nGetById");
            GetById();
            Console.WriteLine("\nGetAll");
            GetAll();
            Console.WriteLine("\nAdd");
            Add();
            GetAll();
            Console.WriteLine("\nUpdate ( id : 4)");
            Update();
            GetAll();
            Console.WriteLine("\nDelete ( id : 1)");
            Delete();
            GetAll();
            Console.ReadKey();
        }
        static void GetById()
        {
            Car car = _carDal.GetById(1);
                Console.WriteLine(String.Format("Id : {0}, B : {1}, C : {2}, MY : {3}, DP : {4}, Des : {5}",
                    car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));

        }
        static void GetAll()
        {
            foreach (Car car in _carDal.GetAll())
            {
                Console.WriteLine(String.Format("Id : {0}, B : {1}, C : {2}, MY : {3}, DP : {4}, Des : {5}",
                    car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));
            }

        }
        static void Add()
        {
            Car car = new Car { Id = 6, BrandId = 4, ColorId = 6, DailyPrice = 100, ModelYear = 2013, Description = "6 Nolu Araç Açıklaması" };
            _carDal.Add(car);
           

        }
        static void Update()
        {
            Car car = new Car();
            car.Id = _carDal.GetById(4).Id;
            car.BrandId = 7;
            car.ColorId = 8;
            car.DailyPrice = 300;
            car.ModelYear = 2019;
            car.Description = _carDal.GetById(4).Description + "_updated";

            _carDal.Update(car);


        }
        static void Delete()
        {
       
            _carDal.Delete(_carDal.GetById(6));


        }
    }

}

