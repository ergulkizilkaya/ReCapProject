using ReCapProject.Business.Abstract;

using ReCapProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.DataAccess.Abstract;
using Core.Utilities.Results.Concrete;
using ReCapProject.Business.Constants;
using Core.Utilities.Results.Abstract;
using ReCapProject.Business.Utilities;
using ReCapProject.Business.ValidationRules.FluentValidation;
using System.Linq;

namespace ReCapProject.Business.Concrete
{
    public class BrandManager : IBrandService
    {
        readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            var validationResult = ValidationTool.Validate(new BrandValidator(), brand);
            if (validationResult.Errors.Count > 0)
            {
                return new ErrorResult(validationResult.Errors.Select(x => x.ErrorMessage).Aggregate((a, b) => $"--{a}\n--{b}"));
            }
            else if (_brandDal.Get(c => c.Name.ToLower() == brand.Name.ToLower()) != null)
            {
                return new ErrorResult(Messages.ColorAddError);
            }
            _brandDal.Add(brand);

            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IResult Update(Brand brand)
        {
            var validationResult = ValidationTool.Validate(new BrandValidator(), brand);
            if (validationResult.Errors.Count > 0)
            {
                return new ErrorResult(validationResult.Errors.Select(x => x.ErrorMessage).Aggregate((a, b) => $"--{a}\n--{b}"));
            }
            else if (_brandDal.Get(c => c.Name.ToLower() == brand.Name.ToLower()) != null)
            {
                return new ErrorResult(Messages.BrandAddError);
            }
            _brandDal.Update(brand);

            return new SuccessResult(Messages.BrandUpdated);
        }

    }
}
