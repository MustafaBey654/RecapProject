using Business.Abstracts;
using Core.Utilities;
using DataAccess.Concrete;
using Entities.Concrete;


namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly EfColorDal _efColorDal;

        public ColorManager()
        {
            _efColorDal = new EfColorDal();
        }
    

        public IResult Add(Color color)
        {
           if(color is not null && color.Name.Length>2)
            {
                _efColorDal.Add(color);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
           
        }

        public IResult Delete(int colorId)
        {
           var car = _efColorDal.Get(c=>c.Id == colorId);
            if(car is not null)
            {
                _efColorDal.Delete(car);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IDataResult<List<Color>> GetAll()
        {
            
            return new SuccessDataResult<List<Color>>(_efColorDal.GetAll());
        }

        public IDataResult<Color> GetColorById(int carId)
        {
            var car = _efColorDal.Get(c=>c.Id==carId);
            if(car is not null)
            {
                return new SuccessDataResult<Color>(car);
            }
            else
            {
                return new ErrorDataResult<Color>();
            }
        }

        public IResult Update(Color color)
        {
            _efColorDal.Update(color);
            return new SuccessResult();

        }
    }
}
