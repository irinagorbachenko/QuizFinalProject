using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using QuizFinalProject.DataBase.Models;

namespace QuizFinalProject.DataBase.DataAccessLayer
{
   
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }



            static ApplicationDbContext()
            {
                Database.SetInitializer<ApplicationDbContext>(new QuizInitializer());

            }

            public DbSet<Test> Tests { get; set; }
            public DbSet<Answer> Answers { get; set; }
            public DbSet<Question> Questions { get; set; }
            public DbSet<Category> Categories { get; set; }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }

        }
    }
