using ReCapProject.Business.Abstract;

using ReCapProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.DataAccess.Abstract;
using Core.Utilities.Results.Concrete;
using ReCapProject.Business.Constants;
using Core.Utilities.Results.Abstract;
using ReCapProject.Business.ValidationRules.FluentValidation;
using System.Linq;
using Core.Aspects.AutoFac.Validation;

namespace ReCapProject.Business.Concrete
{
    public class BrandManager : IBrandService
    {
        readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
           
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.Id == id));
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
           
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

    }
}
