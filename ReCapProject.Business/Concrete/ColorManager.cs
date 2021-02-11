using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.Business.Utilities;
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
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {



            var validationResult = ValidationTool.Validate(new ColorValidator(), color);
            if (validationResult.Errors.Count > 0)
            {
                return new ErrorResult(validationResult.Errors.Select(x => x.ErrorMessage).Aggregate((a, b) => $"--{a}\n--{b}"));
            }
            else if (_colorDal.Get(c => c.Name.ToLower() == color.Name.ToLower()) != null)
            {
                return new ErrorResult(Messages.ColorAddError);
            }
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

        public IResult Update(Color color)
        {
            var validationResult = ValidationTool.Validate(new ColorValidator(), color);
            if (validationResult.Errors.Count > 0)
            {
                return new ErrorResult(validationResult.Errors.Select(x => x.ErrorMessage).Aggregate((a, b) => $"--{a}\n--{b}"));
            }
            else if(_colorDal.Get(c => c.Name.ToLower() == color.Name.ToLower()) != null)
            {
                return new ErrorResult(Messages.ColorAddError);
            }
            _colorDal.Update(color);

            return new SuccessResult(Messages.ColorUpdated);
        }

        IDataResult<List<Color>> IColorService.GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }
    }
}
