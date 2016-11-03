using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Entities;
using DLL.Context;

namespace DLL.Manager
{
    public class UserManager
    {
        public User Create(User t)
        {
            using (var dbContext = new Context.AppDbContext())
            {
                dbContext.Users.Add(t);
                dbContext.SaveChanges();
                return t;
            }
        }

        public User Read(int id)
        {
            using (var dbContext = new Context.AppDbContext())
            {
                var m = dbContext.Users.Include("Status").FirstOrDefault(x => x.Id == id);
                return m;
            }
        }

        public List<User> ReadAll()
        {
            using (var dbContext = new Context.AppDbContext())
            {

                var movies = dbContext.Users.Include("Status").ToList();
                return movies;
            }
        }

        public User Update(User t)
        {
            using (var dbContext = new Context.AppDbContext())
            {
                dbContext.Entry(t).State = EntityState.Modified;
                dbContext.SaveChanges();
                return t;
            }
        }

        public bool Delete(int id)
        {
            using (var dbContext = new Context.AppDbContext())
            {
                var toBeDeleted = dbContext.Users.FirstOrDefault(x => x.Id == id);
                if (toBeDeleted != null)
                {
                    dbContext.Users.Remove(toBeDeleted);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}

