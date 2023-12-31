﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICustomerService
    {

        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
        IDataResult<Customer> GetCustomerById(int id);
        IDataResult<List<Customer>> GetAllCustomer();
    }
}
