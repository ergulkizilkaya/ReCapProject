using FluentValidation;
using ReCapProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Business.ValidationRules.FluentValidation
{
    class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Araba günlük fiyatı 0'dan büyük olmalıdır.");
            RuleFor(c => c.Name).MinimumLength(2).WithMessage("Araba ismi minimum 2 karakter olmalıdır");

        }
       
    }
}
