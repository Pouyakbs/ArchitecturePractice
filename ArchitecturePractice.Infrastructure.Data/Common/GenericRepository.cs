using ArchitecturePractice.Core.Contracts.Repository.Common;
using ArchitecturePractice.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchitecturePractice.Infrastructure.Data.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DemoContext Context;
        public GenericRepository(DemoContext Context)
        {
            this.Context = Context;
        }
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            Context.Entry<T>(entity).State = EntityState.Deleted;
            Context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }
    }
}
