﻿using Core.DataAccess.Eframework;
using DataAccess.Abstracts;

using Core.Entities.Concrete;


namespace DataAccess.Concrete
{
    public class EfUserDal : BaseRepository<User, EfDbContext>, IUserDal
    {
       

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new EfDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.Id
                    select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        
    }
}
