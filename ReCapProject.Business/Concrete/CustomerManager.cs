using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer user)
        {
            _customerDal.Add(user);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer user)
        {
            _customerDal.Delete(user);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id));

        }

        public IResult Update(Customer user)
        {
            _customerDal.Update(user);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
