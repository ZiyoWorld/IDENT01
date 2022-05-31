using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace IDENT01.Models
{
    public class AppDbInit: DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var r_administrator = new IdentityRole { Name = "Administrator" };
            var r_employer = new IdentityRole { Name = "Emp" };
            var r_guest = new IdentityRole { Name = "Guest" };

            var mir_uz = new ApplicationUser { Email = "mirziyod@gmail.com", UserName = "mirziyod@gmail.ru" };
            var ziyo_uz = new ApplicationUser { Email = "ziyo_uz@gmail.com", UserName = "ziyo_uz@gmail.ru" };


            var b_administrator = roleManager.Create(r_administrator).Succeeded;
            var b_employer = roleManager.Create(r_employer).Succeeded;
            var b_guest = roleManager.Create(r_guest).Succeeded;

            var b_mir = userManager.Create(mir_uz, "12345678").Succeeded;
            var b_ziyo = userManager.Create(ziyo_uz, "12345678").Succeeded;

            if (b_administrator && b_mir) userManager.AddToRole(mir_uz.Id, r_administrator.Name);
            if (b_employer && b_mir) userManager.AddToRole(mir_uz.Id, r_employer.Name);
            if (b_employer && b_ziyo) userManager.AddToRole(ziyo_uz.Id, r_employer.Name);

            base.Seed(context);


        }

    }
}