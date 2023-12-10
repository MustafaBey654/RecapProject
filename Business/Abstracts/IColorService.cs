using Core.Utilities;
using DataAccess.Abstracts;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetColorById(int carId);
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(int colorId);

        
    }
}
