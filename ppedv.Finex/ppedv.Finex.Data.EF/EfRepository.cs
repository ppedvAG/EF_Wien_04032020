﻿using ppedv.Finex.Model;
using ppedv.Finex.Model.Contracts;
using System.Linq;

namespace ppedv.Finex.Data.EF
{
    public class EfRepository : IRepository
    {
        EfContext context = new EfContext();

        public void Add<T>(T entity) where T : Entity
        {
            //if (typeof(T) == typeof(Medikament))
            //    context.Medikamente.Add(entity as Medikament);
            context.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            context.Set<T>().Remove(entity);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return context.Set<T>();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return context.Set<T>().Find(id);
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        //nur für WebServices(WCF,WebAPI, gRPC, etc) 
        //bei lokalen Desktop Programmen funktioniert der ChangeTracker
        public void Update<T>(T entity) where T : Entity
        {
            var loaded = GetById<T>(entity.Id);
            if (loaded != null)
                context.Entry(loaded).CurrentValues.SetValues(entity);
        }
    }
}
