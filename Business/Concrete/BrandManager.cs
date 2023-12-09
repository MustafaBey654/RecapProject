


using Business.Abstracts;
using DataAccess.Concrete;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly EfBrandDal _efBrandDal;
        public void Add(Brand entity)
        {
            _efBrandDal.Add(entity);
        }

        public void Delete(Brand entity)
        {
            _efBrandDal.Delete(entity);
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            return _efBrandDal.Get(filter);
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return _efBrandDal.GetAll();
        }

       

        public Brand GetById(Expression<Func<Brand, bool>> filter)
        {
            return _efBrandDal.Get(filter);
        }

        public void Update(Brand entity)
        {
            _efBrandDal.Update(entity);
        }
    }
}
