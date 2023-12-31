﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IResult AddRental(Rental rental);
        IResult RemoveRental(Rental rental);
        IDataResult<Rental> GetRentalById(int id);
        IResult UpdateRental(Rental rental);
    }
}
