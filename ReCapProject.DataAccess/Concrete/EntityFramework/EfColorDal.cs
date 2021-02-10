using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;
using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
    public class EfColorDal:EfEntityRepositoryBase<Color,CarProjectContext>,IColorDal
    {
    }
}
