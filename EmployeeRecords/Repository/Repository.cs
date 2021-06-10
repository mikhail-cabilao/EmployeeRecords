using CodeLabX.EntityFramework.Data;
using EmployeeRecords.Interfaces;
using EmployeeRecords.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeLabX.EntityFramework.Repository
{
    public class Repository : IRepository
    {
        private readonly IDataContext dataContext;

        public Repository(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public DataContext DataContext()
        {
            return dataContext as DataContext;
        }

        public void SaveChanges()
        {
            dataContext.SaveChange();
        }

        public async Task SaveChangesAsync()
        {
            await dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAsync<T>() where T : class, IEntityContext
        {
            return await Task.FromResult(dataContext.Set<T>().OfType<T>());
        }

        public async Task AddAsync<T>(T entity) where T : class, IEntityContext
        {
            dataContext.Set<T>().Add(entity);
            await SaveChangesAsync();
        }

        public async Task<T> UpdateAsync<T>(T entity) where T : class, IEntityContext
        {
            var result = dataContext.Set<T>().Update(entity);
            await SaveChangesAsync();

            return result.Entity;
        }

        public bool DeleteAsync(long id)
        {
            try
            {
                dataContext.DeleteById<Employee>(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
