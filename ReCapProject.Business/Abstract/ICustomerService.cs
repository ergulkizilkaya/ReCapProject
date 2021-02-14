using Core.Utilities.Results.Abstract;
using ReCapProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int id);
        IResult Add(Customer user);
        IResult Update(Customer user);
        IResult Delete(Customer user);
    }
}
