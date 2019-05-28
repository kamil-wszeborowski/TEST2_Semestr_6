using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST2.Data;

namespace TEST2.Models
{
    public class SQLApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext context;

        public SQLApplicationUserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public ApplicationUser Delete(string Id)
        {
           ApplicationUser applicationUser = context.Users.Find(Id);
            if(applicationUser != null)
            {
                context.Users.Remove(applicationUser);
                context.SaveChanges();
            }
            return applicationUser;
        }

        public IEnumerable<ApplicationUser> GetAllApplicationUser()
        {
            return context.Users;
        }

        public ApplicationUser GetApplicationUser(string Id)
        {
            return context.Users.Find(Id);
        }

        public ApplicationUser Update(ApplicationUser applicationUserChanges)
        {
            var applicationUser = context.Users.Attach(applicationUserChanges);
            applicationUser.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return applicationUserChanges;
        }
    }
}
