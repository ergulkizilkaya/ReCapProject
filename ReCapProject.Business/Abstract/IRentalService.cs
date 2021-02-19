using Core.Utilities.Results.Abstract;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int id);
        IDataResult<List<RentalDetailDto>> GetRentalDetailsDto(int carId);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IResult CheckReturnDate(int carId);
        IResult UpdateReturnDate(int carId);
      
    }
}
