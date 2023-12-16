


using Business.Abstracts;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Concrete;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly EfBrandDal _efBrandDal;

        public BrandManager()
        {
            _efBrandDal = new EfBrandDal();
        }

        public IResult Add(Brand brand)
        {
            if (brand is not null && brand.Name.Length>2)
            {
                _efBrandDal.Add(brand);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IResult Delete(int brandId)
        {
            var brand = _efBrandDal.Get(b=>b.Id == brandId);
            if(brand is not null)
            {
                _efBrandDal.Delete(brand);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_efBrandDal.GetAll());
        }

        public IDataResult<Brand> GetBrandById(int brandId)
        {
            var brand = _efBrandDal.Get(b=>b.Id==brandId);
            if (brand is not null)
            {
                return new SuccessDataResult<Brand>(brand);
            }
            else
            {
                return new ErrorDataResult<Brand>();
            }
        }

        public IResult Update(Brand brand)
        {
            var myBrand = _efBrandDal.Get(b => b.Id == brand.Id);
            if (myBrand is not null)
            {
                _efBrandDal.Update(brand); 
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }
    }
}
