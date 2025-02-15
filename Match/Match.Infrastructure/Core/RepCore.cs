using Match.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Match.Infrastructure.Core
{
    
    public class RepCore<T> : IRepCore<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public RepCore(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            IQueryable<T> query = _dbSet;
            var navigationProperties = GetNavigationProperties(typeof(T));

            foreach (var prop in navigationProperties)
            {
                query = query.Include(prop);
            }

            return query.ToList();
        }

        private IEnumerable<string> GetNavigationProperties(Type type)
        {
            var navigationProperties = type.GetProperties()
                .Where(p =>
                    (p.PropertyType.IsGenericType &&
                    typeof(IEnumerable<>).IsAssignableFrom(p.PropertyType.GetGenericTypeDefinition())) ||
                    (p.PropertyType.IsGenericType &&
                    typeof(ICollection<>).IsAssignableFrom(p.PropertyType.GetGenericTypeDefinition())))
                .Select(p => p.Name);

            return navigationProperties;
        }

        
        public List<T> GetAllById(int id)
        {
            IQueryable<T> query = _dbSet;


            var navigationProperties = GetNavigationProperties(typeof(T));

            foreach (var prop in navigationProperties)
            {
                query = query.Include(prop);
            }

            return query.Where(e => EF.Property<int>(e, "Id") == id).ToList();
        }

        public List<T> GetByIds(List<int> ids)
        {
            IQueryable<T> query = _dbSet;

            
            var navigationProperties = GetNavigationProperties(typeof(T));

            foreach (var prop in navigationProperties)
            {
                query = query.Include(prop);
            }

            
            return query.Where(e => ids.Contains(EF.Property<int>(e, "Id"))).ToList();
        }

        public T GetById(int id)
        {
            
            IQueryable<T> query = _dbSet;

            
            var navigationProperties = GetNavigationProperties(typeof(T));

            
            foreach (var prop in navigationProperties)
            {
                query = query.Include(prop);
            }

            
            return query.FirstOrDefault(e => EF.Property<int>(e, "Id") == id);
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}

