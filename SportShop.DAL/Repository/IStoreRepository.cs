using SportShop.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportShop.DAL.Repository
{
    public interface IStoreRepository<TEntity>  where TEntity : class
    {
        IEnumerable<TEntity> GetProducts();
        TEntity GetProductById(int productId);
        void Delete(int productId);
        void Delete(TEntity product);
        void Update(TEntity product);
        void Add(TEntity product);
        void Save();
    }
}
