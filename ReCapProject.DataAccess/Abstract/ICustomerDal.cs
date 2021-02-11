using Core.DataAccess;
using ReCapProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.DataAccess.Abstract
{
    public interface ICustomerDal: IEntityRepository<Customer>
    {
    }
}
