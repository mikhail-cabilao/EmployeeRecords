using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EmployeeRecords.Interfaces
{
    public interface IDataContext : IDisposable
    {
        void DeleteById<TEntity>(long? id) where TEntity : class;
        Task SaveChangesAsync();
        int SaveChange();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}