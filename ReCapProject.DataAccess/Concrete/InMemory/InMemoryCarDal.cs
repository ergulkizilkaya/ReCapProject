using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _carList;

        public InMemoryCarDal()
        {
            _carList = new List<Car>
            {
                new Car{ Id=1,BrandId=1,ColorId=4,DailyPrice=140,ModelYear=2014,Description="1 Nolu Araç Açıklaması" },
                new Car{ Id=2,BrandId=2,ColorId=3,DailyPrice=125,ModelYear=2012,Description="2 Nolu Araç Açıklaması" },
                new Car{ Id=3,BrandId=3,ColorId=5,DailyPrice=150,ModelYear=2015,Description="3 Nolu Araç Açıklaması" },
                new Car{ Id=4,BrandId=4,ColorId=4,DailyPrice=210,ModelYear=2018,Description="4 Nolu Araç Açıklaması" },
                new Car{ Id=5,BrandId=5,ColorId=8,DailyPrice=180,ModelYear=2016,Description="5 Nolu Araç Açıklaması" }

            };
        }

        public void Add(Car car)
        {
            _carList.Add(car);
        }

        public void Delete(Car car)
        {
            Car _deleteToCar = _carList.FirstOrDefault(c => c.Id == car.Id);
            _carList.Remove(_deleteToCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return null;
        }
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return null;
        }

        public List<CarDetailDto> GetCarDetailDtos(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car _updateToCar = _carList.FirstOrDefault(c => c.Id == car.Id);
            _updateToCar.BrandId = car.BrandId;
            _updateToCar.ColorId = car.ColorId;
            _updateToCar.DailyPrice = car.DailyPrice;
            _updateToCar.ModelYear = car.ModelYear;
            _updateToCar.Description = car.Description;
        }
    }
}
