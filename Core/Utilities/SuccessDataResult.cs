using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        private List<Car> cars;
        private string carListed;

        public SuccessDataResult(T data, bool success, string message) : base(data, true, message)
        {
        }



        public SuccessDataResult(T data):base(data,true)
        {
            
        }

        public SuccessDataResult(T data,string message):base(data,message)
        {
            
        }


        public SuccessDataResult(string message):base(default,true,message)
        {
            
        }
        public SuccessDataResult():base(default,true)
        {
            
        }

       
    }
}
