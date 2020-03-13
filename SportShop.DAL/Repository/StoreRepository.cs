using Microsoft.EntityFrameworkCore;
using SportShop.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportShop.DAL.Repository
{
    public class StoreRepository<TEntity> : IDisposable, IStoreRepository<TEntity> where TEntity : class
    {
        private StoreDBContext context;
        private DbSet<TEntity>  dbSet;
        private bool disposed;
        public StoreRepository()
        {
            this.context = new StoreDBContext();
            this.dbSet = this.context.Set<TEntity>();
            this.disposed = false;
        }

        public void Add(TEntity product)
        {
            dbSet.Add(product);
        }

        public void Delete(int productId)
        {
            TEntity deletedEntity = dbSet.Find(productId);
            Delete(deletedEntity);
        }

        public void Delete(TEntity product)
        {
           // var deletedEntity = dbSet.Find(product);

            //if (context.Entry(deletedEntity).State == EntityState.Detached)
            //{
            //    dbSet.Attach(deletedEntity);
            //}
            dbSet.Remove(product);
        }

        public TEntity GetProductById(int productId)
        {
            return dbSet.Find(productId);
        }

        public IEnumerable<TEntity> GetProducts()
        {
            return this.dbSet.ToList();
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void Update(TEntity product)
        {
            var updatedEntity = dbSet.Find(product);
            dbSet.Attach(updatedEntity);
            context.Entry(updatedEntity).State = EntityState.Modified;
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
