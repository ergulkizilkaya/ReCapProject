using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;
using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join br in context.Brands
                             on c.BrandId equals br.Id
                             select new CarDetailDto {
                                 Id = c.Id,
                                 BrandId =br.Id,
                                 BrandName =br.Name,
                                 Name =c.Name,
                                 ColorId =co.Id,
                                 ColorName =co.Name,
                                 DailyPrice =c.DailyPrice,
                                 Description =c.Description,
                                 ModelYear =c.ModelYear };
             
               return result.ToList();
            }
        }
    }
}
