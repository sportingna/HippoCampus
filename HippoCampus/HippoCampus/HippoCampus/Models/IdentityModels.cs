using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity.Infrastructure;

namespace HippoCampus.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            SetDataBase(context);
            return new ApplicationDbContext();
        }

        private static async Task<ApplicationDbContext> SetDataBase(ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Administrator"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Id = "admin", Name = "Administrator" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Student Worker"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Id = "wrkr", Name = "Student Worker" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.Email == "test@test.com"))
            {
                string roleName = "Administrator";
                string password = "Password123!";
                var user = new ApplicationUser { UserName = "test@test.com", Email = "test@test.com" };

                try
                {
                    context.Users.Add(user);
                    context.SaveChanges();

                    
                    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                    UserManager.AddToRole(user.Id, roleName);
                    var result = await UserManager.AddPasswordAsync(user.Id, password);

                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                                    validationError.PropertyName,
                                                    validationError.ErrorMessage);
                        }
                    }
                }
                catch (DbUpdateException dbUEx)
                {
                    dbUEx.InnerException.Message.ToString();
                }

            }
            return context;
        }


        public System.Data.Entity.DbSet<HippoCampus.Models.FutureStudentModel> FutureStudentModels { get; set; }
        public System.Data.Entity.DbSet<HippoCampus.Models.InternStudentModel> InternStudentModels { get; set; }

        public System.Data.Entity.DbSet<HippoCampus.Models.StudentWorkerModel> StudentWorker { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<StudentWorkerModel>().ToTable("StudentWorker");
            modelBuilder.Entity<InternStudentModel>().ToTable("InternStudent");
            modelBuilder.Entity<FutureStudentModel>().ToTable("FutureStudent");
        }
    }
}