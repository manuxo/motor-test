using Microsoft.EntityFrameworkCore;
using motor.infrastructure.Database;
using motor.infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace motor.infrastructure.Repositories.Implementation
{
    public class Repository<T, ID>:IRepository<T,ID> where T: class
    {
        private readonly MotorDbContext context;

        private readonly DbSet<T> set;

        public Repository(MotorDbContext _context)
        {
            context = _context;
            set = context.Set<T>();
        }

        public void Add(T entity)
        {
            set.Add(entity);
            context.SaveChanges();
        }

        public void Delete(ID id)
        {
            var current = set.Find(id);
            set.Remove(current);
            context.SaveChanges();
        }

        public T Find(ID id)
        {
            var current = set.Find(id);
            return current;
        }

        public List<T> List()
        {
            var entities = set.ToList();
            return entities;
        }

        public void Update(ID id, T entity)
        {
            var current = set.Find(id);
            ReflectionHelper.CopyPropertiesTo(entity, current, false);
            context.SaveChanges();
        }
    }
}
