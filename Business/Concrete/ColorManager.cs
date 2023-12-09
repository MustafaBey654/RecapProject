using Business.Abstracts;
using DataAccess.Abstracts;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly EfColorDal _efColorDal;
        public ColorManager()
        {
            _efColorDal=new EfColorDal();
        }
        public void Add(Color entity)
        {
            _efColorDal.Add(entity);
        }

        public void Delete(Color entity)
        {
           _efColorDal.Delete(entity);
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            return _efColorDal.Get(filter);
        }

        public List<Color> GetAll(Expression<Func<Color,bool>> filter=null)
        {
            return _efColorDal.GetAll();
        }

        public Color GetById(int id)
        {
          return  _efColorDal.Get(c=>c.Id == id);
        }

       

        public void Update(Color entity)
        {
            _efColorDal.Update(entity);
        }
    }
}
