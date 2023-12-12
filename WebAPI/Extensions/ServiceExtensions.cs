using Business.Abstracts;
using Business.Concrete;
using DataAccess.Abstracts;
using DataAccess.Concrete;

namespace WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureService(this IServiceCollection services)
        {
            services.AddSingleton<IBrandService, BrandManager>();
            services.AddSingleton<IBrandDal, EfBrandDal>();   
            
            services.AddSingleton<ICarService,CarManager>();
            services.AddSingleton<ICarDal,EfCarDal>();

            services.AddSingleton<IColorService,ColorManager>();
            services.AddSingleton<IColorDal,EfColorDal>();

            services.AddSingleton<ICustomerService,CustomerManager>();
            services.AddSingleton<ICustomerDal,EfCustomerDal>();

            services.AddSingleton<IRentalService,RentalManager>();
            services.AddSingleton<IRentalDal,EfRentalDal>();

            services.AddSingleton<IUserService,UserManager>();
            services.AddSingleton<IUserDal,EfUserDal>();
        }
    }
}
