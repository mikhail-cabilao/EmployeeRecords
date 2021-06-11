using EmployeeRecords.Data;
using EmployeeRecords.Interfaces;
using EmployeeRecords.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CodeLabX.EntityFramework.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public async Task SaveChangesAsync() => await base.SaveChangesAsync();

        public int SaveChange() => base.SaveChanges();

        public void DeleteById<TEntity>(long? id) where TEntity : class
        {
            if (id == null) return;

            var entitySet = Set<TEntity>();
            var entity = entitySet.Find(id.Value);

            Entry(entity).State = EntityState.Deleted;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnDatabaseTableCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void OnDatabaseTableCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable(nameof(Employee));
            DataSeed.Seed(modelBuilder);
        }
    }
}
