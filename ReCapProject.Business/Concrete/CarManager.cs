using ReCapProject.DataAccess.Abstract;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Utilities;
using ReCapProject.Business.ValidationRules.FluentValidation;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using System.Linq;
using ReCapProject.Business.Constants;

namespace ReCapProject.Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            var validationResult = ValidationTool.Validate(new CarValidator(), car);
            if (validationResult.Errors.Count > 0)
            {
                return new ErrorResult(validationResult.Errors.Select(x => x.ErrorMessage).Aggregate((a, b) => $"--{a}\n--{b}"));
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int p)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == p));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int p)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == p));
        }

        public IResult Update(Car car)
        {
            var validationResult = ValidationTool.Validate(new CarValidator(), car);
            if (validationResult.Errors.Count > 0)
            {
                return new Result(false, validationResult.Errors.Select(x=>x.ErrorMessage).Aggregate((a,b)=>$"--{a}\n--{b}"));
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);

        }
    }
}
