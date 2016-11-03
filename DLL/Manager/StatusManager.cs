using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Entities;

namespace DLL.Manager
{
    public class StatusManager
    {
        public Status Create(Status t)
        {
            using (var dbContext = new Context.AppDbContext())
            {
                dbContext.Statuses.Add(t);
                dbContext.SaveChanges();
                return t;
            }
        }

        public Status Read(int id)
        {
            using (var dbContext = new Context.AppDbContext())
            {
                var m = dbContext.Statuses.FirstOrDefault(x => x.Id == id);
                return m;
            }
        }

        public List<Status> ReadAll()
        {
            using (var dbContext = new Context.AppDbContext())
            {

                var movies = dbContext.Statuses.ToList();
                return movies;
            }
        }

        public Status Update(Status t)
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
                var toBeDeleted = dbContext.Statuses.FirstOrDefault(x => x.Id == id);
                if (toBeDeleted != null)
                {
                    dbContext.Statuses.Remove(toBeDeleted);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}

