using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Entities;
using static System.Data.Entity.Database;

namespace DLL.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("RestApiTestDB")
        {
            SetInitializer(new MovieDBInitializer());
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasRequired<Status>(m => m.Status).WithMany(g => g.Users);

            base.OnModelCreating(modelBuilder);
        }

        public class MovieDBInitializer : DropCreateDatabaseAlways<AppDbContext>
        {

            protected override void Seed(AppDbContext context)
            {
                var status1 = new Status() {Statuses = "Masturbating"};
                var status2 = new Status() { Statuses = "Idle"};
                var status3 = new Status() { Statuses = "Smokin' crack"};
                var status4 = new Status() { Statuses = "GET GUD!"};

                context.Statuses.Add(status1);
                context.Statuses.Add(status2);
                context.Statuses.Add(status3);
                context.Statuses.Add(status4);

                var user1 = new User()
                {
                    FirstName = "Morten",
                    LastName = "Greis",
                    BirthDate = DateTime.Now.AddYears(-25),
                    Gender = false,
                    Status = status3
                    
                };
                context.Users.Add(user1);
               

                var user2 = new User()
                {
                    FirstName = "Nicolai",
                    LastName = "Mensel",
                    BirthDate = DateTime.Now.AddYears(-50),
                    Gender = true,
                    Status = status1

                };
                context.Users.Add(user2);
                

                var user3 = new User()
                {
                    FirstName = "Noah",
                    LastName = "Bock",
                    BirthDate = DateTime.Now.AddYears(-15),
                    Gender = false,
                    Status = status4

                };
                context.Users.Add(user3);
                

                var user4 = new User()
                {
                    FirstName = "Bille",
                    LastName = "Iversen",
                    BirthDate = DateTime.Now.AddYears(-5),
                    Gender = false,
                    Status = status2

                };
                context.Users.Add(user4);
               
                base.Seed(context);
            }
        }
    }
}