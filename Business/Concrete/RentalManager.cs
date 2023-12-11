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
    public class RentalManager : IRentalService
    {
        EfRentalDal _efRentalDal;

        public RentalManager()
        {
            _efRentalDal = new EfRentalDal();
        }

        //Eğer araba kirlanma tarihi null ise araba kiralanabilir.
        public IResult AddRental(Rental rental)
        {
            if(rental.ReturnDate != null)
            {
                _efRentalDal.Add(rental);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_efRentalDal.GetAll());
        }

        //Eğer araba kiralama tarihi mevcut tarihten önce ise bu kiralamayı sil
        public IResult RemoveRental(Rental rental)
        {
            if(rental.ReturnDate >= DateTime.Now)
            {
                _efRentalDal.Delete(rental);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }
    }
}
