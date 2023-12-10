﻿using Core.Utilities;
using DataAccess.Abstracts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetColorById(int carId);
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(int brandId);
    }
}
