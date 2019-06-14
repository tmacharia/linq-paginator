using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public interface IDbContext : IDisposable
    {
        DbContext Instance { get; }
        TModel Create<TModel>(TModel entity) where TModel : class;
        DbSet<TModel> GetDbSet<TModel>() where TModel : class;
        void SetModified(object entity);
        int Save();
    }
}
