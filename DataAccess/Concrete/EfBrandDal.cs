
using Core.DataAccess.Eframework;
using DataAccess.Abstracts;
using Entities.Concrete;


namespace DataAccess.Concrete
{
    public class EfBrandDal:BaseRepository<Brand,EfDbContext>,IBrandDal
    {
    }
}
