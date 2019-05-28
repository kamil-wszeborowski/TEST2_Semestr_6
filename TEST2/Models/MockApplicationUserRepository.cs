using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TEST2.Models
{
    public class MockApplicationUserRepository : IApplicationUserRepository
    {
        private List<ApplicationUser> _applicationUsersList;

        public MockApplicationUserRepository()
        {
            _applicationUsersList = new List<ApplicationUser>() {
              /*  new ApplicationUser() { Id = "10", UserName = "aa@aa.aa", NormalizedUserName = "AA@AA.AA", Email = "aa@aa.aa",
                    NormalizedEmail = "AA@AA.AA", EmailConfirmed = false, PasswordHash = "AQAAAAEAACcQAAAAEC6eruDIsEjlOdR1+L8K0/B/FmJluMK98sw/AnfWyOCunVWguOkWn1kVx9vCIcKAeQ==",
                    SecurityStamp = "EGO4IBERHMU5Z4WVBIYHUSNHWWBH2PUA", ConcurrencyStamp = "4c7f9add-42c7-4263-9237-1d3dc523a870",
                    PhoneNumber=null, PhoneNumberConfirmed=true, TwoFactorEnabled=true, LockoutEnd=null, LockoutEnabled=true, AccessFailedCount=1, DateOfBirth=DateTime.Parse("1994-07-17"), FirstName="Kamil2", LastName="Wszeborowski2", Pesel=94071705559 }*/
                
                new ApplicationUser() { Id = "11", UserName = "ff@ff.ff", Email = "ff@ff.ff",
                    PhoneNumber="12345678", DateOfBirth=DateTime.Parse("1994-07-17"), FirstName="Maciek", LastName="Nowak", Pesel=94071705559 }

            };
        }

        public ApplicationUser Delete(string Id)
        {
            ApplicationUser applicationUser = _applicationUsersList.FirstOrDefault(u => u.Id == Id);
            if(applicationUser != null)
            {
                _applicationUsersList.Remove(applicationUser);
            }
            return applicationUser;
        }

        public IEnumerable<ApplicationUser> GetAllApplicationUser()
        {
            return _applicationUsersList;
        }

        public ApplicationUser GetApplicationUser(string Id)
        {
            return _applicationUsersList.FirstOrDefault(u => u.Id == Id);
        }

        public ApplicationUser Update(ApplicationUser applicationUserChanges)
        {
            ApplicationUser applicationUser = _applicationUsersList.FirstOrDefault(u => u.Id == applicationUserChanges.Id);
            if (applicationUser != null)
            {
                applicationUser.UserName = applicationUserChanges.UserName;
                applicationUser.Email = applicationUserChanges.Email;
                applicationUser.FirstName = applicationUserChanges.FirstName;
                applicationUser.LastName = applicationUserChanges.LastName;
                applicationUser.Pesel = applicationUserChanges.Pesel;
                applicationUser.DateOfBirth = applicationUserChanges.DateOfBirth;
            }
            return applicationUser;
        }
    }
}
