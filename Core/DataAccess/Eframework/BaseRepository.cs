

using Entities.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Eframework
{
    public class BaseRepository<T, EFContext> : IEntityRepository<T> where T : class, IEntity, new()
        where EFContext : DbContext, new()
    {

        public void Add(T entity)
        {
            using (var context = new EFContext())
            {
               var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var context = new EFContext())
            {
               var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

      

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (var context = new EFContext())
            {
                return filter == null
                    ? context.Set<T>().ToList()
                    : context.Set<T>().Where(filter).ToList();
            }
        }

        public T Get(Expression<Func<T,bool>> filter)
        {
            using (var context = new EFContext())
            {
                return context.Set<T>().SingleOrDefault(filter);
            }
        }

       

        public void Update(T entity)
        {
            using (var context = new EFContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
