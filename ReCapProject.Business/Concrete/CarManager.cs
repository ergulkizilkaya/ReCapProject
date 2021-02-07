using ReCapProject.Business.Abstract;
using ReCapProject.Business.Utilities;
using ReCapProject.Business.ValidationRules.FluentValidation;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Business.Concrete
{
    public class CarManager : ICarService
    {

        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            ValidationTool.Validate(new CarValidator(),car);
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetailDto()
        {
            return _carDal.GetCarDetailDtos();
        }

        public List<CarDetailDto> GetCarsByBrandId(int v)
        {
            return _carDal.GetCarDetailDtos(x=>x.BrandId == v);
        }
        public List<CarDetailDto> GetCarsByColorId(int v)
        {
            return _carDal.GetCarDetailDtos(x => x.ColorId == v);
        }

        public void Update(Car car)
        {
            ValidationTool.Validate(new CarValidator(), car);
            _carDal.Update(car);
        }
    }
}
