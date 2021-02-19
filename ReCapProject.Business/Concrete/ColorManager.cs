using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.Business.ValidationRules.FluentValidation;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReCapProject.Business.Concrete
{
    public class ColorManager : IColorService
    {
        readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
           
            _colorDal.Add(color);

            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public IDataResult<Color> GetById(int id)
        {

            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id));

        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
           
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }

        IDataResult<List<Color>> IColorService.GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }
    }
}
