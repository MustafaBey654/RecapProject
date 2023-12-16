using Business.Abstracts;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        EfUserDal _efUserDal;
        public UserManager()
        {
            _efUserDal = new EfUserDal();
        }
        public IResult Add(User user)
        {
            _efUserDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            var myUser = _efUserDal.Get(u=>u.Id ==  user.Id);
            if(myUser != null)
            {
                _efUserDal.Delete(myUser);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IDataResult<List<User>> GetAllUser()
        {
            return new SuccessDataResult<List<User>>(_efUserDal.GetAll());
        }

        public IDataResult<User> GetUserById(int id)
        {
            var user = _efUserDal.Get(u=>u.Id ==  id);
            if(user != null)
            {
                return new SuccessDataResult<User>(user);
            }
            else
            {
                return new ErrorDataResult<User>();
            }
        }

        public IResult Update(User user)
        {
            var myUSer = _efUserDal.Get(u=>u.Id==user.Id);
            if(myUSer != null)
            {
                myUSer.FirstName = user.FirstName;
                myUSer.LastName = user.LastName;
                myUSer.Email = user.Email;
                myUSer.Password = user.Password;

                _efUserDal.Update(myUSer);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }
    }
}
