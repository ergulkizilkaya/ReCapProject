using Core.Utilities.Results.Abstract;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int p);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int p);
        IResult Update(Car car);
        IResult Delete(Car car);
        IResult Add(Car car);
    }
}
