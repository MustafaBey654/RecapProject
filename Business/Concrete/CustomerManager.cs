using Business.Abstracts;
using Core.Utilities;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        EfCustomerDal _efCustomer;
        public CustomerManager()
        {
            _efCustomer = new EfCustomerDal();
        }
        public IResult Add(Customer customer)
        {
            _efCustomer.Add(customer);
            return new SuccessResult();
        }

        public IResult Delete(Customer customer)
        {
            var myCustomer = _efCustomer.Get(c=>c.CustomerId == customer.CustomerId);
            if (myCustomer != null)
            {
                _efCustomer.Delete(myCustomer);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IDataResult<List<Customer>> GetAllCustomer()
        {
            return new SuccessDataResult<List<Customer>>(_efCustomer.GetAll());
        }

        public IDataResult<Customer> GetCustomerById(int id)
        {
            var customer = _efCustomer.Get(c=>c.CustomerId == id);
            if (customer != null)
            {
                return new SuccessDataResult<Customer>(customer);
            }
            else
            {
                return new ErrorDataResult<Customer>();
            }
        }

        public IResult Update(Customer customer)
        {
            var Mycustomer = _efCustomer.Get(c => c.CustomerId == customer.CustomerId);
            if (customer != null)
            {
               
                Mycustomer.UserId = customer.UserId;
                Mycustomer.CompanyName= customer.CompanyName;

                _efCustomer.Update(Mycustomer);

                return new SuccessDataResult<Customer>(customer);
            }
            else
            {
                return new ErrorDataResult<Customer>();
            }
        }
    }
}
