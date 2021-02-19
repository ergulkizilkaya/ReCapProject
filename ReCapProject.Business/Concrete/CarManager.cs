using ReCapProject.DataAccess.Abstract;
using ReCapProject.Business.Abstract;
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
using FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspects.AutoFac.Validation;

namespace ReCapProject.Business.Concrete
{
    public class CarManager : ICarService
    {
        readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
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

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
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


        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
           
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);

        }
    }
}
