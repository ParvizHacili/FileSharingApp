﻿using FileSharingApp.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingApp.Data.Concrete.EfCore
{
    public class EfCoreGenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;
        public EfCoreGenericRepository(DbContext dbContext)
        {
            context = dbContext;
        }
        public void Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

        }
    }
}
