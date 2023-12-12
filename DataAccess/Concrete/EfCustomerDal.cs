using Core.DataAccess.Eframework;
using DataAccess.Abstracts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfCustomerDal:BaseRepository<Customer,EfDbContext>,ICustomerDal
    {
    }
}
