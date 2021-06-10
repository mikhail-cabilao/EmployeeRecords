using EmployeeRecords.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace CodeLabX.EntityFramework.Extensions
{
    public static class EntityExtensions
    {
        public static TEntity ResolveEntity<TEntity>(this TEntity entiy, TEntity mapper) where TEntity : class, IEntityContext
        {
            var properties = entiy.GetType()
                .GetProperties()
                .Where(d => d.GetValue(entiy) != null && d.Name != "Id")
                .ToList();

            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(entiy);
                mapper.GetType().GetProperty(property.Name).SetValue(mapper, propertyValue);
            }

            return mapper;
        }
    }
}
