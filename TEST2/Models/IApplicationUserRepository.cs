using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST2.Models
{
    public interface IApplicationUserRepository
    {
        ApplicationUser GetApplicationUser(string Id);
        IEnumerable<ApplicationUser> GetAllApplicationUser();
        ApplicationUser Update(ApplicationUser applicationUserChanges);
        ApplicationUser Delete(string Id);

    }
}
