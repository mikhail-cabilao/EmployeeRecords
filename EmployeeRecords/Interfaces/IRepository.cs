using CodeLabX.EntityFramework.Data;
using EmployeeRecords.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRepository
{
    DataContext DataContext();
    void SaveChanges();
    Task SaveChangesAsync();
    Task<IEnumerable<T>> GetAsync<T>() where T : class, IEntityContext;
    Task AddAsync<T>(T entity) where T : class, IEntityContext;
    Task<T> UpdateAsync<T>(T entity) where T : class, IEntityContext;
    bool DeleteAsync(long id);
}